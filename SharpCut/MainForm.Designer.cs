
namespace SharpCut
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTimestampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asCommaseparatedValuescsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asYouTubeChapterstoClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.setCutStartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCutEndTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.previousCutStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextCutStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.goToVideoStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToVideoEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.enterCutStartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterCutEndTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.navigateToSpecificTimelinePositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remuxToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mPEG4mp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matroskamkvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.captureFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsMediaUtilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsCuttingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.pluginManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSharpCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.submitABugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelViewport = new System.Windows.Forms.Panel();
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.timerPause = new System.Windows.Forms.Timer(this.components);
            this.panelTimeline = new System.Windows.Forms.Panel();
            this.timeline = new SharpCut.Controls.Timeline();
            this.panelTools = new System.Windows.Forms.Panel();
            this.framePreview = new SharpCut.Controls.FramePreview();
            this.panelTimeControls = new System.Windows.Forms.Panel();
            this.buttonCaptureFrame = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonSetCutEndTime = new System.Windows.Forms.Button();
            this.buttonSetCutStartTime = new System.Windows.Forms.Button();
            this.buttonRemoveCut = new System.Windows.Forms.Button();
            this.buttonInsertCut = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.timerCourtesyUpdate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.panelViewport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            this.panelTimeline.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openNetworkToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportMediaToolStripMenuItem,
            this.exportTimestampsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem6,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openNetworkToolStripMenuItem
            // 
            this.openNetworkToolStripMenuItem.Name = "openNetworkToolStripMenuItem";
            resources.ApplyResources(this.openNetworkToolStripMenuItem, "openNetworkToolStripMenuItem");
            this.openNetworkToolStripMenuItem.Click += new System.EventHandler(this.openNetworkToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // exportMediaToolStripMenuItem
            // 
            resources.ApplyResources(this.exportMediaToolStripMenuItem, "exportMediaToolStripMenuItem");
            this.exportMediaToolStripMenuItem.Name = "exportMediaToolStripMenuItem";
            this.exportMediaToolStripMenuItem.Click += new System.EventHandler(this.exportMediaToolStripMenuItem_Click);
            // 
            // exportTimestampsToolStripMenuItem
            // 
            this.exportTimestampsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asCommaseparatedValuescsvToolStripMenuItem,
            this.asYouTubeChapterstoClipboardToolStripMenuItem});
            resources.ApplyResources(this.exportTimestampsToolStripMenuItem, "exportTimestampsToolStripMenuItem");
            this.exportTimestampsToolStripMenuItem.Name = "exportTimestampsToolStripMenuItem";
            // 
            // asCommaseparatedValuescsvToolStripMenuItem
            // 
            this.asCommaseparatedValuescsvToolStripMenuItem.Name = "asCommaseparatedValuescsvToolStripMenuItem";
            resources.ApplyResources(this.asCommaseparatedValuescsvToolStripMenuItem, "asCommaseparatedValuescsvToolStripMenuItem");
            this.asCommaseparatedValuescsvToolStripMenuItem.Click += new System.EventHandler(this.asCommaseparatedValuescsvToolStripMenuItem_Click);
            // 
            // asYouTubeChapterstoClipboardToolStripMenuItem
            // 
            this.asYouTubeChapterstoClipboardToolStripMenuItem.Name = "asYouTubeChapterstoClipboardToolStripMenuItem";
            resources.ApplyResources(this.asYouTubeChapterstoClipboardToolStripMenuItem, "asYouTubeChapterstoClipboardToolStripMenuItem");
            this.asYouTubeChapterstoClipboardToolStripMenuItem.Click += new System.EventHandler(this.asYouTubeChapterstoClipboardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            resources.ApplyResources(this.quitToolStripMenuItem, "quitToolStripMenuItem");
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertCutToolStripMenuItem,
            this.removeCutToolStripMenuItem,
            this.toolStripMenuItem4,
            this.setCutStartTimeToolStripMenuItem,
            this.setCutEndTimeToolStripMenuItem,
            this.toolStripMenuItem7,
            this.previousCutStartToolStripMenuItem,
            this.nextCutStartToolStripMenuItem,
            this.toolStripMenuItem8,
            this.goToVideoStartToolStripMenuItem,
            this.goToVideoEndToolStripMenuItem,
            this.toolStripMenuItem11,
            this.enterCutStartTimeToolStripMenuItem,
            this.enterCutEndTimeToolStripMenuItem,
            this.toolStripMenuItem12,
            this.navigateToSpecificTimelinePositionToolStripMenuItem});
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            // 
            // insertCutToolStripMenuItem
            // 
            this.insertCutToolStripMenuItem.Name = "insertCutToolStripMenuItem";
            resources.ApplyResources(this.insertCutToolStripMenuItem, "insertCutToolStripMenuItem");
            this.insertCutToolStripMenuItem.Click += new System.EventHandler(this.insertCutToolStripMenuItem_Click);
            // 
            // removeCutToolStripMenuItem
            // 
            this.removeCutToolStripMenuItem.Name = "removeCutToolStripMenuItem";
            resources.ApplyResources(this.removeCutToolStripMenuItem, "removeCutToolStripMenuItem");
            this.removeCutToolStripMenuItem.Click += new System.EventHandler(this.removeCutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // setCutStartTimeToolStripMenuItem
            // 
            this.setCutStartTimeToolStripMenuItem.Name = "setCutStartTimeToolStripMenuItem";
            resources.ApplyResources(this.setCutStartTimeToolStripMenuItem, "setCutStartTimeToolStripMenuItem");
            this.setCutStartTimeToolStripMenuItem.Click += new System.EventHandler(this.setCutStartTimeToolStripMenuItem_Click);
            // 
            // setCutEndTimeToolStripMenuItem
            // 
            this.setCutEndTimeToolStripMenuItem.Name = "setCutEndTimeToolStripMenuItem";
            resources.ApplyResources(this.setCutEndTimeToolStripMenuItem, "setCutEndTimeToolStripMenuItem");
            this.setCutEndTimeToolStripMenuItem.Click += new System.EventHandler(this.setCutEndTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // previousCutStartToolStripMenuItem
            // 
            this.previousCutStartToolStripMenuItem.Name = "previousCutStartToolStripMenuItem";
            resources.ApplyResources(this.previousCutStartToolStripMenuItem, "previousCutStartToolStripMenuItem");
            this.previousCutStartToolStripMenuItem.Click += new System.EventHandler(this.previousCutStartEndToolStripMenuItem_Click);
            // 
            // nextCutStartToolStripMenuItem
            // 
            this.nextCutStartToolStripMenuItem.Name = "nextCutStartToolStripMenuItem";
            resources.ApplyResources(this.nextCutStartToolStripMenuItem, "nextCutStartToolStripMenuItem");
            this.nextCutStartToolStripMenuItem.Click += new System.EventHandler(this.nextCutStartEndToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            // 
            // goToVideoStartToolStripMenuItem
            // 
            this.goToVideoStartToolStripMenuItem.Name = "goToVideoStartToolStripMenuItem";
            resources.ApplyResources(this.goToVideoStartToolStripMenuItem, "goToVideoStartToolStripMenuItem");
            this.goToVideoStartToolStripMenuItem.Click += new System.EventHandler(this.goToVideoStartToolStripMenuItem_Click);
            // 
            // goToVideoEndToolStripMenuItem
            // 
            this.goToVideoEndToolStripMenuItem.Name = "goToVideoEndToolStripMenuItem";
            resources.ApplyResources(this.goToVideoEndToolStripMenuItem, "goToVideoEndToolStripMenuItem");
            this.goToVideoEndToolStripMenuItem.Click += new System.EventHandler(this.goToVideoEndToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            // 
            // enterCutStartTimeToolStripMenuItem
            // 
            this.enterCutStartTimeToolStripMenuItem.Name = "enterCutStartTimeToolStripMenuItem";
            resources.ApplyResources(this.enterCutStartTimeToolStripMenuItem, "enterCutStartTimeToolStripMenuItem");
            this.enterCutStartTimeToolStripMenuItem.Click += new System.EventHandler(this.enterCutStartTimeToolStripMenuItem_Click);
            // 
            // enterCutEndTimeToolStripMenuItem
            // 
            this.enterCutEndTimeToolStripMenuItem.Name = "enterCutEndTimeToolStripMenuItem";
            resources.ApplyResources(this.enterCutEndTimeToolStripMenuItem, "enterCutEndTimeToolStripMenuItem");
            this.enterCutEndTimeToolStripMenuItem.Click += new System.EventHandler(this.enterCutEndTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            // 
            // navigateToSpecificTimelinePositionToolStripMenuItem
            // 
            this.navigateToSpecificTimelinePositionToolStripMenuItem.Name = "navigateToSpecificTimelinePositionToolStripMenuItem";
            resources.ApplyResources(this.navigateToSpecificTimelinePositionToolStripMenuItem, "navigateToSpecificTimelinePositionToolStripMenuItem");
            this.navigateToSpecificTimelinePositionToolStripMenuItem.Click += new System.EventHandler(this.navigateToSpecificTimelinePositionToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeFilesToolStripMenuItem,
            this.remuxToToolStripMenuItem,
            this.toolStripMenuItem9,
            this.captureFrameToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // mergeFilesToolStripMenuItem
            // 
            this.mergeFilesToolStripMenuItem.Name = "mergeFilesToolStripMenuItem";
            resources.ApplyResources(this.mergeFilesToolStripMenuItem, "mergeFilesToolStripMenuItem");
            this.mergeFilesToolStripMenuItem.Click += new System.EventHandler(this.mergeFilesToolStripMenuItem_Click);
            // 
            // remuxToToolStripMenuItem
            // 
            this.remuxToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPEG4mp4ToolStripMenuItem,
            this.matroskamkvToolStripMenuItem});
            resources.ApplyResources(this.remuxToToolStripMenuItem, "remuxToToolStripMenuItem");
            this.remuxToToolStripMenuItem.Name = "remuxToToolStripMenuItem";
            // 
            // mPEG4mp4ToolStripMenuItem
            // 
            this.mPEG4mp4ToolStripMenuItem.Name = "mPEG4mp4ToolStripMenuItem";
            resources.ApplyResources(this.mPEG4mp4ToolStripMenuItem, "mPEG4mp4ToolStripMenuItem");
            this.mPEG4mp4ToolStripMenuItem.Click += new System.EventHandler(this.mPEG4mp4ToolStripMenuItem_Click);
            // 
            // matroskamkvToolStripMenuItem
            // 
            this.matroskamkvToolStripMenuItem.Name = "matroskamkvToolStripMenuItem";
            resources.ApplyResources(this.matroskamkvToolStripMenuItem, "matroskamkvToolStripMenuItem");
            this.matroskamkvToolStripMenuItem.Click += new System.EventHandler(this.matroskamkvToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // captureFrameToolStripMenuItem
            // 
            this.captureFrameToolStripMenuItem.Name = "captureFrameToolStripMenuItem";
            resources.ApplyResources(this.captureFrameToolStripMenuItem, "captureFrameToolStripMenuItem");
            this.captureFrameToolStripMenuItem.Click += new System.EventHandler(this.captureFrameToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsGeneralToolStripMenuItem,
            this.pluginsMediaUtilitiesToolStripMenuItem,
            this.pluginsAnalysisToolStripMenuItem,
            this.pluginsCuttingToolStripMenuItem,
            this.toolStripMenuItem13,
            this.pluginManagerToolStripMenuItem});
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            resources.ApplyResources(this.pluginsToolStripMenuItem, "pluginsToolStripMenuItem");
            // 
            // pluginsGeneralToolStripMenuItem
            // 
            this.pluginsGeneralToolStripMenuItem.Name = "pluginsGeneralToolStripMenuItem";
            resources.ApplyResources(this.pluginsGeneralToolStripMenuItem, "pluginsGeneralToolStripMenuItem");
            // 
            // pluginsMediaUtilitiesToolStripMenuItem
            // 
            this.pluginsMediaUtilitiesToolStripMenuItem.Name = "pluginsMediaUtilitiesToolStripMenuItem";
            resources.ApplyResources(this.pluginsMediaUtilitiesToolStripMenuItem, "pluginsMediaUtilitiesToolStripMenuItem");
            // 
            // pluginsAnalysisToolStripMenuItem
            // 
            this.pluginsAnalysisToolStripMenuItem.Name = "pluginsAnalysisToolStripMenuItem";
            resources.ApplyResources(this.pluginsAnalysisToolStripMenuItem, "pluginsAnalysisToolStripMenuItem");
            // 
            // pluginsCuttingToolStripMenuItem
            // 
            this.pluginsCuttingToolStripMenuItem.Name = "pluginsCuttingToolStripMenuItem";
            resources.ApplyResources(this.pluginsCuttingToolStripMenuItem, "pluginsCuttingToolStripMenuItem");
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            // 
            // pluginManagerToolStripMenuItem
            // 
            this.pluginManagerToolStripMenuItem.Name = "pluginManagerToolStripMenuItem";
            resources.ApplyResources(this.pluginManagerToolStripMenuItem, "pluginManagerToolStripMenuItem");
            this.pluginManagerToolStripMenuItem.Click += new System.EventHandler(this.pluginManagerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSharpCutToolStripMenuItem,
            this.licensesToolStripMenuItem,
            this.toolStripMenuItem10,
            this.submitABugReportToolStripMenuItem,
            this.toolStripMenuItem5,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutSharpCutToolStripMenuItem
            // 
            this.aboutSharpCutToolStripMenuItem.Name = "aboutSharpCutToolStripMenuItem";
            resources.ApplyResources(this.aboutSharpCutToolStripMenuItem, "aboutSharpCutToolStripMenuItem");
            this.aboutSharpCutToolStripMenuItem.Click += new System.EventHandler(this.aboutSharpCutToolStripMenuItem_Click);
            // 
            // licensesToolStripMenuItem
            // 
            this.licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            resources.ApplyResources(this.licensesToolStripMenuItem, "licensesToolStripMenuItem");
            this.licensesToolStripMenuItem.Click += new System.EventHandler(this.licensesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            // 
            // submitABugReportToolStripMenuItem
            // 
            this.submitABugReportToolStripMenuItem.Name = "submitABugReportToolStripMenuItem";
            resources.ApplyResources(this.submitABugReportToolStripMenuItem, "submitABugReportToolStripMenuItem");
            this.submitABugReportToolStripMenuItem.Click += new System.EventHandler(this.submitABugReportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // panelViewport
            // 
            this.panelViewport.Controls.Add(this.videoView);
            resources.ApplyResources(this.panelViewport, "panelViewport");
            this.panelViewport.Name = "panelViewport";
            // 
            // videoView
            // 
            this.videoView.AllowDrop = true;
            this.videoView.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.videoView, "videoView");
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.DragDrop += new System.Windows.Forms.DragEventHandler(this.videoView_DragDrop);
            this.videoView.DragEnter += new System.Windows.Forms.DragEventHandler(this.videoView_DragEnter);
            this.videoView.Paint += new System.Windows.Forms.PaintEventHandler(this.videoView_Paint);
            // 
            // timerPause
            // 
            this.timerPause.Interval = 1000;
            this.timerPause.Tick += new System.EventHandler(this.timerPause_Tick);
            // 
            // panelTimeline
            // 
            this.panelTimeline.Controls.Add(this.timeline);
            resources.ApplyResources(this.panelTimeline, "panelTimeline");
            this.panelTimeline.Name = "panelTimeline";
            // 
            // timeline
            // 
            this.timeline.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.timeline, "timeline");
            this.timeline.Duration = 0D;
            this.timeline.Name = "timeline";
            this.timeline.PreviewGeneratingNewFrames = false;
            this.timeline.PreviewLoaded = false;
            this.timeline.PreviewProgress = 0F;
            this.timeline.ScrollSpeed = 1F;
            this.timeline.SelectedSection = null;
            this.timeline.SelectionLabel = "";
            this.timeline.Time = 0D;
            this.timeline.TimeChanged += new System.EventHandler<SharpCut.Controls.Timeline.TimeChangedEventArgs>(this.timeline_TimeChanged);
            this.timeline.SeekStart += new System.EventHandler(this.timeline_SeekStart);
            this.timeline.SeekEnd += new System.EventHandler(this.timeline_SeekEnd);
            this.timeline.SectionRenamed += new System.EventHandler(this.timeline_SectionRenamed);
            this.timeline.ForceClosePreviewFrame += new System.EventHandler(this.timeline_ForceClosePreviewFrame);
            this.timeline.SelectionChanged += new System.EventHandler(this.timeline_SelectionChanged);
            this.timeline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.timeline_KeyUp);
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.PowderBlue;
            this.panelTools.Controls.Add(this.framePreview);
            this.panelTools.Controls.Add(this.panelTimeControls);
            this.panelTools.Controls.Add(this.buttonCaptureFrame);
            this.panelTools.Controls.Add(this.buttonExport);
            this.panelTools.Controls.Add(this.buttonSetCutEndTime);
            this.panelTools.Controls.Add(this.buttonSetCutStartTime);
            this.panelTools.Controls.Add(this.buttonRemoveCut);
            this.panelTools.Controls.Add(this.buttonInsertCut);
            resources.ApplyResources(this.panelTools, "panelTools");
            this.panelTools.Name = "panelTools";
            // 
            // framePreview
            // 
            this.framePreview.FrameHeight = 90;
            resources.ApplyResources(this.framePreview, "framePreview");
            this.framePreview.Name = "framePreview";
            this.framePreview.VideoFrame = null;
            // 
            // panelTimeControls
            // 
            resources.ApplyResources(this.panelTimeControls, "panelTimeControls");
            this.panelTimeControls.Name = "panelTimeControls";
            // 
            // buttonCaptureFrame
            // 
            resources.ApplyResources(this.buttonCaptureFrame, "buttonCaptureFrame");
            this.buttonCaptureFrame.Name = "buttonCaptureFrame";
            this.buttonCaptureFrame.UseVisualStyleBackColor = true;
            this.buttonCaptureFrame.Click += new System.EventHandler(this.captureFrameToolStripMenuItem_Click);
            // 
            // buttonExport
            // 
            resources.ApplyResources(this.buttonExport, "buttonExport");
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.exportMediaToolStripMenuItem_Click);
            // 
            // buttonSetCutEndTime
            // 
            resources.ApplyResources(this.buttonSetCutEndTime, "buttonSetCutEndTime");
            this.buttonSetCutEndTime.Name = "buttonSetCutEndTime";
            this.buttonSetCutEndTime.UseVisualStyleBackColor = true;
            this.buttonSetCutEndTime.Click += new System.EventHandler(this.setCutEndTimeToolStripMenuItem_Click);
            // 
            // buttonSetCutStartTime
            // 
            resources.ApplyResources(this.buttonSetCutStartTime, "buttonSetCutStartTime");
            this.buttonSetCutStartTime.Name = "buttonSetCutStartTime";
            this.buttonSetCutStartTime.UseVisualStyleBackColor = true;
            this.buttonSetCutStartTime.Click += new System.EventHandler(this.setCutStartTimeToolStripMenuItem_Click);
            // 
            // buttonRemoveCut
            // 
            resources.ApplyResources(this.buttonRemoveCut, "buttonRemoveCut");
            this.buttonRemoveCut.Name = "buttonRemoveCut";
            this.buttonRemoveCut.UseVisualStyleBackColor = true;
            this.buttonRemoveCut.Click += new System.EventHandler(this.removeCutToolStripMenuItem_Click);
            // 
            // buttonInsertCut
            // 
            resources.ApplyResources(this.buttonInsertCut, "buttonInsertCut");
            this.buttonInsertCut.Name = "buttonInsertCut";
            this.buttonInsertCut.UseVisualStyleBackColor = true;
            this.buttonInsertCut.Click += new System.EventHandler(this.insertCutToolStripMenuItem_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 5000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // timerCourtesyUpdate
            // 
            this.timerCourtesyUpdate.Enabled = true;
            this.timerCourtesyUpdate.Interval = 10000;
            this.timerCourtesyUpdate.Tick += new System.EventHandler(this.timerCourtesyUpdate_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelViewport);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panelTimeline);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelViewport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            this.panelTimeline.ResumeLayout(false);
            this.panelTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem setCutStartTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCutEndTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remuxToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mPEG4mp4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matroskamkvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSharpCutToolStripMenuItem;
        private System.Windows.Forms.Panel panelViewport;
        private System.Windows.Forms.Timer timerPause;
        private LibVLCSharp.WinForms.VideoView videoView;
        private System.Windows.Forms.Panel panelTimeline;
        private System.Windows.Forms.Panel panelTools;
        private Controls.Timeline timeline;
        private System.Windows.Forms.Button buttonInsertCut;
        private System.Windows.Forms.Button buttonRemoveCut;
        private System.Windows.Forms.Button buttonSetCutStartTime;
        private System.Windows.Forms.Button buttonSetCutEndTime;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem previousCutStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextCutStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem goToVideoStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToVideoEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNetworkToolStripMenuItem;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer timerCourtesyUpdate;
        private Controls.FramePreview framePreview;
        private System.Windows.Forms.Button buttonCaptureFrame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem captureFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTimestampsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asCommaseparatedValuescsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asYouTubeChapterstoClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem submitABugReportToolStripMenuItem;
        private System.Windows.Forms.Panel panelTimeControls;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem enterCutStartTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterCutEndTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem navigateToSpecificTimelinePositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsMediaUtilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsCuttingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem pluginManagerToolStripMenuItem;
    }
}

