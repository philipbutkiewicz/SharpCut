
namespace SharpCut
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.checkBoxAutoSaveProject = new System.Windows.Forms.CheckBox();
            this.labelTimelineScrollSpeed = new System.Windows.Forms.Label();
            this.trackBarTimelineScrollSpeed = new System.Windows.Forms.TrackBar();
            this.labelTimelineScrollSpeedValue = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.checkBoxGenerateFastPreview = new System.Windows.Forms.CheckBox();
            this.labelFastPreviewAccuracy = new System.Windows.Forms.Label();
            this.comboBoxFastPreviewRate = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageFileNames = new System.Windows.Forms.TabPage();
            this.textBoxMergedFileNameTemplate = new System.Windows.Forms.TextBox();
            this.labelMergedFileNameTemplate = new System.Windows.Forms.Label();
            this.textBoxSegmentFileNameTemplate = new System.Windows.Forms.TextBox();
            this.labelSegmentFileNameTemplate = new System.Windows.Forms.Label();
            this.textBoxProjectFileNameTemplate = new System.Windows.Forms.TextBox();
            this.labelProjectFileNameTemplate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimelineScrollSpeed)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageFileNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // checkBoxAutoSaveProject
            // 
            resources.ApplyResources(this.checkBoxAutoSaveProject, "checkBoxAutoSaveProject");
            this.checkBoxAutoSaveProject.Name = "checkBoxAutoSaveProject";
            this.checkBoxAutoSaveProject.UseVisualStyleBackColor = true;
            // 
            // labelTimelineScrollSpeed
            // 
            resources.ApplyResources(this.labelTimelineScrollSpeed, "labelTimelineScrollSpeed");
            this.labelTimelineScrollSpeed.Name = "labelTimelineScrollSpeed";
            // 
            // trackBarTimelineScrollSpeed
            // 
            resources.ApplyResources(this.trackBarTimelineScrollSpeed, "trackBarTimelineScrollSpeed");
            this.trackBarTimelineScrollSpeed.Maximum = 20;
            this.trackBarTimelineScrollSpeed.Minimum = 1;
            this.trackBarTimelineScrollSpeed.Name = "trackBarTimelineScrollSpeed";
            this.trackBarTimelineScrollSpeed.Value = 1;
            this.trackBarTimelineScrollSpeed.ValueChanged += new System.EventHandler(this.trackBarTimelineScrollSpeed_ValueChanged);
            // 
            // labelTimelineScrollSpeedValue
            // 
            resources.ApplyResources(this.labelTimelineScrollSpeedValue, "labelTimelineScrollSpeedValue");
            this.labelTimelineScrollSpeedValue.Name = "labelTimelineScrollSpeedValue";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveSettings
            // 
            resources.ApplyResources(this.buttonSaveSettings, "buttonSaveSettings");
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // checkBoxGenerateFastPreview
            // 
            resources.ApplyResources(this.checkBoxGenerateFastPreview, "checkBoxGenerateFastPreview");
            this.checkBoxGenerateFastPreview.Name = "checkBoxGenerateFastPreview";
            this.checkBoxGenerateFastPreview.UseVisualStyleBackColor = true;
            // 
            // labelFastPreviewAccuracy
            // 
            resources.ApplyResources(this.labelFastPreviewAccuracy, "labelFastPreviewAccuracy");
            this.labelFastPreviewAccuracy.Name = "labelFastPreviewAccuracy";
            // 
            // comboBoxFastPreviewRate
            // 
            resources.ApplyResources(this.comboBoxFastPreviewRate, "comboBoxFastPreviewRate");
            this.comboBoxFastPreviewRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFastPreviewRate.FormattingEnabled = true;
            this.comboBoxFastPreviewRate.Items.AddRange(new object[] {
            resources.GetString("comboBoxFastPreviewRate.Items"),
            resources.GetString("comboBoxFastPreviewRate.Items1"),
            resources.GetString("comboBoxFastPreviewRate.Items2"),
            resources.GetString("comboBoxFastPreviewRate.Items3")});
            this.comboBoxFastPreviewRate.Name = "comboBoxFastPreviewRate";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageFileNames);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageGeneral
            // 
            resources.ApplyResources(this.tabPageGeneral, "tabPageGeneral");
            this.tabPageGeneral.BackColor = System.Drawing.Color.White;
            this.tabPageGeneral.Controls.Add(this.checkBoxAutoSaveProject);
            this.tabPageGeneral.Controls.Add(this.comboBoxFastPreviewRate);
            this.tabPageGeneral.Controls.Add(this.labelTimelineScrollSpeed);
            this.tabPageGeneral.Controls.Add(this.labelFastPreviewAccuracy);
            this.tabPageGeneral.Controls.Add(this.trackBarTimelineScrollSpeed);
            this.tabPageGeneral.Controls.Add(this.checkBoxGenerateFastPreview);
            this.tabPageGeneral.Controls.Add(this.labelTimelineScrollSpeedValue);
            this.tabPageGeneral.Name = "tabPageGeneral";
            // 
            // tabPageFileNames
            // 
            resources.ApplyResources(this.tabPageFileNames, "tabPageFileNames");
            this.tabPageFileNames.BackColor = System.Drawing.Color.White;
            this.tabPageFileNames.Controls.Add(this.textBoxMergedFileNameTemplate);
            this.tabPageFileNames.Controls.Add(this.labelMergedFileNameTemplate);
            this.tabPageFileNames.Controls.Add(this.textBoxSegmentFileNameTemplate);
            this.tabPageFileNames.Controls.Add(this.labelSegmentFileNameTemplate);
            this.tabPageFileNames.Controls.Add(this.textBoxProjectFileNameTemplate);
            this.tabPageFileNames.Controls.Add(this.labelProjectFileNameTemplate);
            this.tabPageFileNames.Name = "tabPageFileNames";
            // 
            // textBoxMergedFileNameTemplate
            // 
            resources.ApplyResources(this.textBoxMergedFileNameTemplate, "textBoxMergedFileNameTemplate");
            this.textBoxMergedFileNameTemplate.Name = "textBoxMergedFileNameTemplate";
            // 
            // labelMergedFileNameTemplate
            // 
            resources.ApplyResources(this.labelMergedFileNameTemplate, "labelMergedFileNameTemplate");
            this.labelMergedFileNameTemplate.Name = "labelMergedFileNameTemplate";
            // 
            // textBoxSegmentFileNameTemplate
            // 
            resources.ApplyResources(this.textBoxSegmentFileNameTemplate, "textBoxSegmentFileNameTemplate");
            this.textBoxSegmentFileNameTemplate.Name = "textBoxSegmentFileNameTemplate";
            // 
            // labelSegmentFileNameTemplate
            // 
            resources.ApplyResources(this.labelSegmentFileNameTemplate, "labelSegmentFileNameTemplate");
            this.labelSegmentFileNameTemplate.Name = "labelSegmentFileNameTemplate";
            // 
            // textBoxProjectFileNameTemplate
            // 
            resources.ApplyResources(this.textBoxProjectFileNameTemplate, "textBoxProjectFileNameTemplate");
            this.textBoxProjectFileNameTemplate.Name = "textBoxProjectFileNameTemplate";
            // 
            // labelProjectFileNameTemplate
            // 
            resources.ApplyResources(this.labelProjectFileNameTemplate, "labelProjectFileNameTemplate");
            this.labelProjectFileNameTemplate.Name = "labelProjectFileNameTemplate";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTimelineScrollSpeed)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageFileNames.ResumeLayout(false);
            this.tabPageFileNames.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveProject;
        private System.Windows.Forms.Label labelTimelineScrollSpeed;
        private System.Windows.Forms.TrackBar trackBarTimelineScrollSpeed;
        private System.Windows.Forms.Label labelTimelineScrollSpeedValue;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.CheckBox checkBoxGenerateFastPreview;
        private System.Windows.Forms.Label labelFastPreviewAccuracy;
        private System.Windows.Forms.ComboBox comboBoxFastPreviewRate;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageFileNames;
        private System.Windows.Forms.Label labelProjectFileNameTemplate;
        private System.Windows.Forms.TextBox textBoxMergedFileNameTemplate;
        private System.Windows.Forms.Label labelMergedFileNameTemplate;
        private System.Windows.Forms.TextBox textBoxSegmentFileNameTemplate;
        private System.Windows.Forms.Label labelSegmentFileNameTemplate;
        private System.Windows.Forms.TextBox textBoxProjectFileNameTemplate;
    }
}