
namespace SharpCutCommon
{
    partial class ProgressDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialog));
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonShowDetails = new System.Windows.Forms.Button();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.labelProgress = new System.Windows.Forms.Label();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.MarqueeAnimationSpeed = 33;
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // buttonShowDetails
            // 
            resources.ApplyResources(this.buttonShowDetails, "buttonShowDetails");
            this.buttonShowDetails.Name = "buttonShowDetails";
            this.buttonShowDetails.UseVisualStyleBackColor = true;
            this.buttonShowDetails.Click += new System.EventHandler(this.buttonShowDetails_Click);
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.labelProgress);
            resources.ApplyResources(this.panelProgress, "panelProgress");
            this.panelProgress.Name = "panelProgress";
            // 
            // labelProgress
            // 
            resources.ApplyResources(this.labelProgress, "labelProgress");
            this.labelProgress.Name = "labelProgress";
            // 
            // ProgressDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.buttonShowDetails);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressDialog";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonShowDetails;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label labelProgress;
    }
}