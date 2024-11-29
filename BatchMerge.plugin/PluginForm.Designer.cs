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
            this.buttonAddJob = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonRemoveJob = new System.Windows.Forms.Button();
            this.buttonMergeSelected = new System.Windows.Forms.Button();
            this.buttonMergeAll = new System.Windows.Forms.Button();
            this.labelHeading = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panelControls.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddJob
            // 
            this.buttonAddJob.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAddJob.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddJob.Location = new System.Drawing.Point(8, 0);
            this.buttonAddJob.Name = "buttonAddJob";
            this.buttonAddJob.Size = new System.Drawing.Size(90, 24);
            this.buttonAddJob.TabIndex = 2;
            this.buttonAddJob.Text = "Add new job";
            this.buttonAddJob.UseVisualStyleBackColor = true;
            this.buttonAddJob.Click += new System.EventHandler(this.buttonAddJob_Click);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.panelProgress);
            this.panelControls.Controls.Add(this.buttonRemoveJob);
            this.panelControls.Controls.Add(this.buttonAddJob);
            this.panelControls.Controls.Add(this.buttonMergeSelected);
            this.panelControls.Controls.Add(this.buttonMergeAll);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(4, 412);
            this.panelControls.Name = "panelControls";
            this.panelControls.Padding = new System.Windows.Forms.Padding(8, 0, 8, 4);
            this.panelControls.Size = new System.Drawing.Size(792, 28);
            this.panelControls.TabIndex = 3;
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.progressBar);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgress.Location = new System.Drawing.Point(178, 0);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Padding = new System.Windows.Forms.Padding(3);
            this.panelProgress.Size = new System.Drawing.Size(420, 24);
            this.panelProgress.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(414, 18);
            this.progressBar.TabIndex = 5;
            // 
            // buttonRemoveJob
            // 
            this.buttonRemoveJob.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRemoveJob.Enabled = false;
            this.buttonRemoveJob.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRemoveJob.Location = new System.Drawing.Point(98, 0);
            this.buttonRemoveJob.Name = "buttonRemoveJob";
            this.buttonRemoveJob.Size = new System.Drawing.Size(80, 24);
            this.buttonRemoveJob.TabIndex = 3;
            this.buttonRemoveJob.Text = "Remove job";
            this.buttonRemoveJob.UseVisualStyleBackColor = true;
            this.buttonRemoveJob.Click += new System.EventHandler(this.buttonRemoveJob_Click);
            // 
            // buttonMergeSelected
            // 
            this.buttonMergeSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMergeSelected.Enabled = false;
            this.buttonMergeSelected.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonMergeSelected.Location = new System.Drawing.Point(598, 0);
            this.buttonMergeSelected.Name = "buttonMergeSelected";
            this.buttonMergeSelected.Size = new System.Drawing.Size(96, 24);
            this.buttonMergeSelected.TabIndex = 1;
            this.buttonMergeSelected.Text = "Merge selected";
            this.buttonMergeSelected.UseVisualStyleBackColor = true;
            this.buttonMergeSelected.Click += new System.EventHandler(this.buttonMergeSelected_Click);
            // 
            // buttonMergeAll
            // 
            this.buttonMergeAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMergeAll.Enabled = false;
            this.buttonMergeAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonMergeAll.Location = new System.Drawing.Point(694, 0);
            this.buttonMergeAll.Name = "buttonMergeAll";
            this.buttonMergeAll.Size = new System.Drawing.Size(90, 24);
            this.buttonMergeAll.TabIndex = 0;
            this.buttonMergeAll.Text = "Merge all";
            this.buttonMergeAll.UseVisualStyleBackColor = true;
            this.buttonMergeAll.Click += new System.EventHandler(this.buttonMergeAll_Click);
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
            this.panelList.Size = new System.Drawing.Size(792, 377);
            this.panelList.TabIndex = 5;
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(8, 8);
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(776, 365);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.panelControls);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PluginForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch Merge plugin";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddJob;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button buttonRemoveJob;
        private System.Windows.Forms.Button buttonMergeSelected;
        private System.Windows.Forms.Button buttonMergeAll;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}