
namespace SharpCut
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelBuildDate = new System.Windows.Forms.Label();
            this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.buttonChangelog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // labelBuildDate
            // 
            resources.ApplyResources(this.labelBuildDate, "labelBuildDate");
            this.labelBuildDate.Name = "labelBuildDate";
            // 
            // linkLabelWebsite
            // 
            resources.ApplyResources(this.linkLabelWebsite, "linkLabelWebsite");
            this.linkLabelWebsite.Name = "linkLabelWebsite";
            this.linkLabelWebsite.TabStop = true;
            this.linkLabelWebsite.Click += new System.EventHandler(this.linkLabelWebsite_Click);
            // 
            // labelCopyright
            // 
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.Name = "labelCopyright";
            // 
            // buttonChangelog
            // 
            resources.ApplyResources(this.buttonChangelog, "buttonChangelog");
            this.buttonChangelog.Name = "buttonChangelog";
            this.buttonChangelog.UseVisualStyleBackColor = true;
            this.buttonChangelog.Click += new System.EventHandler(this.buttonChangelog_Click);
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonChangelog);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.linkLabelWebsite);
            this.Controls.Add(this.labelBuildDate);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelBuildDate;
        private System.Windows.Forms.LinkLabel linkLabelWebsite;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Button buttonChangelog;
    }
}