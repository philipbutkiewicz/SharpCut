using SharpCutCommon.Video;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpCut
{
    public partial class ExportForm : Form
    {
        #region Properties

        /// <summary>
        /// Default fucking export settings.
        /// </summary>
        public ExportSettings DefaultExportSettings = null;

        #endregion

        #region Fields

        /// <summary>
        /// Are we currently merging after the export?
        /// </summary>
        private bool isMergingAfterExport = false;

        #endregion

        #region Public methods

        public ExportForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Called when the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportForm_Load(object sender, EventArgs e)
        {
            comboBoxContainer.SelectedIndex = 0;

            if (DefaultExportSettings != null)
            {
                comboBoxContainer.SelectedIndex = DefaultExportSettings.Container;
                checkBoxMerge.Checked = DefaultExportSettings.MergeFiles;

                buttonExport_Click(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when the form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetEvents();
        }

        /// <summary>
        /// Called when the cancel button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Called when the export button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            ControlBox = false;
            buttonCancel.Enabled = false;
            buttonExport.Enabled = false;

            Project.CurrentProject.ExportCompleted += CurrentProject_ExportCompleted;
            Project.CurrentProject.MergeCompleted += CurrentProject_MergeCompleted;
            Project.CurrentProject.Export(GetContainer());
        }

        /// <summary>
        /// Called when the merge is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentProject_MergeCompleted(object sender, Project.MergeCompletedEventArgs e)
        {
            if (!e.Success)
            {
                DialogResult = DialogResult.Abort;
                Close();
                return;
            }

            DialogResult = DialogResult.OK;
            DefaultExportSettings = new ExportSettings()
            {
                Container = comboBoxContainer.SelectedIndex,
                MergeFiles = checkBoxMerge.Checked
            };

            isMergingAfterExport = false;

            Close();
        }

        /// <summary>
        /// Called when the export is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentProject_ExportCompleted(object sender, Project.ExportCompletedEventArgs e)
        {
            if (e.Success && checkBoxMerge.Checked && !isMergingAfterExport)
            {
                isMergingAfterExport = true;
                Project.CurrentProject.Merge(Path.GetFileName(Project.CurrentProject.MediaFileName), e.ExportedFileNames, GetContainer());
                return;
            }

            if (!e.Success)
            {
                DialogResult = DialogResult.Abort;
            }

            DialogResult = DialogResult.OK;
            DefaultExportSettings = new ExportSettings()
            {
                Container = comboBoxContainer.SelectedIndex,
                MergeFiles = checkBoxMerge.Checked
            };

            isMergingAfterExport = false;

            Close();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets the selected container.
        /// </summary>
        /// <returns></returns>
        private string GetContainer()
        {
            switch (comboBoxContainer.SelectedIndex)
            {
                default:
                    return null;
                case 1:
                    return "mp4";
                case 2:
                    return "mkv";
            }
        }

        /// <summary>
        /// Remove event calls.
        /// </summary>
        private void ResetEvents()
        {
            Project.CurrentProject.ExportCompleted -= CurrentProject_ExportCompleted;
            Project.CurrentProject.MergeCompleted -= CurrentProject_MergeCompleted;
        }

        #endregion
    }
}
