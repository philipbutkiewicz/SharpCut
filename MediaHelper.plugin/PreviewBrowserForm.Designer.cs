
namespace MediaHelper.plugin
{
    partial class PreviewBrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewBrowserForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFile = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxFrameskip = new System.Windows.Forms.ComboBox();
            this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.comboBoxRenderScale = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.labelFile);
            this.panel1.Controls.Add(this.comboBoxRenderScale);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.comboBoxFrameskip);
            this.panel1.Controls.Add(this.comboBoxSpeed);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonPrev);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // labelFile
            // 
            resources.ApplyResources(this.labelFile, "labelFile");
            this.labelFile.Name = "labelFile";
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Image = global::MediaHelper.plugin.Properties.Resources.media_floppy;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.TabStop = false;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxFrameskip
            // 
            resources.ApplyResources(this.comboBoxFrameskip, "comboBoxFrameskip");
            this.comboBoxFrameskip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameskip.FormattingEnabled = true;
            this.comboBoxFrameskip.Items.AddRange(new object[] {
            resources.GetString("comboBoxFrameskip.Items"),
            resources.GetString("comboBoxFrameskip.Items1"),
            resources.GetString("comboBoxFrameskip.Items2"),
            resources.GetString("comboBoxFrameskip.Items3"),
            resources.GetString("comboBoxFrameskip.Items4")});
            this.comboBoxFrameskip.Name = "comboBoxFrameskip";
            this.comboBoxFrameskip.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrameskip_SelectedIndexChanged);
            // 
            // comboBoxSpeed
            // 
            resources.ApplyResources(this.comboBoxSpeed, "comboBoxSpeed");
            this.comboBoxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpeed.FormattingEnabled = true;
            this.comboBoxSpeed.Items.AddRange(new object[] {
            resources.GetString("comboBoxSpeed.Items"),
            resources.GetString("comboBoxSpeed.Items1"),
            resources.GetString("comboBoxSpeed.Items2"),
            resources.GetString("comboBoxSpeed.Items3")});
            this.comboBoxSpeed.Name = "comboBoxSpeed";
            this.comboBoxSpeed.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpeed_SelectedIndexChanged);
            // 
            // buttonNext
            // 
            resources.ApplyResources(this.buttonNext, "buttonNext");
            this.buttonNext.Image = global::MediaHelper.plugin.Properties.Resources.go_next;
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.TabStop = false;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Image = global::MediaHelper.plugin.Properties.Resources.edit_delete;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.TabStop = false;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonPrev
            // 
            resources.ApplyResources(this.buttonPrev, "buttonPrev");
            this.buttonPrev.Image = global::MediaHelper.plugin.Properties.Resources.go_previous1;
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.TabStop = false;
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // comboBoxRenderScale
            // 
            resources.ApplyResources(this.comboBoxRenderScale, "comboBoxRenderScale");
            this.comboBoxRenderScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRenderScale.FormattingEnabled = true;
            this.comboBoxRenderScale.Items.AddRange(new object[] {
            resources.GetString("comboBoxRenderScale.Items"),
            resources.GetString("comboBoxRenderScale.Items1"),
            resources.GetString("comboBoxRenderScale.Items2"),
            resources.GetString("comboBoxRenderScale.Items3")});
            this.comboBoxRenderScale.Name = "comboBoxRenderScale";
            this.comboBoxRenderScale.SelectedIndexChanged += new System.EventHandler(this.comboBoxRenderScale_SelectedIndexChanged);
            // 
            // PreviewBrowserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewBrowserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewBrowserForm_FormClosing);
            this.Load += new System.EventHandler(this.PreviewBrowserForm_Load);
            this.Move += new System.EventHandler(this.PreviewBrowserForm_Move);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.ComboBox comboBoxSpeed;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.ComboBox comboBoxFrameskip;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxRenderScale;
    }
}