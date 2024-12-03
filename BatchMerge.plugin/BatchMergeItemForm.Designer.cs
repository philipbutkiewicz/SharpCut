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
            this.Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Files.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Files.FormattingEnabled = true;
            this.Files.Location = new System.Drawing.Point(8, 8);
            this.Files.Name = "Files";
            this.Files.ScrollAlwaysVisible = true;
            this.Files.Size = new System.Drawing.Size(355, 193);
            this.Files.TabIndex = 2;
            this.Files.SelectedIndexChanged += new System.EventHandler(this.Files_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Files);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.panel1.Size = new System.Drawing.Size(363, 209);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonDown);
            this.panel2.Controls.Add(this.buttonUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(363, 52);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.panel2.Size = new System.Drawing.Size(111, 209);
            this.panel2.TabIndex = 8;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.White;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(3, 54);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.White;
            this.buttonDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDown.Enabled = false;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDown.Location = new System.Drawing.Point(3, 31);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(100, 23);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.Text = "Move down";
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.White;
            this.buttonUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUp.Enabled = false;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonUp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUp.Location = new System.Drawing.Point(3, 8);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(100, 23);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.Text = "Move up";
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // panelOutputSettings
            // 
            this.panelOutputSettings.BackColor = System.Drawing.Color.White;
            this.panelOutputSettings.Controls.Add(this.panelOutputFileName);
            this.panelOutputSettings.Controls.Add(this.buttonBrowse);
            this.panelOutputSettings.Controls.Add(this.labelOutputName);
            this.panelOutputSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOutputSettings.Location = new System.Drawing.Point(0, 0);
            this.panelOutputSettings.Name = "panelOutputSettings";
            this.panelOutputSettings.Padding = new System.Windows.Forms.Padding(8);
            this.panelOutputSettings.Size = new System.Drawing.Size(474, 52);
            this.panelOutputSettings.TabIndex = 9;
            // 
            // panelOutputFileName
            // 
            this.panelOutputFileName.Controls.Add(this.textBoxOutput);
            this.panelOutputFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputFileName.Location = new System.Drawing.Point(8, 21);
            this.panelOutputFileName.Name = "panelOutputFileName";
            this.panelOutputFileName.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panelOutputFileName.Size = new System.Drawing.Size(358, 23);
            this.panelOutputFileName.TabIndex = 13;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(355, 22);
            this.textBoxOutput.TabIndex = 12;
            this.textBoxOutput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.BackColor = System.Drawing.Color.White;
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.Location = new System.Drawing.Point(366, 21);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowse.TabIndex = 12;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = false;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelOutputName
            // 
            this.labelOutputName.AutoSize = true;
            this.labelOutputName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelOutputName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutputName.Location = new System.Drawing.Point(8, 8);
            this.labelOutputName.Name = "labelOutputName";
            this.labelOutputName.Size = new System.Drawing.Size(95, 13);
            this.labelOutputName.TabIndex = 10;
            this.labelOutputName.Text = "Output file name";
            // 
            // BatchMergeItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelOutputSettings);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 300);
            this.Name = "BatchMergeItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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