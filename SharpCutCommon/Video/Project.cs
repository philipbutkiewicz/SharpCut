using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Newtonsoft.Json;
using SharpCutCommon.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SharpCutCommon.Properties;
using static SharpCutCommon.Video.FFMPEG;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SharpCutCommon.Video
{
    [Serializable]
    public class Project
    {
        #region Props

        /// <summary>
        /// List of all project sections
        /// </summary>
        [JsonProperty("cutSegments")]
        public List<Section> CutSegments = new List<Section>();

        /// <summary>
        /// Media file name.
        /// </summary>
        [JsonProperty("mediaFileName")]
        public string MediaFileName = "";

        /// <summary>
        /// Project file name.
        /// </summary>
        [JsonIgnore]
        public string FileName = null;

        /// <summary>
        /// List of preview frames.
        /// </summary>
        [JsonIgnore]
        public List<Image> PreviewFrames = new List<Image>();

        /// <summary>
        /// Preview frame rate.
        /// </summary>
        public double PreviewRate
        {
            get
            {
                if (string.IsNullOrEmpty(previewRate)) return 0;

                switch (previewRate)
                {
                    default:
                        return 3d / 60d;
                    case "6/60":
                        return 6d / 60d;
                    case "12/60":
                        return 12d / 60d;
                    case "24/60":
                        return 24d / 60d;
                }
            }
        }

        /// <summary>
        /// Returns the LibVLC instance.
        /// </summary>
        public static LibVLC LibVLCInstance
        {
            get { return libVLC; }
        }

        /// <summary>
        /// Currently opened project.
        /// </summary>
        [JsonIgnore]
        public static Project CurrentProject
        {
            get { return currentProject; }
            set { currentProject = value; }
        }

        #endregion

        #region Fields

        /// <summary>
        /// LibVLC instance.
        /// </summary>
        private static LibVLC libVLC;

        /// <summary>
        /// Currently opened project
        /// </summary>
        private static Project currentProject = null;

        /// <summary>
        /// Preview frame rate.
        /// </summary>
        private string previewRate = "3/60";

        /// <summary>
        /// Current progress dialog.
        /// </summary>
        private ProgressDialog progressDialog;

        /// <summary>
        /// Exported file names.
        /// </summary>
        private List<string> exportedFileNames = new List<string>();

        /// <summary>
        /// Target dir for preview frame generation.
        /// </summary>
        private string previewFramesTargetDir = "";

        #endregion

        #region Public event handlers

        /// <summary>
        /// Triggered when project export is completed.
        /// </summary>
        public event EventHandler<ExportCompletedEventArgs> ExportCompleted
        {
            add
            {
                onExportCompleted += value;
            }
            remove
            {
                onExportCompleted -= value;
            }
        }

        /// <summary>
        /// Triggered when project merge is completed.
        /// </summary>
        public event EventHandler<MergeCompletedEventArgs> MergeCompleted
        {
            add
            {
                onMergeCompleted += value;
            }
            remove
            {
                onMergeCompleted -= value;
            }
        }

        /// <summary>
        /// Triggered when project remux is completed.
        /// </summary>
        public event EventHandler<RemuxCompletedEventArgs> RemuxCompleted
        {
            add
            {
                onRemuxCompleted += value;
            }
            remove
            {
                onRemuxCompleted -= value;
            }
        }

        /// <summary>
        /// Triggered when preview frame loading is completed.
        /// </summary>
        public event EventHandler<LoadPreviewFramesCompletedEventArgs> LoadPreviewFramesCompleted
        {
            add
            {
                onLoadPreviewFramesCompleted += value;
            }
            remove
            {
                onLoadPreviewFramesCompleted -= value;
            }
        }

        /// <summary>
        /// Triggered when preview frame loading progress is updated.
        /// </summary>
        public event EventHandler<LoadPreviewFramesProgressEventArgs> LoadPreviewFramesProgress
        {
            add
            {
                onLoadPreviewFramesProgress += value;
            }
            remove
            {
                onLoadPreviewFramesProgress -= value;
            }
        }

        #endregion

        #region Event args

        /// <summary>
        /// Export completed event args.
        /// </summary>
        public class ExportCompletedEventArgs : EventArgs
        {
            public bool Success;

            public List<string> ExportedFileNames;

            public ExportCompletedEventArgs(List<string> exportedFileNames, bool success)
            {
                ExportedFileNames = exportedFileNames;
                Success = success;
            }
        }

        /// <summary>
        /// Merge completed event args.
        /// </summary>
        public class MergeCompletedEventArgs : EventArgs
        {
            public bool Success;

            public string OutputFileName;

            public MergeCompletedEventArgs(string outputFileName, bool success)
            {
                OutputFileName = outputFileName;
                Success = success;
            }
        }

        /// <summary>
        /// Remux completed event args.
        /// </summary>
        public class RemuxCompletedEventArgs : EventArgs
        {
            public bool Success;

            public string OutputFileName;

            public RemuxCompletedEventArgs(string outputFileName, bool success)
            {
                OutputFileName = outputFileName;
                Success = success;
            }
        }

        /// <summary>
        /// Load preview frames completed event args.
        /// </summary>
        public class LoadPreviewFramesCompletedEventArgs : EventArgs
        {
            public bool Success;

            public string ErrorMessage;

            public LoadPreviewFramesCompletedEventArgs(bool success, string errorMessage = "")
            {
                Success = success;
                ErrorMessage = errorMessage;
            }
        }

        /// <summary>
        /// Load preview frames completed event args.
        /// </summary>
        public class LoadPreviewFramesProgressEventArgs : EventArgs
        {
            public float Progress;

            public bool IsGeneratingNewFrames;

            public LoadPreviewFramesProgressEventArgs(float progress, bool isGeneratingNewFrames = false)
            {
                Progress = progress;
                IsGeneratingNewFrames = isGeneratingNewFrames;
            }
        }

        #endregion

        #region Private event handlers

        /// <summary>
        /// Export completed event handler.
        /// </summary>
        private EventHandler<ExportCompletedEventArgs> onExportCompleted;

        /// <summary>
        /// Merge completed event handler.
        /// </summary>
        private EventHandler<MergeCompletedEventArgs> onMergeCompleted;

        /// <summary>
        /// Remux completed event handler.
        /// </summary>
        private EventHandler<RemuxCompletedEventArgs> onRemuxCompleted;

        /// <summary>
        /// Load preview frames completed event handler.
        /// </summary>
        private EventHandler<LoadPreviewFramesCompletedEventArgs> onLoadPreviewFramesCompleted;

        /// <summary>
        /// Load preview frames progress event handler.
        /// </summary>
        private EventHandler<LoadPreviewFramesProgressEventArgs> onLoadPreviewFramesProgress;

        #endregion

        #region Static public methods

        /// <summary>
        /// Initialize the VLC library.
        /// </summary>
        /// <param name="videoView"></param>
        public static void InitializeVLC(VideoView videoView)
        {
            Core.Initialize();

            libVLC = new LibVLC();

            videoView.MediaPlayer = new MediaPlayer(libVLC);
        }

        /// <summary>
        /// Create Project from file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Project CreateFromFile(string fileName)
        {
            string projectFile = File.ReadAllText(fileName).Replace("sections", "cutSegments");
            return JsonConvert.DeserializeObject<Project>(projectFile);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Export section timestamps as a CSV file.
        /// </summary>
        public void ExportTimestampsToCsv()
        {
            if (CutSegments.Count < 1) return;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Resources.CsvFilter;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string csv = "";
                    foreach (Section section in CutSegments)
                    {
                        csv += $"{section.GetStartString()},{section.GetEndString()},{section.Name}\r\n";
                    }

                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }

                    File.WriteAllText(saveFileDialog.FileName, csv);
                }
            }
        }

        /// <summary>
        /// Export section timestamps as YouTube chapters.
        /// </summary>
        public void ExportTimestampsToYoutubeChapters()
        {
            if (CutSegments.Count < 1) return;

            string youtubeChapters = "";
            foreach (Section section in CutSegments)
            {
                youtubeChapters += $"{section.GetStartEndString()} {section.Name}\r\n";
            }

            Clipboard.SetText(youtubeChapters);
        }

        /// <summary>
        /// Export sections as videos.
        /// </summary>
        /// <param name="container"></param>
        public void Export(string container = null)
        {
            exportedFileNames.Clear();

            foreach (Section section in CutSegments)
            {
                FFMPEG fFMPEG = new FFMPEG();
                fFMPEG.Progress += FFMPEG_Progress;
                fFMPEG.Completed += Export_FFMPEG_Completed;
                fFMPEG.ExportSection(MediaFileName, section, container);

                progressDialog = new ProgressDialog();
                progressDialog.ProgressTitle = Resources.ExportingSections;
                progressDialog.ShowDialog();
            }

            OnExportCompleted(new ExportCompletedEventArgs(exportedFileNames, true));
        }

        /// <summary>
        /// Merge video files.
        /// </summary>
        /// <param name="originalFileName"></param>
        /// <param name="toMerge"></param>
        /// <param name="container"></param>
        public void Merge(string originalFileName, List<string> toMerge, string container = null)
        {
            if (container == null)
            {
                container = toMerge.Count > 0 ? Path.GetExtension(toMerge[0]) : "mp4";
            }

            FFMPEG fFMPEG = new FFMPEG();
            fFMPEG.Progress += FFMPEG_Progress;
            fFMPEG.Completed += FFMPEG_Merge_Completed;
            fFMPEG.Merge(originalFileName, toMerge, container);

            progressDialog = new ProgressDialog();
            progressDialog.ProgressTitle = Resources.MergingFiles;
            progressDialog.ShowDialog();
        }

        /// <summary>
        /// Remux a video to a different container.
        /// </summary>
        /// <param name="mediaFileName"></param>
        /// <param name="container"></param>
        public void Remux(string mediaFileName, string container)
        {
            FFMPEG fFMPEG = new FFMPEG();
            fFMPEG.Progress += FFMPEG_Progress;
            fFMPEG.Completed += FFMPEG_RemuxCompleted;
            fFMPEG.Remux(mediaFileName, container);

            progressDialog = new ProgressDialog();
            progressDialog.ProgressTitle = Resources.RemuxingFiles;
            progressDialog.ShowDialog();
        }

        /// <summary>
        /// Load preview frames.
        /// </summary>
        public void LoadPreviewFrames()
        {
            previewFramesTargetDir = Path.Combine(DirUtil.GetWorkingDir(), Path.GetFileName(MediaFileName));
            if (!Directory.Exists(previewFramesTargetDir))
            {
                Directory.CreateDirectory(previewFramesTargetDir);
            }

            string[] previewFrameFileNames = Directory.GetFiles(previewFramesTargetDir, "*.jpg", SearchOption.TopDirectoryOnly);
            if (previewFrameFileNames.Length == 0 && (!File.Exists(Path.Combine(previewFramesTargetDir, "preview_info")) && !File.Exists(Path.Combine(previewFramesTargetDir, "preview.bin"))))
            {
                previewRate = Settings.Default.PreviewRate;
                Console.WriteLine("Preview frames not found, generating...");
                GeneratePreviewFrames();
                return;
            }
            
            if (File.Exists(Path.Combine(previewFramesTargetDir, "preview_info")) && !File.Exists(Path.Combine(previewFramesTargetDir, "preview.bin")))
            {
                previewRate = File.ReadAllText(Path.Combine(previewFramesTargetDir, "preview_info"));
            }

            FinishLoadingPreviewFrames(previewFrameFileNames);
        }

        /// <summary>
        /// Method that uses the ImageConverter object in .Net Framework to convert a byte array, 
        /// presumably containing a JPEG or PNG file image, into a Bitmap object, which can also be 
        /// used as an Image object.
        /// </summary>
        /// <param name="byteArray">byte array containing JPEG or PNG file image or similar</param>
        /// <returns>Bitmap object if it works, else exception is thrown</returns>
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            ImageConverter _imageConverter = new ImageConverter();
            try
            {
                Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

                if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                                   bm.VerticalResolution != (int)bm.VerticalResolution))
                {
                    // Correct a strange glitch that has been observed in the test program when converting 
                    //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                    //  slightly away from the nominal integer value
                    bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                     (int)(bm.VerticalResolution + 0.5f));
                }

                return bm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Bitmap(320, 240);
        }

        /// <summary>
        /// Serializes this object and returns result as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Generates preview frames.
        /// </summary>
        private void GeneratePreviewFrames()
        {
            FFMPEG fFMPEG = new FFMPEG();
            fFMPEG.Progress += FFMPEG_GeneratePreviewFrames_Progress;
            fFMPEG.Completed += FFMPEG_GeneratePreviewFrames_Completed;
            fFMPEG.GeneratePreviewFrames(MediaFileName, previewFramesTargetDir, previewRate);
        }

        /// <summary>
        /// Finishes loading preview frames from a list of files.
        /// </summary>
        /// <param name="previewFrameFileNames"></param>
        private void FinishLoadingPreviewFrames(string[] previewFrameFileNames)
        {
            Task.Run(() =>
            {
                try
                {
                    if (!File.Exists(Path.Combine(previewFramesTargetDir, "preview.bin")))
                    {
                        Console.WriteLine("preview.bin not found, attempting to load legacy preview frames...");

                        if (previewFrameFileNames.Length == 0)
                        {
                            OnLoadPreviewFramesCompleted(new LoadPreviewFramesCompletedEventArgs(false, "No preview frames were available"));
                            return;
                        }

                        int currentIndex = 0;
                        foreach (string file in previewFrameFileNames)
                        {
                            Image image = Image.FromFile(file);
                            PreviewFrames.Add(image);
                            currentIndex++;

                            float percentComplete = currentIndex > 0 ? currentIndex / previewFrameFileNames.Length : 0;
                            OnLoadPreviewFramesProgress(new LoadPreviewFramesProgressEventArgs(percentComplete));
                        }
                    }
                    else
                    {
                        Console.WriteLine("preview.bin found, attempting to load preview frames...");

                        string[] desc = File.ReadAllText(Path.Combine(previewFramesTargetDir, "info.dat")).Split(new char[] { '\n' });
                        previewRate = desc[0] + "/60";

                        using (FileStream fs = new FileStream(Path.Combine(previewFramesTargetDir, "preview.bin"), FileMode.Open, FileAccess.Read))
                        {
                            for (int i = 1; i < desc.Length; i++)
                            {
                                string s = desc[i];
                                if (!string.IsNullOrEmpty(s))
                                {
                                    int len = int.Parse(s);

                                    byte[] frame = new byte[len];
                                    fs.Read(frame, 0, len);

                                    PreviewFrames.Add(GetImageFromByteArray(frame));

                                    float percentComplete = i > 0 ? i / desc.Length : 0;
                                    OnLoadPreviewFramesProgress(new LoadPreviewFramesProgressEventArgs(percentComplete));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OnLoadPreviewFramesCompleted(new LoadPreviewFramesCompletedEventArgs(false, ex.Message));
                    return;
                }

                OnLoadPreviewFramesCompleted(new LoadPreviewFramesCompletedEventArgs(true));
            });
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Triggered after FFMPEG completes its processing, starting in Export.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export_FFMPEG_Completed(object sender, CompletedEventArgs e)
        {
            if (!e.Success)
            {
                MessageBox.Show(Resources.ProjectExportError.Replace("%e", e.FailureReason), Resources.ProjectExportErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnExportCompleted(new ExportCompletedEventArgs(null, false));
                return;
            }

            progressDialog?.Close();

            exportedFileNames.Add((string)e.Result);
        }


        /// <summary>
        /// Triggered after FFMPEG completes its processing, starting in Merge.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FFMPEG_Merge_Completed(object sender, CompletedEventArgs e)
        {
            if (!e.Success)
            {
                MessageBox.Show(Resources.ProjectMergeError.Replace("%e", e.FailureReason), Resources.ProjectMergeErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnMergeCompleted(new MergeCompletedEventArgs(null, false));
                return;
            }

            progressDialog?.Close();

            OnMergeCompleted(new MergeCompletedEventArgs((string)e.Result, true));
        }

        /// <summary>
        /// Triggered after FFMPEG completes its processing, starting in Remux.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FFMPEG_RemuxCompleted(object sender, CompletedEventArgs e)
        {
            if (!e.Success)
            {
                MessageBox.Show(Resources.ProjectRemuxError.Replace("%e", e.FailureReason), Resources.ProjectRemuxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnRemuxCompleted(new RemuxCompletedEventArgs(null, false));
                return;
            }

            progressDialog?.Close();

            OnRemuxCompleted(new RemuxCompletedEventArgs((string)e.Result, true));
        }


        /// <summary>
        /// Triggered after FFMPEG completes its processing, starting in GeneratePreviewFrames.
        /// Will further trigger FinishLoadingPreviewFrames.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FFMPEG_GeneratePreviewFrames_Completed(object sender, CompletedEventArgs e)
        {
            if (!e.Success)
            {
                OnLoadPreviewFramesCompleted(new LoadPreviewFramesCompletedEventArgs(false));
                return;
            }

            File.WriteAllText(Path.Combine(previewFramesTargetDir, "preview_info"), previewRate);

            string[] previewFrameFileNames = Directory.GetFiles(previewFramesTargetDir, "*.jpg", SearchOption.TopDirectoryOnly);
            FinishLoadingPreviewFrames(previewFrameFileNames);
        }

        /// <summary>
        /// Called to update FFMPEG progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FFMPEG_Progress(object sender, ProgressEventArgs e)
        {
            try
            {
                progressDialog?.SetProgress(e.ProgressPercentage, e.CurrentTime, e.TotalTime);
            }
            catch
            {
                // Progress dialog may be disposed before we make a call here. Completed event might come earlier than the progress event. Lol fml.
            }
        }

        /// <summary>
        /// Called to update preview frame generation progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FFMPEG_GeneratePreviewFrames_Progress(object sender, ProgressEventArgs e)
        {
            OnLoadPreviewFramesProgress(new LoadPreviewFramesProgressEventArgs(e.ProgressPercentage > 0 ? e.ProgressPercentage / 100f : 0f, true));
        }

        #endregion

        #region Event callers

        protected void OnExportCompleted(ExportCompletedEventArgs e)
        {
            onExportCompleted?.Invoke(this, e);
        }

        protected void OnMergeCompleted(MergeCompletedEventArgs e)
        {
            onMergeCompleted?.Invoke(this, e);
        }

        protected void OnRemuxCompleted(RemuxCompletedEventArgs e)
        {
            onRemuxCompleted?.Invoke(this, e);
        }

        protected void OnLoadPreviewFramesCompleted(LoadPreviewFramesCompletedEventArgs e)
        {
            onLoadPreviewFramesCompleted?.Invoke(this, e);
        }

        protected void OnLoadPreviewFramesProgress(LoadPreviewFramesProgressEventArgs e)
        {
            onLoadPreviewFramesProgress?.Invoke(this, e);
        }

        #endregion
    }
}
