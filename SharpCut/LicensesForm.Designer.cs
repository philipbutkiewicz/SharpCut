namespace SharpCut
{
    partial class LicensesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicensesForm));
            this.listBoxDependencies = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxLicense = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxDependencies
            // 
            resources.ApplyResources(this.listBoxDependencies, "listBoxDependencies");
            this.listBoxDependencies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxDependencies.FormattingEnabled = true;
            this.listBoxDependencies.Items.AddRange(new object[] {
            resources.GetString("listBoxDependencies.Items"),
            resources.GetString("listBoxDependencies.Items1"),
            resources.GetString("listBoxDependencies.Items2"),
            resources.GetString("listBoxDependencies.Items3"),
            resources.GetString("listBoxDependencies.Items4")});
            this.listBoxDependencies.Name = "listBoxDependencies";
            this.listBoxDependencies.SelectedIndexChanged += new System.EventHandler(this.listBoxDependencies_SelectedIndexChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.textBoxLicense);
            this.panel1.Name = "panel1";
            // 
            // textBoxLicense
            // 
            resources.ApplyResources(this.textBoxLicense, "textBoxLicense");
            this.textBoxLicense.BackColor = System.Drawing.Color.White;
            this.textBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLicense.Name = "textBoxLicense";
            this.textBoxLicense.ReadOnly = true;
            // 
            // LicensesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxDependencies);
            this.Name = "LicensesForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDependencies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxLicense;
    }
}