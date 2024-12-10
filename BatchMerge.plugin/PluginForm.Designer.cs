namespace BatchMerge.plugin
{
    partial class PluginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonMergeSelected = new System.Windows.Forms.Button();
            this.buttonMergeAll = new System.Windows.Forms.Button();
            this.buttonRemoveJob = new System.Windows.Forms.Button();
            this.buttonAddJob = new System.Windows.Forms.Button();
            this.panelList = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.checkBoxSaveDeleteList = new System.Windows.Forms.CheckBox();
            this.buttonSetDeleteList = new System.Windows.Forms.Button();
            this.panelHeading = new System.Windows.Forms.Panel();
            this.labelHeading = new System.Windows.Forms.Label();
            this.panelOutputDir = new System.Windows.Forms.Panel();
            this.labelOutputDir = new System.Windows.Forms.Label();
            this.linkLabelOutputDir = new System.Windows.Forms.LinkLabel();
            this.panelControls.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelHeading.SuspendLayout();
            this.panelOutputDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.panelOptions);
            this.panelControls.Controls.Add(this.panelActions);
            resources.ApplyResources(this.panelControls, "panelControls");
            this.panelControls.Name = "panelControls";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.panelProgress);
            this.panelActions.Controls.Add(this.buttonMergeSelected);
            this.panelActions.Controls.Add(this.buttonMergeAll);
            this.panelActions.Controls.Add(this.buttonRemoveJob);
            this.panelActions.Controls.Add(this.buttonAddJob);
            resources.ApplyResources(this.panelActions, "panelActions");
            this.panelActions.Name = "panelActions";
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.progressBar);
            resources.ApplyResources(this.panelProgress, "panelProgress");
            this.panelProgress.Name = "panelProgress";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // buttonMergeSelected
            // 
            resources.ApplyResources(this.buttonMergeSelected, "buttonMergeSelected");
            this.buttonMergeSelected.Name = "buttonMergeSelected";
            this.buttonMergeSelected.UseVisualStyleBackColor = true;
            this.buttonMergeSelected.Click += new System.EventHandler(this.buttonMergeSelected_Click);
            // 
            // buttonMergeAll
            // 
            resources.ApplyResources(this.buttonMergeAll, "buttonMergeAll");
            this.buttonMergeAll.Name = "buttonMergeAll";
            this.buttonMergeAll.UseVisualStyleBackColor = true;
            this.buttonMergeAll.Click += new System.EventHandler(this.buttonMergeAll_Click);
            // 
            // buttonRemoveJob
            // 
            resources.ApplyResources(this.buttonRemoveJob, "buttonRemoveJob");
            this.buttonRemoveJob.Name = "buttonRemoveJob";
            this.buttonRemoveJob.UseVisualStyleBackColor = true;
            this.buttonRemoveJob.Click += new System.EventHandler(this.buttonRemoveJob_Click);
            // 
            // buttonAddJob
            // 
            resources.ApplyResources(this.buttonAddJob, "buttonAddJob");
            this.buttonAddJob.Name = "buttonAddJob";
            this.buttonAddJob.UseVisualStyleBackColor = true;
            this.buttonAddJob.Click += new System.EventHandler(this.buttonAddJob_Click);
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.listBox);
            resources.ApplyResources(this.panelList, "panelList");
            this.panelList.Name = "panelList";
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            resources.ApplyResources(this.listBox, "listBox");
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.FormattingEnabled = true;
            this.listBox.Name = "listBox";
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.checkBoxSaveDeleteList);
            this.panelOptions.Controls.Add(this.buttonSetDeleteList);
            resources.ApplyResources(this.panelOptions, "panelOptions");
            this.panelOptions.Name = "panelOptions";
            // 
            // checkBoxSaveDeleteList
            // 
            resources.ApplyResources(this.checkBoxSaveDeleteList, "checkBoxSaveDeleteList");
            this.checkBoxSaveDeleteList.Name = "checkBoxSaveDeleteList";
            this.checkBoxSaveDeleteList.UseVisualStyleBackColor = true;
            this.checkBoxSaveDeleteList.CheckedChanged += new System.EventHandler(this.checkBoxSaveDeleteList_CheckedChanged);
            // 
            // buttonSetDeleteList
            // 
            resources.ApplyResources(this.buttonSetDeleteList, "buttonSetDeleteList");
            this.buttonSetDeleteList.Name = "buttonSetDeleteList";
            this.buttonSetDeleteList.UseVisualStyleBackColor = true;
            this.buttonSetDeleteList.Click += new System.EventHandler(this.buttonSetDeleteList_Click);
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.panelOutputDir);
            this.panelHeading.Controls.Add(this.labelHeading);
            resources.ApplyResources(this.panelHeading, "panelHeading");
            this.panelHeading.Name = "panelHeading";
            // 
            // labelHeading
            // 
            resources.ApplyResources(this.labelHeading, "labelHeading");
            this.labelHeading.Name = "labelHeading";
            // 
            // panelOutputDir
            // 
            this.panelOutputDir.Controls.Add(this.labelOutputDir);
            this.panelOutputDir.Controls.Add(this.linkLabelOutputDir);
            resources.ApplyResources(this.panelOutputDir, "panelOutputDir");
            this.panelOutputDir.Name = "panelOutputDir";
            // 
            // labelOutputDir
            // 
            this.labelOutputDir.AutoEllipsis = true;
            resources.ApplyResources(this.labelOutputDir, "labelOutputDir");
            this.labelOutputDir.Name = "labelOutputDir";
            // 
            // linkLabelOutputDir
            // 
            resources.ApplyResources(this.linkLabelOutputDir, "linkLabelOutputDir");
            this.linkLabelOutputDir.Name = "linkLabelOutputDir";
            this.linkLabelOutputDir.TabStop = true;
            this.linkLabelOutputDir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.linkLabelOutputDir_MouseClick);
            // 
            // PluginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelHeading);
            this.Controls.Add(this.panelControls);
            this.DoubleBuffered = true;
            this.Name = "PluginForm";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelHeading.ResumeLayout(false);
            this.panelOutputDir.ResumeLayout(false);
            this.panelOutputDir.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button buttonMergeSelected;
        private System.Windows.Forms.Button buttonMergeAll;
        private System.Windows.Forms.Button buttonRemoveJob;
        private System.Windows.Forms.Button buttonAddJob;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.CheckBox checkBoxSaveDeleteList;
        private System.Windows.Forms.Button buttonSetDeleteList;
        private System.Windows.Forms.Panel panelHeading;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Panel panelOutputDir;
        private System.Windows.Forms.Label labelOutputDir;
        private System.Windows.Forms.LinkLabel linkLabelOutputDir;
    }
}