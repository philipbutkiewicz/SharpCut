using SharpCutCommon.Properties;
using SharpCutCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace SharpCutCommon.Video
{
    public class FFMPEG
    {
        #region Public event handlers

        /// <summary>
        /// Triggered when any conversion is in progress.
        /// </summary>
        public event EventHandler<ProgressEventArgs> Progress
        {
            add
            {
                onProgress += value;
            }
            remove
            {
                onProgress -= value;
            }
        }

        /// <summary>
        /// Triggered when any conversion is completed or fails.
        /// </summary>
        public event EventHandler<CompletedEventArgs> Completed
        {
            add
            {
                onCompleted += value;
            }
            remove
            {
                onCompleted -= value;
            }
        }

        #endregion

        #region Event args

        /// <summary>
        /// Progress event args.
        /// </summary>
        public class ProgressEventArgs : EventArgs
        {
            /// <summary>
            /// Current conversion progress percentage (0-100).
            /// </summary>
            public int ProgressPercentage;

            /// <summary>
            /// Current conversion progress (current time).
            /// </summary>
            public TimeSpan CurrentTime;

            /// <summary>
            /// Total length of the converted file.
            /// </summary>
            public TimeSpan TotalTime;

            public ProgressEventArgs(int progressPercentage = 0, TimeSpan currentTime = default, TimeSpan totalTime = default)
            {
                ProgressPercentage = progressPercentage;
                CurrentTime = currentTime;
                TotalTime = totalTime;
            }
        }

        /// <summary>
        /// Completed event args.
        /// </summary>
        public class CompletedEventArgs : EventArgs
        {
            /// <summary>
            /// Conversion result (usually string).
            /// </summary>
            public object Result;

            /// <summary>
            /// Was the conversion successful.
            /// </summary>
            public bool Success;

            /// <summary>
            /// Failure reason (if conversion was not successful).
            /// </summary>
            public string FailureReason;

            public CompletedEventArgs(object result = null, bool success = false, string failureReason = "")
            {
                Result = result;
                Success = success;
                FailureReason = failureReason;
            }
        }

        #endregion

        #region Private event handlers

        /// <summary>
        /// Progress event handler.
        /// </summary>
        private EventHandler<ProgressEventArgs> onProgress;

        /// <summary>
        /// Completion event handler.
        /// </summary>
        private EventHandler<CompletedEventArgs> onCompleted;

        #endregion

        #region Public methods

        /// <summary>
        /// Export a single video section.
        /// </summary>
        /// <param name="mediaFileName"></param>
        /// <param name="section"></param>
        /// <param name="container"></param>
        public void ExportSection(string mediaFileName, Section section, string container)
        {
            string absoluteMediaFileName = GetAbsoluteMediaFileName(mediaFileName);
            string extension = Path.GetExtension(absoluteMediaFileName);
            string outputFileName = absoluteMediaFileName.Replace(
                Path.GetFileName(absoluteMediaFileName),
                StringUtil.ParseTemplate(
                    Settings.Default.SegmentFileNameTemplate,
                    Path.GetFileName(absoluteMediaFileName),
                    string.IsNullOrEmpty(container) ? extension.Replace(".", "") : container,
                    section.GetStartString().Replace(":", "."),
                    section.GetEndString().Replace(":", ".")
                )
            );

            MoveOldOutputFile(outputFileName);

            IConversion conversion = GetConversion()
                .AddParameter($"-i \"{absoluteMediaFileName}\"")
                .SetInputTime(TimeSpan.FromSeconds(section.End - section.Start))
                .SetSeek(TimeSpan.FromSeconds(section.Start))
                .AddParameter("-c copy")
                .SetOutput(outputFileName);

            StartAndAwaitConversion(conversion, outputFileName);
        }

        /// <summary>
        /// Remux a video file.
        /// </summary>
        /// <param name="mediaFileName"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public void Remux(string mediaFileName, string container)
        {
            string absoluteMediaFileName = GetAbsoluteMediaFileName(mediaFileName);
            string extension = Path.GetExtension(absoluteMediaFileName);
            string outputFileName = container == null ? absoluteMediaFileName : absoluteMediaFileName.Replace(extension, $".{container}");

            MoveOldOutputFile(outputFileName);

            IConversion conversion = GetConversion()
                .AddParameter($"-i \"{absoluteMediaFileName}\"")
                .AddParameter("-c copy")
                .SetOutput(outputFileName);

            StartAndAwaitConversion(conversion, outputFileName);
        }

        /// <summary>
        /// Merges multiple files into one.
        /// </summary>
        /// <param name="originalFileName"></param>
        /// <param name="filesToMerge"></param>
        /// <param name="container"></param>
        /// <exception cref="Exception"></exception>
        public void Merge(string originalFileName, List<string> filesToMerge, string container)
        {
            if (filesToMerge.Count == 0)
            {
                throw new Exception("Need to provide at least 1 file.");
            }

            string absoluteMediaFileName = GetAbsoluteMediaFileName(originalFileName);
            string extension = Path.GetExtension(filesToMerge[0]);
            string outputFileName = filesToMerge[0].Replace(
                Path.GetFileName(filesToMerge[0]),
                StringUtil.ParseTemplate(
                    Settings.Default.MergedFileNameTemplate,
                    Path.GetFileName(absoluteMediaFileName),
                    string.IsNullOrEmpty(container) ? extension.Replace(".", "") : container
                )
            );
            string mergeFileName = Path.Combine(Environment.GetEnvironmentVariable("tmp"), $"SharpCut_{StringUtil.RandomString(24)}");

            MoveOldOutputFile(outputFileName);

            string list = "";
            foreach (string file in filesToMerge)
            {
                list += $"file '{file}'\n";
            }

            File.WriteAllText(mergeFileName, list);

            IConversion conversion = GetConversion()
                .AddParameter("-f concat")
                .AddParameter("-safe 0")
                .AddParameter($"-i \"{mergeFileName}\"")
                .AddParameter("-c copy")
                .SetOutput(outputFileName);

            StartAndAwaitConversion(conversion, outputFileName);
        }

        /// <summary>
        /// Generate preview frames for media.
        /// </summary>
        /// <param name="mediaFileName"></param>
        /// <param name="targetDir"></param>
        /// <param name="rate"></param>
        public void GeneratePreviewFrames(string mediaFileName, string targetDir, string rate)
        {
            string absoluteMediaFileName = GetAbsoluteMediaFileName(mediaFileName);
            string targetName = Path.Combine(targetDir, "%04d.jpg");

            IConversion conversion = GetConversion()
                .AddParameter($"-i \"{absoluteMediaFileName}\"")
                .AddParameter($"-vf \"fps=fps={rate},scale=-1:144\"")
                .SetOutput(targetName);

            StartAndAwaitConversion(conversion);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets the Xabe.Ffmpeg conversion object.
        /// </summary>
        /// <returns></returns>
        private IConversion GetConversion()
        {
            IConversion conversion = FFmpeg.Conversions.New();
            conversion.OnProgress += Conversion_OnProgress;

            return conversion;
        }

        /// <summary>
        /// Starts and awaits conversion.
        /// </summary>
        /// <param name="conversion"></param>
        /// <param name="callbackResult"></param>
        private async void StartAndAwaitConversion(IConversion conversion, object callbackResult = null)
        {
            try
            {
                await conversion.Start();
            }
            catch (Exception ex)
            {
                OnCompleted(new CompletedEventArgs(null, false, ex.Message));
                return;
            }

            OnCompleted(new CompletedEventArgs(callbackResult, true));
        }

        /// <summary>
        /// Moves old output files.
        /// </summary>
        /// <param name="outputFileName"></param>
        private void MoveOldOutputFile(string outputFileName)
        {
            if (File.Exists(outputFileName))
            {
                File.Move(outputFileName, $"{outputFileName.Replace(Path.GetExtension(outputFileName), "")}.old-{StringUtil.RandomString(6)}.{Path.GetExtension(outputFileName)}");
            }
        }

        /// <summary>
        /// Returns an absolute path to media.
        /// </summary>
        /// <param name="mediaFileName"></param>
        /// <returns></returns>
        private string GetAbsoluteMediaFileName(string mediaFileName)
        {
            if (Path.IsPathRooted(mediaFileName))
            {
                return mediaFileName;
            }

            return Path.Combine(Path.GetDirectoryName(Project.CurrentProject.FileName), mediaFileName);
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Progress event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Conversion_OnProgress(object sender, ConversionProgressEventArgs args)
        {
            OnProgress(new ProgressEventArgs(args.Percent, args.Duration, args.TotalLength));
        }

        #endregion

        #region Event callers

        /// <summary>
        /// Progress event caller.
        /// </summary>
        /// <param name="e"></param>
        protected void OnProgress(ProgressEventArgs e)
        {
            onProgress?.Invoke(null, e);
        }

        /// <summary>
        /// Completion event caller.
        /// </summary>
        /// <param name="e"></param>
        protected void OnCompleted(CompletedEventArgs e)
        {
            onCompleted?.Invoke(null, e);
        }

        #endregion
    }
}
