
namespace SharpCut
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.checkBoxMerge = new System.Windows.Forms.CheckBox();
            this.comboBoxContainer = new System.Windows.Forms.ComboBox();
            this.labelContainer = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // checkBoxMerge
            // 
            resources.ApplyResources(this.checkBoxMerge, "checkBoxMerge");
            this.checkBoxMerge.Name = "checkBoxMerge";
            this.checkBoxMerge.UseVisualStyleBackColor = true;
            // 
            // comboBoxContainer
            // 
            resources.ApplyResources(this.comboBoxContainer, "comboBoxContainer");
            this.comboBoxContainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContainer.FormattingEnabled = true;
            this.comboBoxContainer.Items.AddRange(new object[] {
            resources.GetString("comboBoxContainer.Items"),
            resources.GetString("comboBoxContainer.Items1"),
            resources.GetString("comboBoxContainer.Items2")});
            this.comboBoxContainer.Name = "comboBoxContainer";
            // 
            // labelContainer
            // 
            resources.ApplyResources(this.labelContainer, "labelContainer");
            this.labelContainer.Name = "labelContainer";
            // 
            // buttonExport
            // 
            resources.ApplyResources(this.buttonExport, "buttonExport");
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ExportForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelContainer);
            this.Controls.Add(this.comboBoxContainer);
            this.Controls.Add(this.checkBoxMerge);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportForm_FormClosing);
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.CheckBox checkBoxMerge;
        private System.Windows.Forms.ComboBox comboBoxContainer;
        private System.Windows.Forms.Label labelContainer;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonCancel;
    }
}