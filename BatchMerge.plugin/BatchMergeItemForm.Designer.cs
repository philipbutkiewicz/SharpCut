namespace BatchMerge.plugin
{
    partial class BatchMergeItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchMergeItemForm));
            this.Files = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.panelOutputSettings = new System.Windows.Forms.Panel();
            this.panelOutputFileName = new System.Windows.Forms.Panel();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelOutputName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelOutputSettings.SuspendLayout();
            this.panelOutputFileName.SuspendLayout();
            this.SuspendLayout();
            // 
            // Files
            // 
            resources.ApplyResources(this.Files, "Files");
            this.Files.FormattingEnabled = true;
            this.Files.Name = "Files";
            this.Files.SelectedIndexChanged += new System.EventHandler(this.Files_SelectedIndexChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Files);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonDown);
            this.panel2.Controls.Add(this.buttonUp);
            this.panel2.Name = "panel2";
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.BackColor = System.Drawing.Color.White;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDown
            // 
            resources.ApplyResources(this.buttonDown, "buttonDown");
            this.buttonDown.BackColor = System.Drawing.Color.White;
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            resources.ApplyResources(this.buttonUp, "buttonUp");
            this.buttonUp.BackColor = System.Drawing.Color.White;
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // panelOutputSettings
            // 
            resources.ApplyResources(this.panelOutputSettings, "panelOutputSettings");
            this.panelOutputSettings.BackColor = System.Drawing.Color.White;
            this.panelOutputSettings.Controls.Add(this.panelOutputFileName);
            this.panelOutputSettings.Controls.Add(this.buttonBrowse);
            this.panelOutputSettings.Controls.Add(this.labelOutputName);
            this.panelOutputSettings.Name = "panelOutputSettings";
            // 
            // panelOutputFileName
            // 
            resources.ApplyResources(this.panelOutputFileName, "panelOutputFileName");
            this.panelOutputFileName.Controls.Add(this.textBoxOutput);
            this.panelOutputFileName.Name = "panelOutputFileName";
            // 
            // textBoxOutput
            // 
            resources.ApplyResources(this.textBoxOutput, "textBoxOutput");
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // buttonBrowse
            // 
            resources.ApplyResources(this.buttonBrowse, "buttonBrowse");
            this.buttonBrowse.BackColor = System.Drawing.Color.White;
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.UseVisualStyleBackColor = false;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelOutputName
            // 
            resources.ApplyResources(this.labelOutputName, "labelOutputName");
            this.labelOutputName.Name = "labelOutputName";
            // 
            // BatchMergeItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelOutputSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchMergeItemForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchMergeItemForm_FormClosing);
            this.Load += new System.EventHandler(this.BatchMergeItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelOutputSettings.ResumeLayout(false);
            this.panelOutputSettings.PerformLayout();
            this.panelOutputFileName.ResumeLayout(false);
            this.panelOutputFileName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Panel panelOutputSettings;
        private System.Windows.Forms.Label labelOutputName;
        private System.Windows.Forms.Button buttonBrowse;
        public System.Windows.Forms.ListBox Files;
        private System.Windows.Forms.Panel panelOutputFileName;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}