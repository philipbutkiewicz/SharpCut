namespace SharpCutCommon.Dialogs
{
    partial class OpenNetworkDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenNetworkDialog));
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.labelURL = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxDownload = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelDownloadStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // textBoxURL
            // 
            resources.ApplyResources(this.textBoxURL, "textBoxURL");
            this.textBoxURL.Name = "textBoxURL";
            // 
            // labelURL
            // 
            resources.ApplyResources(this.labelURL, "labelURL");
            this.labelURL.Name = "labelURL";
            // 
            // buttonOpen
            // 
            resources.ApplyResources(this.buttonOpen, "buttonOpen");
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxDownload
            // 
            resources.ApplyResources(this.checkBoxDownload, "checkBoxDownload");
            this.checkBoxDownload.Name = "checkBoxDownload";
            this.checkBoxDownload.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // labelDownloadStatus
            // 
            resources.ApplyResources(this.labelDownloadStatus, "labelDownloadStatus");
            this.labelDownloadStatus.Name = "labelDownloadStatus";
            // 
            // OpenNetworkDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.labelDownloadStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkBoxDownload);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.labelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenNetworkDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxDownload;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelDownloadStatus;
    }
}