using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpCut
{
    public partial class SettingsForm : Form
    {
        #region Constructor

        public SettingsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBoxAutoSaveProject.Checked = SharpCutCommon.Properties.Settings.Default.AutoSaveProject;
            checkBoxGenerateFastPreview.Checked = SharpCutCommon.Properties.Settings.Default.GenerateFastPreview;
            labelTimelineScrollSpeedValue.Text = $"{SharpCutCommon.Properties.Settings.Default.TimelineScrollSpeed}s";
            trackBarTimelineScrollSpeed.Value = (int)Math.Round(SharpCutCommon.Properties.Settings.Default.TimelineScrollSpeed * 2f);

            switch (SharpCutCommon.Properties.Settings.Default.PreviewRate)
            {
                default:
                    comboBoxFastPreviewRate.SelectedIndex = 3;
                    break;
                case "24/60":
                    comboBoxFastPreviewRate.SelectedIndex = 0;
                    break;
                case "12/60":
                    comboBoxFastPreviewRate.SelectedIndex = 1;
                    break;
                case "6/60":
                    comboBoxFastPreviewRate.SelectedIndex = 2;
                    break;
            }

            textBoxProjectFileNameTemplate.Text = SharpCutCommon.Properties.Settings.Default.ProjectFileNameTemplate;
            textBoxSegmentFileNameTemplate.Text = SharpCutCommon.Properties.Settings.Default.SegmentFileNameTemplate;
            textBoxMergedFileNameTemplate.Text = SharpCutCommon.Properties.Settings.Default.MergedFileNameTemplate;
        }

        private void trackBarTimelineScrollSpeed_ValueChanged(object sender, EventArgs e)
        {
            labelTimelineScrollSpeedValue.Text = $"{trackBarTimelineScrollSpeed.Value * .5f}{SharpCutCommon.Properties.Resources.SecondIndicator}";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            SharpCutCommon.Properties.Settings.Default.AutoSaveProject = checkBoxAutoSaveProject.Checked;
            SharpCutCommon.Properties.Settings.Default.TimelineScrollSpeed = (trackBarTimelineScrollSpeed.Value * .5f);
            SharpCutCommon.Properties.Settings.Default.GenerateFastPreview = checkBoxGenerateFastPreview.Checked;

            switch (comboBoxFastPreviewRate.SelectedIndex)
            {
                case 0:
                    SharpCutCommon.Properties.Settings.Default.PreviewRate = "24/60";
                    break;
                case 1:
                    SharpCutCommon.Properties.Settings.Default.PreviewRate = "12/60";
                    break;
                case 2:
                    SharpCutCommon.Properties.Settings.Default.PreviewRate = "6/60";
                    break;
                case 3:
                    SharpCutCommon.Properties.Settings.Default.PreviewRate = "3/60";
                    break;
            }

            if (!VerifyAndSetFileNameTemplates())
            {
                MessageBox.Show(SharpCutCommon.Properties.Resources.FileNameTemplateInvalid, SharpCutCommon.Properties.Resources.FileNameTemplateInvalidTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            SharpCutCommon.Properties.Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Private methods

        private bool VerifyAndSetFileNameTemplates()
        {
            if (textBoxProjectFileNameTemplate.Text.Length == 0 || textBoxSegmentFileNameTemplate.Text.Length == 0 || textBoxMergedFileNameTemplate.Text.Length == 0)
            {
                return false;
            }

            SharpCutCommon.Properties.Settings.Default.ProjectFileNameTemplate = textBoxProjectFileNameTemplate.Text;
            SharpCutCommon.Properties.Settings.Default.SegmentFileNameTemplate = textBoxSegmentFileNameTemplate.Text;
            SharpCutCommon.Properties.Settings.Default.MergedFileNameTemplate = textBoxMergedFileNameTemplate.Text;

            return true;
        }

        #endregion
    }
}
