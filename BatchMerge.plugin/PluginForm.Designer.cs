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
            this.panelOptions = new System.Windows.Forms.Panel();
            this.buttonSetDeleteList = new System.Windows.Forms.Button();
            this.panelActions = new System.Windows.Forms.Panel();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonMergeSelected = new System.Windows.Forms.Button();
            this.buttonMergeAll = new System.Windows.Forms.Button();
            this.buttonRemoveJob = new System.Windows.Forms.Button();
            this.buttonAddJob = new System.Windows.Forms.Button();
            this.labelHeading = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panelCheckBox = new System.Windows.Forms.Panel();
            this.checkBoxSaveDeleteList = new System.Windows.Forms.CheckBox();
            this.panelControls.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelCheckBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.panelOptions);
            this.panelControls.Controls.Add(this.panelActions);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(4, 495);
            this.panelControls.Name = "panelControls";
            this.panelControls.Padding = new System.Windows.Forms.Padding(8, 0, 8, 4);
            this.panelControls.Size = new System.Drawing.Size(976, 62);
            this.panelControls.TabIndex = 3;
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.panelCheckBox);
            this.panelOptions.Controls.Add(this.buttonSetDeleteList);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptions.Location = new System.Drawing.Point(8, 0);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panelOptions.Size = new System.Drawing.Size(960, 30);
            this.panelOptions.TabIndex = 5;
            // 
            // buttonSetDeleteList
            // 
            this.buttonSetDeleteList.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSetDeleteList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSetDeleteList.Location = new System.Drawing.Point(0, 3);
            this.buttonSetDeleteList.Name = "buttonSetDeleteList";
            this.buttonSetDeleteList.Size = new System.Drawing.Size(157, 24);
            this.buttonSetDeleteList.TabIndex = 2;
            this.buttonSetDeleteList.Text = "Set delete list output path";
            this.buttonSetDeleteList.UseVisualStyleBackColor = true;
            this.buttonSetDeleteList.Click += new System.EventHandler(this.buttonSetDeleteList_Click);
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.panelProgress);
            this.panelActions.Controls.Add(this.buttonMergeSelected);
            this.panelActions.Controls.Add(this.buttonMergeAll);
            this.panelActions.Controls.Add(this.buttonRemoveJob);
            this.panelActions.Controls.Add(this.buttonAddJob);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(8, 30);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(960, 28);
            this.panelActions.TabIndex = 6;
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.progressBar);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgress.Location = new System.Drawing.Point(170, 0);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Padding = new System.Windows.Forms.Padding(3);
            this.panelProgress.Size = new System.Drawing.Size(604, 28);
            this.panelProgress.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(598, 22);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // buttonMergeSelected
            // 
            this.buttonMergeSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMergeSelected.Enabled = false;
            this.buttonMergeSelected.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonMergeSelected.Location = new System.Drawing.Point(774, 0);
            this.buttonMergeSelected.Name = "buttonMergeSelected";
            this.buttonMergeSelected.Size = new System.Drawing.Size(96, 28);
            this.buttonMergeSelected.TabIndex = 9;
            this.buttonMergeSelected.Text = "Merge selected";
            this.buttonMergeSelected.UseVisualStyleBackColor = true;
            this.buttonMergeSelected.Click += new System.EventHandler(this.buttonMergeSelected_Click);
            // 
            // buttonMergeAll
            // 
            this.buttonMergeAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMergeAll.Enabled = false;
            this.buttonMergeAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonMergeAll.Location = new System.Drawing.Point(870, 0);
            this.buttonMergeAll.Name = "buttonMergeAll";
            this.buttonMergeAll.Size = new System.Drawing.Size(90, 28);
            this.buttonMergeAll.TabIndex = 8;
            this.buttonMergeAll.Text = "Merge all";
            this.buttonMergeAll.UseVisualStyleBackColor = true;
            this.buttonMergeAll.Click += new System.EventHandler(this.buttonMergeAll_Click);
            // 
            // buttonRemoveJob
            // 
            this.buttonRemoveJob.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRemoveJob.Enabled = false;
            this.buttonRemoveJob.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRemoveJob.Location = new System.Drawing.Point(90, 0);
            this.buttonRemoveJob.Name = "buttonRemoveJob";
            this.buttonRemoveJob.Size = new System.Drawing.Size(80, 28);
            this.buttonRemoveJob.TabIndex = 7;
            this.buttonRemoveJob.Text = "Remove job";
            this.buttonRemoveJob.UseVisualStyleBackColor = true;
            this.buttonRemoveJob.Click += new System.EventHandler(this.buttonRemoveJob_Click);
            // 
            // buttonAddJob
            // 
            this.buttonAddJob.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAddJob.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddJob.Location = new System.Drawing.Point(0, 0);
            this.buttonAddJob.Name = "buttonAddJob";
            this.buttonAddJob.Size = new System.Drawing.Size(90, 28);
            this.buttonAddJob.TabIndex = 6;
            this.buttonAddJob.Text = "Add new job";
            this.buttonAddJob.UseVisualStyleBackColor = true;
            this.buttonAddJob.Click += new System.EventHandler(this.buttonAddJob_Click);
            // 
            // labelHeading
            // 
            this.labelHeading.AutoSize = true;
            this.labelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeading.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelHeading.Location = new System.Drawing.Point(4, 4);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Padding = new System.Windows.Forms.Padding(3);
            this.labelHeading.Size = new System.Drawing.Size(171, 31);
            this.labelHeading.TabIndex = 4;
            this.labelHeading.Text = "Batch merge jobs";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.listBox);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(4, 35);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.panelList.Size = new System.Drawing.Size(976, 460);
            this.panelList.TabIndex = 5;
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 24;
            this.listBox.Location = new System.Drawing.Point(8, 8);
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(960, 448);
            this.listBox.TabIndex = 0;
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // panelCheckBox
            // 
            this.panelCheckBox.Controls.Add(this.checkBoxSaveDeleteList);
            this.panelCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCheckBox.Location = new System.Drawing.Point(157, 3);
            this.panelCheckBox.Name = "panelCheckBox";
            this.panelCheckBox.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.panelCheckBox.Size = new System.Drawing.Size(466, 24);
            this.panelCheckBox.TabIndex = 3;
            // 
            // checkBoxSaveDeleteList
            // 
            this.checkBoxSaveDeleteList.AutoSize = true;
            this.checkBoxSaveDeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSaveDeleteList.Location = new System.Drawing.Point(6, 0);
            this.checkBoxSaveDeleteList.Name = "checkBoxSaveDeleteList";
            this.checkBoxSaveDeleteList.Size = new System.Drawing.Size(460, 24);
            this.checkBoxSaveDeleteList.TabIndex = 2;
            this.checkBoxSaveDeleteList.Text = "Save a list of source files upon completion (for deleting manually)";
            this.checkBoxSaveDeleteList.UseVisualStyleBackColor = true;
            this.checkBoxSaveDeleteList.CheckedChanged += new System.EventHandler(this.checkBoxSaveDeleteList_CheckedChanged);
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.panelControls);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "PluginForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch Merge plugin";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelCheckBox.ResumeLayout(false);
            this.panelCheckBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button buttonMergeSelected;
        private System.Windows.Forms.Button buttonMergeAll;
        private System.Windows.Forms.Button buttonRemoveJob;
        private System.Windows.Forms.Button buttonAddJob;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Button buttonSetDeleteList;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panelCheckBox;
        private System.Windows.Forms.CheckBox checkBoxSaveDeleteList;
    }
}