namespace SharpCutCommon.Dialogs
{
    partial class TimeInputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeInputDialog));
            this.buttonSet = new System.Windows.Forms.Button();
            this.textBoxHours = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.textBoxMinutes = new System.Windows.Forms.TextBox();
            this.textBoxSeconds = new System.Windows.Forms.TextBox();
            this.textBoxMilliseconds = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSet
            // 
            resources.ApplyResources(this.buttonSet, "buttonSet");
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // textBoxHours
            // 
            resources.ApplyResources(this.textBoxHours, "textBoxHours");
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.TextChanged += new System.EventHandler(this.textBoxHours_TextChanged);
            this.textBoxHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            // 
            // textBoxMinutes
            // 
            resources.ApplyResources(this.textBoxMinutes, "textBoxMinutes");
            this.textBoxMinutes.Name = "textBoxMinutes";
            this.textBoxMinutes.TextChanged += new System.EventHandler(this.textBoxMinutes_TextChanged);
            this.textBoxMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxSeconds
            // 
            resources.ApplyResources(this.textBoxSeconds, "textBoxSeconds");
            this.textBoxSeconds.Name = "textBoxSeconds";
            this.textBoxSeconds.TextChanged += new System.EventHandler(this.textBoxSeconds_TextChanged);
            this.textBoxSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxMilliseconds
            // 
            resources.ApplyResources(this.textBoxMilliseconds, "textBoxMilliseconds");
            this.textBoxMilliseconds.Name = "textBoxMilliseconds";
            this.textBoxMilliseconds.TextChanged += new System.EventHandler(this.textBoxMilliseconds_TextChanged);
            this.textBoxMilliseconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // TimeInputDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBoxMilliseconds);
            this.Controls.Add(this.textBoxSeconds);
            this.Controls.Add(this.textBoxMinutes);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.textBoxHours);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeInputDialog";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.TimeInputDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSet;
        public System.Windows.Forms.TextBox textBoxHours;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.TextBox textBoxMinutes;
        public System.Windows.Forms.TextBox textBoxSeconds;
        public System.Windows.Forms.TextBox textBoxMilliseconds;
    }
}