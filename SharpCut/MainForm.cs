using LibVLCSharp.Shared;
using SharpCutCommon;
using SharpCutCommon.Dialogs;
using SharpCutCommon.Plugins;
using SharpCutCommon.Properties;
using SharpCutCommon.Util;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpCut.Controls.Timeline;

namespace SharpCut
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Fields

        private Image imageSplash;

        private DateTime lastPlayTime = DateTime.Now;

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the app and the project.
        /// </summary>
        private void InitProject()
        {
            Project.InitializeVLC(videoView);

            videoView.MediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
            videoView.MediaPlayer.EncounteredError += MediaPlayer_EncounteredError;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (Path.GetExtension(args[1]).ToLower() == ".llc")
                {
                    OpenProject(args[1]);
                }
                else
                {
                    OpenVideoFile(args[1], true);
                }
            }
        }

        /// <summary>
        /// Initialize project events.
        /// </summary>
        private void InitProjectEvents()
        {
            Project.CurrentProject.LoadPreviewFramesCompleted += CurrentProject_LoadPreviewFramesCompleted;
            Project.CurrentProject.LoadPreviewFramesProgress += CurrentProject_LoadPreviewFramesProgress;
            Project.CurrentProject.MergeCompleted += CurrentProject_MergeCompleted;
        }

        /// <summary>
        /// Deinitialize project events.
        /// </summary>
        private void UninitProjectEvents()
        {
            Project.CurrentProject.LoadPreviewFramesCompleted -= CurrentProject_LoadPreviewFramesCompleted;
            Project.CurrentProject.LoadPreviewFramesProgress -= CurrentProject_LoadPreviewFramesProgress;
            Project.CurrentProject.MergeCompleted -= CurrentProject_MergeCompleted;
        }

        /// <summary>
        /// Initialize splash image.
        /// </summary>
        private void InitSplash()
        {
            imageSplash = Image.FromFile(Path.Combine(Path.Combine(Program.AssemblyDirectory, "Resources"), Settings.Default.IsBetaBuild ? "BetaTestingChannel.png" : "DefaultSplash.png"));
        }

        /// <summary>
        /// Initializes updates.
        /// </summary>
        private void InitUpdates()
        {
            updateTimer.Start();
        }

        /// <summary>
        /// Loads user settings.
        /// </summary>
        private void LoadSettings()
        {
            timeline.ScrollSpeed = Settings.Default.TimelineScrollSpeed;
        }

        /// <summary>
        /// Opens a video from file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="autoOpenProject"></param>
        private void OpenVideoFile(string fileName, bool autoOpenProject = false)
        {
            timeline.Clear();

            if (!FFMPEG.IsMediaSupported(fileName))
            {
                MessageBox.Show(Resources.ErrorFormatNotSupported, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseFile(); return;
            }

            string projectFileName = fileName.Replace(
                Path.GetFileName(fileName),
                StringUtil.ParseTemplate(
                    Settings.Default.ProjectFileNameTemplate,
                    Path.GetFileName(fileName),
                    "llc"
                )
            );

            if (File.Exists(projectFileName) && autoOpenProject)
            {
                OpenProject(projectFileName); return;
            }

            if (Project.CurrentProject != null)
            {
                UninitProjectEvents();
            }

            if (Project.CurrentProject == null || Project.CurrentProject.MediaFileName != fileName)
            {
                Project.CurrentProject = new Project()
                {
                    MediaFileName = fileName,
                };

                InitProjectEvents();
            }

            if (Settings.Default.GenerateFastPreview)
            {
                Project.CurrentProject.LoadPreviewFrames();
            }

            try
            {
                videoView.MediaPlayer.Media = new Media(Project.LibVLCInstance, fileName, fileName.Contains("://") ? FromType.FromLocation : FromType.FromPath);
                videoView.MediaPlayer.FileCaching = 250;
                videoView.MediaPlayer.NetworkCaching = 250;
                videoView.MediaPlayer.Volume = 0;
                videoView.MediaPlayer.Play();

                timerPause.Start();

                Text = "SharpCut - " + fileName;

                SetVideoControlsEnabled();
            }
            catch
            {
                MessageBox.Show(Resources.ErrorLoadingVideo, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Opens a project file.
        /// </summary>
        /// <param name="fileName"></param>
        private void OpenProject(string fileName)
        {
            try
            {
                Project project = Project.CreateFromFile(fileName);
                if (project != null)
                {
                    Project.CurrentProject = project;
                }

                project.FileName = fileName;

                if (!project.MediaFileName.Contains("://") && !Path.IsPathRooted(project.MediaFileName))
                {
                    project.MediaFileName = fileName.Replace(Path.GetFileName(fileName), project.MediaFileName);
                }

                OpenVideoFile(project.MediaFileName);

                timeline.Sections = Project.CurrentProject.CutSegments;
                timeline.Invalidate();

                SetVideoControlsEnabled();
                SetSelectionLabel();
            }
            catch
            {
                MessageBox.Show(Resources.ErrorLoadingProject, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        /// <summary>
        /// Loads plugins.
        /// </summary>
        private void LoadPlugins()
        {
            PluginManager.LoadPlugins(Project.CurrentProject);

            foreach (ISharpCutPlugin plugin in PluginManager.Plugins)
            {
                SharpCutPluginInfo pluginInfo = plugin.GetPluginInfo();

                ToolStripMenuItem pluginToolStripMenuItem = new ToolStripMenuItem(pluginInfo.Name);

                ToolStripItemCollection collection = pluginsGeneralToolStripMenuItem.DropDownItems;
                switch (pluginInfo.Category)
                {
                    case SharpCutPluginInfo.PluginCategory.MediaUtility:
                        collection = pluginsMediaUtilitiesToolStripMenuItem.DropDownItems;
                        break;
                    case SharpCutPluginInfo.PluginCategory.Analysis:
                        collection = pluginsAnalysisToolStripMenuItem.DropDownItems;
                        break;
                    case SharpCutPluginInfo.PluginCategory.Cutting:
                        collection = pluginsCuttingToolStripMenuItem.DropDownItems;
                        break;
                }

                collection.Add(pluginToolStripMenuItem);

                Dictionary<string, Action> actions = plugin.GetPluginActions();
                if (actions != null)
                {
                    foreach (KeyValuePair<string, Action> action in actions)
                    {
                        ToolStripMenuItem pluginActionToolStripMenuItem = new ToolStripMenuItem(action.Key);
                        pluginActionToolStripMenuItem.Click += delegate
                        {
                            action.Value();
                        };

                        pluginToolStripMenuItem.DropDownItems.Add(pluginActionToolStripMenuItem);
                    }

                    if (pluginInfo.CanExecute)
                    {
                        ToolStripMenuItem pluginExecuteToolStripMenuItem = new ToolStripMenuItem(Resources.ExecutePlugin);
                        pluginExecuteToolStripMenuItem.Click += delegate
                        {
                            plugin.Execute();
                        };

                        pluginToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
                        pluginToolStripMenuItem.DropDownItems.Add(pluginExecuteToolStripMenuItem);
                    }
                }
                else
                {
                    pluginToolStripMenuItem.Click += delegate
                    {
                        plugin.Execute();
                    };
                }
            }

            pluginsToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// <summary>
        /// Unloads plugins.
        /// </summary>
        private void UnloadPlugins()
        {
            PluginManager.UnloadPlugins();

            pluginsToolStripMenuItem.DropDownItems.Clear();

            pluginsToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Called when auto-save request is made.
        /// </summary>
        private void AutoSaveFile()
        {
            if (string.IsNullOrEmpty(Project.CurrentProject.MediaFileName) || !Settings.Default.AutoSaveProject) return;

            if (string.IsNullOrEmpty(Project.CurrentProject.FileName))
            {
                string mediaFileName = Path.GetFileName(Project.CurrentProject.MediaFileName);
                string projectFileName = StringUtil.ParseTemplate(
                    Settings.Default.ProjectFileNameTemplate,
                    mediaFileName,
                    "llc"
                );

                Project.CurrentProject.FileName = Project.CurrentProject.MediaFileName.Replace(Path.GetFileName(Project.CurrentProject.MediaFileName), projectFileName);
            }

            SaveFile();
        }

        /// <summary>
        /// Saves currently opened file.
        /// </summary>
        /// <param name="saveAs"></param>
        private void SaveFile(bool saveAs = false)
        {

            if (string.IsNullOrEmpty(Project.CurrentProject.FileName) || saveAs || Project.CurrentProject.MediaFileName.Contains("://"))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    string projectFileName = StringUtil.ParseTemplate(
                        Settings.Default.ProjectFileNameTemplate,
                        Path.GetFileName(Project.CurrentProject.MediaFileName),
                        "llc"
                    );

                    saveFileDialog.Filter = Resources.ProjectFormatFilter;
                    saveFileDialog.DefaultExt = ".llc";
                    saveFileDialog.InitialDirectory = Project.CurrentProject.MediaFileName.Replace(Path.GetFileName(Project.CurrentProject.MediaFileName), "");
                    saveFileDialog.FileName = projectFileName;

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    Project.CurrentProject.FileName = saveFileDialog.FileName;
                }
            }

            if (!Project.CurrentProject.MediaFileName.Contains("://") && Path.GetDirectoryName(Project.CurrentProject.MediaFileName) == Path.GetDirectoryName(Project.CurrentProject.FileName))
            {
                Project.CurrentProject.MediaFileName = Path.GetFileName(Project.CurrentProject.MediaFileName);
            }

            File.WriteAllText(Project.CurrentProject.FileName, Project.CurrentProject.ToString());
        }

        /// <summary>
        /// Closes current file.
        /// </summary>
        private void CloseFile()
        {
            SetVideoControlsEnabled(false);

            videoView.MediaPlayer.Stop();
            videoView.MediaPlayer.Media.Dispose();

            timeline.Clear();

            SetSelectionLabel(true);

            Text = "SharpCut";
        }

        /// <summary>
        /// Exports current media.
        /// </summary>
        /// <param name="exportSettings"></param>
        /// <returns></returns>
        private ExportSettings ExportMedia(ExportSettings exportSettings = null)
        {
            if (Project.CurrentProject.CutSegments.Count == 0)
            {
                MessageBox.Show(Resources.ErrorCutSectionsRequiredBeforeExport, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return null;
            }

            using (ExportForm exportForm = new ExportForm())
            {
                exportForm.DefaultExportSettings = exportSettings;
                exportForm.ShowDialog();

                return exportForm.DefaultExportSettings;
            }
        }

        /// <summary>
        /// Merges video files.
        /// </summary>
        /// <param name="originalFileName"></param>
        /// <param name="fileNamesToMerge"></param>
        private void MergeFiles(string originalFileName, List<string> fileNamesToMerge)
        {
            if (Project.CurrentProject == null)
            {
                Project.CurrentProject = new Project();
                InitProjectEvents();
            }

            Project.CurrentProject.Merge(originalFileName, fileNamesToMerge);
        }

        /// <summary>
        /// Remuxes video files.
        /// </summary>
        /// <param name="container"></param>
        private void RemuxFile(string container)
        {
            string extension = Path.GetExtension(Project.CurrentProject.MediaFileName).Replace(".", "").ToLower();
            if (extension == container)
            {
                MessageBox.Show(Resources.ErrorCannotRemuxToSource, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            Project.CurrentProject.Remux(Project.CurrentProject.MediaFileName, container);
        }

        /// <summary>
        /// Captures current frame to a file.
        /// </summary>
        private void CaptureFrame()
        {
            if (Project.CurrentProject == null || string.IsNullOrEmpty(Project.CurrentProject.MediaFileName) ||
                videoView.MediaPlayer == null || videoView.MediaPlayer.Media == null) return;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Resources.CaptureFrameFormatFilter;
                saveFileDialog.DefaultExt = "jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    videoView.MediaPlayer.TakeSnapshot(0, saveFileDialog.FileName, 0, 0);
                }
            }
        }

        /// <summary>
        /// Toggle editing controls on/off.
        /// </summary>
        /// <param name="enabled"></param>
        private void SetVideoControlsEnabled(bool enabled = true)
        {
            closeToolStripMenuItem.Enabled = enabled;
            saveToolStripMenuItem.Enabled = enabled;
            saveAsToolStripMenuItem.Enabled = enabled;
            exportMediaToolStripMenuItem.Enabled = enabled;
            editToolStripMenuItem.Enabled = enabled;
            remuxToToolStripMenuItem.Enabled = enabled;
            buttonInsertCut.Enabled = enabled;
            buttonRemoveCut.Enabled = enabled;
            buttonSetCutStartTime.Enabled = enabled;
            buttonSetCutEndTime.Enabled = enabled;
            buttonExport.Enabled = enabled;
            buttonCaptureFrame.Enabled = enabled;
            exportTimestampsToolStripMenuItem.Enabled = enabled;
        }

        /// <summary>
        /// Inserts a cut.
        /// </summary>
        private void InsertCut()
        {
            if (Project.CurrentProject == null) return;

            Section prevSection = Project.CurrentProject.CutSegments.Count > 0 ? Project.CurrentProject.CutSegments[Project.CurrentProject.CutSegments.Count - 1] : null;
            if ((prevSection != null && timeline.Time == prevSection.Start) || (prevSection != null && prevSection.End == 0)) return;

            Section newSection = new Section()
            {
                Start = timeline.Time >= 0 ? timeline.Time : 0,
                End = timeline.Duration,
                SectionColor = Section.RandomColor()
            };

            Project.CurrentProject.CutSegments.Add(newSection);

            timeline.Sections = Project.CurrentProject.CutSegments;
            timeline.SelectedSection = newSection;
            timeline.Invalidate();

            SetSelectionLabel();

            AutoSaveFile();
        }

        /// <summary>
        /// Removes a cut.
        /// </summary>
        private void RemoveCut()
        {
            if (Project.CurrentProject == null || timeline.SelectedSection == null) return;

            Project.CurrentProject.CutSegments.Remove(timeline.SelectedSection);

            timeline.SelectedSection = null;
            timeline.Sections = Project.CurrentProject.CutSegments;
            timeline.Invalidate();

            SetSelectionLabel();

            AutoSaveFile();
        }

        /// <summary>
        /// Sets cut start time.
        /// </summary>
        private void SetCutStartTime()
        {
            if (Project.CurrentProject == null) return;

            if (timeline.SelectedSection == null)
            {
                InsertCut();
                return;
            }

            if (timeline.SelectedSection.End != 0 && timeline.Time > timeline.SelectedSection.End) return;

            timeline.SelectedSection.Start = timeline.Time >= 0 ? timeline.Time : 0;

            timeline.Sections = Project.CurrentProject.CutSegments;
            timeline.Invalidate();

            SetSelectionLabel();

            AutoSaveFile();
        }

        /// <summary>
        /// Sets cut end time.
        /// </summary>
        private void SetCutEndTime()
        {
            if (Project.CurrentProject == null || timeline.SelectedSection == null) return;

            if (timeline.Time <= timeline.SelectedSection.Start) return;

            // Prevent sections smaller than 1000ms and set the end time
            double endTime = timeline.Time <= timeline.Duration ? timeline.Time : timeline.Duration;
            if (timeline.Time < timeline.Duration && (timeline.Time - timeline.SelectedSection.Start) < 1d)
            {
                endTime = timeline.SelectedSection.Start + 1d;
            }

            timeline.SelectedSection.End = endTime;

            timeline.Sections = Project.CurrentProject.CutSegments;
            timeline.Invalidate();

            SetSelectionLabel();

            AutoSaveFile();
        }

        /// <summary>
        /// Sets cut start time from user input.
        /// </summary>
        private void SetCutStartTimeFromInput()
        {
            if (timeline.SelectedSection == null) return;

            using (TimeInputDialog timeInputDialog = new TimeInputDialog())
            {
                timeInputDialog.LabelText = Resources.SetCutStartTimeInput;
                timeInputDialog.Time = timeline.SelectedSection.Start;
                timeInputDialog.MinTime = 0d;
                timeInputDialog.MaxTime = timeline.SelectedSection.End - 1d;

                if (timeInputDialog.ShowDialog() == DialogResult.OK)
                {
                    timeline.Time = timeInputDialog.Time;

                    timeline_TimeChanged(this, new TimeChangedEventArgs(false));

                    HidePreviewFrame();
                    SetCutStartTime();
                }
            }
        }

        /// <summary>
        /// Sets cut end time from user input.
        /// </summary>
        private void SetCutEndTimeFromInput()
        {
            if (timeline.SelectedSection == null) return;

            using (TimeInputDialog timeInputDialog = new TimeInputDialog())
            {
                timeInputDialog.LabelText = Resources.SetCutEndTimeInput;
                timeInputDialog.Time = timeline.SelectedSection.End;
                timeInputDialog.MinTime = timeline.SelectedSection.Start + 1d;
                timeInputDialog.MaxTime = timeline.Duration;

                if (timeInputDialog.ShowDialog() == DialogResult.OK)
                {
                    timeline.Time = timeInputDialog.Time;

                    timeline_TimeChanged(this, new TimeChangedEventArgs(false));

                    HidePreviewFrame();
                    SetCutEndTime();
                }
            }
        }

        /// <summary>
        /// Navigates to previous segment start/end.
        /// </summary>
        private void NavigateToPreviousCutLocation()
        {
            if (timeline.SelectedSection == null)
            {
                timeline.SelectedSection = timeline.Sections.Find(item => item.End < timeline.Time);
                timeline.Time = timeline.SelectedSection.End;
                timeline.Invalidate();
            }
            else
            {
                if (timeline.Time == timeline.SelectedSection.Start && timeline.Sections.IndexOf(timeline.SelectedSection) != 0)
                {
                    timeline.SelectedSection = timeline.Sections[timeline.Sections.IndexOf(timeline.SelectedSection) - 1];
                    timeline.Time = timeline.SelectedSection.End;
                    timeline.Invalidate();
                }
                else if (timeline.Time > timeline.SelectedSection.End)
                {
                    timeline.Time = timeline.SelectedSection.End;
                    timeline.Invalidate();
                }
                else
                {
                    timeline.Time = timeline.SelectedSection.Start;
                    timeline.Invalidate();
                }
            }

            timeline_TimeChanged(this, new TimeChangedEventArgs(false));
        }

        /// <summary>
        /// Navigates to next segment start/end.
        /// </summary>
        private void NavigateToNextCutLocation()
        {
            if (timeline.SelectedSection == null)
            {
                timeline.SelectedSection = timeline.Sections.Find(item => item.Start > timeline.Time);
                timeline.Time = timeline.SelectedSection.Start;
                timeline.Invalidate();
            }
            else
            {
                if (timeline.Time == timeline.SelectedSection.End && timeline.Sections.IndexOf(timeline.SelectedSection) != (timeline.Sections.Count - 1))
                {
                    timeline.SelectedSection = timeline.Sections[timeline.Sections.IndexOf(timeline.SelectedSection) + 1];
                    timeline.Time = timeline.SelectedSection.Start;
                    timeline.Invalidate();
                }
                else if (timeline.Time == timeline.SelectedSection.Start)
                {
                    timeline.Time = timeline.SelectedSection.End;
                    timeline.Invalidate();
                }
                else
                {
                    timeline.Time = timeline.SelectedSection.Start;
                    timeline.Invalidate();
                }
            }

            timeline_TimeChanged(this, new TimeChangedEventArgs(false));
        }

        /// <summary>
        /// Navigates to media start.
        /// </summary>
        private void NavigateToMediaStart()
        {
            timeline.Time = 0;

            timeline_TimeChanged(this, new TimeChangedEventArgs(false));

            HidePreviewFrame();
        }

        /// <summary>
        /// Navigates to media end.
        /// </summary>
        private void NavigateToMediaEnd()
        {
            timeline.Time = timeline.Duration;

            timeline_TimeChanged(this, new TimeChangedEventArgs(false));

            HidePreviewFrame();
        }

        /// <summary>
        /// Set timeline time from user input.
        /// </summary>
        private void SetTimelineTimeFromInput()
        {
            using (TimeInputDialog timeInputDialog = new TimeInputDialog())
            {
                timeInputDialog.LabelText = Resources.SetTimelineTimeInput;
                timeInputDialog.Time = timeline.Time;
                timeInputDialog.MinTime = 0d;
                timeInputDialog.MaxTime = timeline.Duration;

                if (timeInputDialog.ShowDialog() == DialogResult.OK)
                {
                    timeline.Time = timeInputDialog.Time;

                    timeline_TimeChanged(this, new TimeChangedEventArgs(false));

                    HidePreviewFrame();
                }
            }
        }

        /// <summary>
        /// Updates the selection label (current time).
        /// </summary>
        private void SetSelectionLabel(bool closing = false)
        {
            if (closing)
            {
                timeline.SelectionLabel = string.Empty;
                return;
            }

            double duration = timeline.Duration;
            if (Project.CurrentProject.CutSegments.Count > 0)
            {
                duration = 0;
                foreach (Section section in  Project.CurrentProject.CutSegments)
                {
                    duration += section.End - section.Start;
                }
            }

            string totalDurationString = duration != 0 ? TimeSpan.FromSeconds(duration).ToString(@"hh\:mm\:ss\:fff") : "--:--:--:---";
            string selectedSectionString = timeline.SelectedSection != null ? $"{Resources.SectionSelected} [{timeline.SelectedSection.GetStartEndString()} ({Resources.SectionDuration}{timeline.SelectedSection.GetDurationString()})]" : Resources.SelectionLabelNoSelection;
            string totalString = $"{Resources.SectionTotal} [{Resources.SectionDuration}{totalDurationString}]";

            timeline.SelectionLabel = $" {selectedSectionString} | {totalString}";
        }

        /// <summary>
        /// Shows the preview frame.
        /// </summary>
        private void ShowPreviewFrame()
        {
            if (!Settings.Default.GenerateFastPreview) return;

            try
            {
                int targetFrame = timeline.Time == 0 ? 0 : (int)Math.Ceiling(timeline.Time * (Project.CurrentProject.PreviewRate));
                if (targetFrame > Project.CurrentProject.PreviewFrames.Count - 1) return;

                framePreview.VideoFrame = Project.CurrentProject.PreviewFrames[targetFrame];

                framePreview.ShowFrame();

                framePreview.Top = panelTimeline.Top - framePreview.Bounds.Height;
                framePreview.Left = (timeline.CaretX + framePreview.Bounds.Width) > timeline.Bounds.Width ? timeline.Bounds.Width - framePreview.Bounds.Width : (int)timeline.CaretX;
                framePreview.Invalidate();
            }
            catch
            {
                // We fucked up somehow, didn't we? Well I don't give a fuck.
            }
        }

        /// <summary>
        /// Hides the preview frame.
        /// </summary>
        private void HidePreviewFrame()
        {
            framePreview.Hide();
        }

        /// <summary>
        /// Toggles playback.
        /// </summary>
        private void TogglePause()
        {
            if (videoView.MediaPlayer.IsPlaying)
            {
                videoView.MediaPlayer.Pause();
            }
            else
            {
                videoView.MediaPlayer.Play();
            }
        }

        /// <summary>
        /// Toggles video view visibility.
        /// </summary>
        private void ToggleVideoViewVisibility()
        {
            if (videoView.Dock == DockStyle.Fill)
            {
                if (videoView.MediaPlayer.IsPlaying)
                {
                    videoView.MediaPlayer.Pause();
                }

                videoView.Dock = DockStyle.None;
                videoView.Top += 9001;
            }
            else
            {
                videoView.Dock = DockStyle.Fill;
                videoView.Top = 0;
            }
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Called when the main form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitProject();
            InitSplash();
            LoadPlugins();
            InitUpdates();
        }

        /// <summary>
        /// Called when the main form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnloadPlugins();
            Settings.Default.Save();
        }

        /// <summary>
        /// Called when the main form is resizing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            timeline.Invalidate();
            videoView.Invalidate();
        }

        /// <summary>
        /// Called whenever playback time changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            timeline.Duration = videoView.MediaPlayer.Length == 0 ? 0d : videoView.MediaPlayer.Length / 1000d;
            timeline.Time = e.Time == 0 ? 0d : e.Time / 1000d;
            timeline.Invalidate();
        }

        /// <summary>
        /// Called whenever mediaplayer has an error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.ErrorMediaPlayer, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Pause timer tick event. Used to pre-cache video duration during file opening.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPause_Tick(object sender, EventArgs e)
        {
            videoView.MediaPlayer.Pause();
            videoView.MediaPlayer.Volume = 100;
            timerPause.Stop();
        }

        /// <summary>
        /// Timeline section renamed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_SectionRenamed(object sender, EventArgs e)
        {
            AutoSaveFile();
        }

        /// <summary>
        /// Timeline key-up event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_KeyUp(object sender, KeyEventArgs e)
        {
            if (Project.CurrentProject == null) return;

            if (e.KeyCode == Keys.Space)
            {
                TogglePause();
            }

            if (e.KeyCode == Keys.P)
            {
                ToggleVideoViewVisibility();
            }
        }

        /// <summary>
        /// Timeline seek start event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_SeekStart(object sender, EventArgs e)
        {
            if (Project.CurrentProject == null) return;
            
            videoView.MediaPlayer.Volume = 0;
        }

        /// <summary>
        /// Timeline seek end event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_SeekEnd(object sender, EventArgs e)
        {
            if (Project.CurrentProject == null) return;

            Console.WriteLine(videoView.MediaPlayer.State);

            if (videoView.MediaPlayer.IsPlaying)
            {
                videoView.MediaPlayer.Pause();
            }

            videoView.MediaPlayer.Volume = 100;

            HidePreviewFrame();
        }

        /// <summary>
        /// Fired when the preview frame should be forcefully closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_ForceClosePreviewFrame(object sender, EventArgs e)
        {
            HidePreviewFrame();
        }

        /// <summary>
        /// Timeline selection changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_SelectionChanged(object sender, EventArgs e)
        {
            SetSelectionLabel();
        }

        /// <summary>
        /// Timeline time changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeline_TimeChanged(object sender, TimeChangedEventArgs e)
        {
            if (Project.CurrentProject == null) return;

            videoView.MediaPlayer.Time = (long)timeline.Time * 1000;

            if (e.CausesDecodingUpdate)
            {
                TimeSpan diff = DateTime.Now - lastPlayTime;
                if (!videoView.MediaPlayer.IsPlaying && diff.TotalMilliseconds > 250)
                {
                    videoView.MediaPlayer.Play();
                    lastPlayTime = DateTime.Now;
                }

                if (videoView.MediaPlayer.IsPlaying)
                {
                    videoView.MediaPlayer.Pause();
                }
            }

            if (sender != this)
            {
                ShowPreviewFrame();
            }
        }

        /// <summary>
        /// Video view file drag enter event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// Video view file drag drop event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
            {
                DialogResult dialogResult = MessageBox.Show(
                    Resources.MultipleFilesMerge,
                    Resources.MultipleFilesMergeTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    );

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string file in files)
                    {
                        if (!FFMPEG.IsMediaSupported(file))
                        {
                            MessageBox.Show(Resources.ErrorFormatNotSupported, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                    MergeFiles(files[0], files.ToList());
                }

                return;
            }

            if (File.Exists(files[0]))
            {
                if (Path.GetExtension(files[0]).ToLower() == ".llc")
                {
                    OpenProject(files[0]);
                }
                else
                {
                    OpenVideoFile(files[0], true);
                }
            }
        }

        /// <summary>
        /// Open toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".llc")
                    {
                        OpenProject(openFileDialog.FileName);
                    }
                    else
                    {
                        OpenVideoFile(openFileDialog.FileName, true);
                    }
                }
            }
        }

        /// <summary>
        /// Open network toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenNetworkDialog openNetworkDialog = new OpenNetworkDialog())
            {
                if (openNetworkDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenVideoFile(openNetworkDialog.URL);
                }
            }
        }

        /// <summary>
        /// Close toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        /// <summary>
        /// Save toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Save As toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }


        /// <summary>
        /// Export timestamps as CSV toolstrip event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void asCommaseparatedValuescsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.CurrentProject.ExportTimestampsToCsv();
        }

        /// <summary>
        /// Export timestamps as YouTube chapters toolstrip event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void asYouTubeChapterstoClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.CurrentProject.ExportTimestampsToYoutubeChapters();
        }

        /// <summary>
        /// Export media toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportMedia();
        }

        /// <summary>
        /// Settings toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSettings();
                }
            }
        }

        /// <summary>
        /// Quit toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Insert cut toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertCut();
        }

        /// <summary>
        /// Remove cut toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCut();
        }

        /// <summary>
        /// Set cut start time toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setCutStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCutStartTime();
        }

        /// <summary>
        /// Set cut end time toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setCutEndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCutEndTime();
        }

        /// <summary>
        /// Previous cut start end toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousCutStartEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NavigateToPreviousCutLocation();
        }

        /// <summary>
        /// Next cut start end toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextCutStartEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NavigateToNextCutLocation();
        }

        /// <summary>
        /// Go to video start toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToVideoStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NavigateToMediaStart();
        }

        /// <summary>
        /// Go to video end toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToVideoEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NavigateToMediaEnd();
        }

        /// <summary>
        /// Enter cut start time toolstip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterCutStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCutStartTimeFromInput();
        }

        /// <summary>
        /// Enter cut end time toolstip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterCutEndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCutEndTimeFromInput();
        }

        /// <summary>
        /// Navigate to specific timeline position toolstip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navigateToSpecificTimelinePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimelineTimeFromInput();
        }

        /// <summary>
        /// Merge files toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mergeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileNames.Length == 0) return;

                    MergeFiles(openFileDialog.FileNames[0], openFileDialog.FileNames.ToList());
                }
            }
        }

        /// <summary>
        /// Remux to MP4 toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mPEG4mp4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemuxFile("mp4");
        }

        /// <summary>
        /// Remux to MKV toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matroskamkvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemuxFile("mkv");
        }

        /// <summary>
        /// Capture frame toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void captureFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureFrame();
        }

        /// <summary>
        /// Open the plugin manager.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PluginManagerForm pluginManagerForm = new PluginManagerForm())
            {
                pluginManagerForm.ShowDialog();
            }
        }

        /// <summary>
        /// Check for updates toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater.CheckForUpdates(false);
        }

        /// <summary>
        /// About toolstrip item event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutSharpCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        /// <summary>
        /// Licenses toolstrip event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void licensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LicensesForm licensesForm = new LicensesForm())
            {
                licensesForm.ShowDialog();
            }
        }

        /// <summary>
        /// Submit a bug report toolstrip event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitABugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:contact@conflagrate.co");
        }

        /// <summary>
        /// Update timer event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Stop();
            Updater.CheckForUpdates(false, true);
        }

        /// <summary>
        /// Video view paint event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoView_Paint(object sender, PaintEventArgs e)
        {
            if (Project.CurrentProject == null)
            {
                e.Graphics.Clear(Color.Black);

                int origWidth = imageSplash.Width;
                int origHeight = imageSplash.Height;

                double ratioX = (double)((videoView.Width / 2) + (origWidth / 2)) / origWidth;
                double ratioY = (double)((videoView.Height / 2) + (origHeight / 2)) / origHeight;
                double ratio = ratioX < ratioY ? ratioX : ratioY;
                ratio = ratio * 0.7d;

                int newHeight = Convert.ToInt32(imageSplash.Height * ratio);
                int newWidth = Convert.ToInt32(imageSplash.Width * ratio);

                e.Graphics.DrawImage(imageSplash, (videoView.Width / 2) - (newWidth / 2), (videoView.Height / 2) - (newHeight / 2), newWidth, newHeight);
            }
        }

        /// <summary>
        /// Courtesy message timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCourtesyUpdate_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.TimeUntilCourtesy <= 0 && Settings.Default.CourtesyEnabled)
            {
                Settings.Default.CourtesyEnabled = false;
                Settings.Default.Save();
                
                DialogResult dialogResult = MessageBox.Show(
                    Resources.Courtesy, 
                    Resources.CourtesyTitle, 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("https://conflagrate.co");
                }
                else
                {
                    MessageBox.Show(
                        Resources.CourtesyDisabled,
                        Resources.CourtesyTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            else
            {
                Settings.Default.TimeUntilCourtesy -= 10;
            }
        }

        /// <summary>
        /// Merge completed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CurrentProject_MergeCompleted(object sender, Project.MergeCompletedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                Resources.MergeComplete,
                Resources.MergeCompleteTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                CloseFile();
                OpenVideoFile(e.OutputFileName);
            }
        }

        /// <summary>
        /// Preview frame loading progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentProject_LoadPreviewFramesProgress(object sender, Project.LoadPreviewFramesProgressEventArgs e)
        {
            timeline.PreviewProgress = e.Progress;
            timeline.PreviewGeneratingNewFrames = e.IsGeneratingNewFrames;
        }

        /// <summary>
        /// Load preview frames completed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentProject_LoadPreviewFramesCompleted(object sender, Project.LoadPreviewFramesCompletedEventArgs e)
        {
            if (e.Success)
            {
                timeline.PreviewLoaded = true;
            }
        }

        #endregion
    }
}
