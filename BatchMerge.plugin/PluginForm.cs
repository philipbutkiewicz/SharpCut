using SharpCutCommon;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SharpCutCommon.Video.FFMPEG;

namespace BatchMerge.plugin
{
    public partial class PluginForm : Form
    {
        private FFMPEG fFMPEG = new FFMPEG();

        private string deleteListPath = null;

        private Font defaultFont = new Font("Segoe UI", 9.5f);

        public PluginForm()
        {
            InitializeComponent();
        }

        #region Private methods

        private void UpdateList()
        {
            listBox.Invalidate();
        }

        private void AddSource(List<string> fileNames)
        {
            if (fileNames.Count == 0) return;

            BatchMergeJobItem jobItem = new BatchMergeJobItem();
            foreach (string fileName in fileNames)
            {
                if (!IsMediaSupported(fileName))
                {
                    MessageBox.Show(
                        SharpCutCommon.Properties.Resources.ErrorFormatNotSupported,
                        SharpCutCommon.Properties.Resources.GenericErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                jobItem.Items.Add(new BatchMergeFileItem()
                {
                    FileName = fileName,
                });
            }

            jobItem.OutputName = jobItem.Items[0].FileName.Replace(
                Path.GetExtension(jobItem.Items[0].FileName), "-merged" + Path.GetExtension(jobItem.Items[0].FileName)
            );

            listBox.Items.Add(jobItem);

            buttonMergeAll.Enabled = true;
        }

        private void RemoveJob(int index)
        {
            listBox.Items.RemoveAt(index);

            if (listBox.Items.Count == 0)
            {
                buttonMergeAll.Enabled = false;
                buttonMergeSelected.Enabled = false;
                buttonRemoveJob.Enabled = false;
            }
        }

        private void EditJob(int index)
        {
            if (index == -1) return;

            using (BatchMergeItemForm batchMergeItemForm = new BatchMergeItemForm())
            {
                BatchMergeJobItem batchMergeJobItem = listBox.SelectedItem as BatchMergeJobItem;
                batchMergeItemForm.Files.Items.AddRange(batchMergeJobItem.Items.ToArray());
                batchMergeItemForm.OutputName = batchMergeJobItem.OutputName;

                if (batchMergeItemForm.ShowDialog() == DialogResult.OK)
                {
                    batchMergeJobItem.OutputName = batchMergeItemForm.OutputName;
                    batchMergeJobItem.Items.Clear();
                    batchMergeJobItem.Items.AddRange(batchMergeItemForm.Files.Items.Cast<BatchMergeFileItem>().ToArray());
                    UpdateList();
                }
            }
        }

        private void MergeItem(BatchMergeJobItem batchMergeJobItem)
        {
            using (ProgressDialog progressDialog = new ProgressDialog())
            {
                progressDialog.ProgressTitle = SharpCutCommon.Properties.Resources.MergingFiles;
                fFMPEG.Progress += (object _sender, ProgressEventArgs _e) =>
                {
                    try
                    {
                        progressDialog?.SetProgress(_e.ProgressPercentage, _e.CurrentTime, _e.TotalTime);
                    }
                    catch
                    {
                        // Progress dialog may be disposed before we make a call here. Completed event might come earlier than the progress event. Lol fml.
                    }
                };

                fFMPEG.Completed += (object __sender, CompletedEventArgs __e) =>
                {
                    if (!__e.Success)
                    {
                        progressDialog?.Abort();

                        batchMergeJobItem.Status = BatchMergeJobItem.JobStatus.Error;
                        UpdateList();

                        return;
                    }

                    progressDialog?.Close();

                    batchMergeJobItem.Status = BatchMergeJobItem.JobStatus.Success;
                    UpdateList();
                };

                batchMergeJobItem.Status = BatchMergeJobItem.JobStatus.Started;
                UpdateList();

                fFMPEG.Merge(batchMergeJobItem.Items.Select(item => item.FileName).ToList(), batchMergeJobItem.OutputName);
                progressDialog.ShowDialog();
            }
        }

        private void MergeAll()
        {
            progressBar.Value = 0;
            progressBar.Maximum = listBox.Items.Count;
            progressBar.Show();

            StreamWriter streamWriter = !string.IsNullOrEmpty(deleteListPath) && checkBoxSaveDeleteList.Checked ? new StreamWriter(deleteListPath, true, System.Text.Encoding.UTF8) : null;

            List<BatchMergeJobItem> jobs = listBox.Items.Cast<BatchMergeJobItem>().ToList();
            foreach (BatchMergeJobItem batchMergeJobItem in jobs)
            {
                MergeItem(batchMergeJobItem);

                if (streamWriter != null)
                {
                    foreach (BatchMergeFileItem batchMergeFileItem in batchMergeJobItem.Items)
                    {
                        streamWriter.WriteLine(Path.GetFileName(batchMergeFileItem.FileName));
                    }
                }

                progressBar.Value++;
                Invalidate();
            }

            streamWriter?.Dispose();

            progressBar.Hide();

            MessageBox.Show(
                "All merge jobs have been completed.",
                "Jobs completed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void SetDeleteListPath()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.DefaultExt = ".txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    deleteListPath = saveFileDialog.FileName;
                }
            }
        }

        #endregion

        #region Events

        private void PluginForm_Load(object sender, EventArgs e)
        {
            listBox.DisplayMember = "DisplayName";
        }

        private void buttonAddJob_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddSource(openFileDialog.FileNames.ToList());
                }
            }
        }

        private void buttonRemoveJob_Click(object sender, EventArgs e)
        {
            RemoveJob(listBox.SelectedIndex);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonMergeSelected.Enabled = listBox.SelectedIndex > -1;
            buttonRemoveJob.Enabled = listBox.SelectedIndex > -1;
            UpdateList();
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            EditJob(listBox.SelectedIndex);
        }

        private void buttonMergeSelected_Click(object sender, EventArgs e)
        {
            MergeItem(listBox.SelectedItem as BatchMergeJobItem);
        }

        private void buttonMergeAll_Click(object sender, EventArgs e)
        {
            MergeAll();
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
            {
                AddSource(files.ToList());
                return;
            }
        }

        private void checkBoxSaveDeleteList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSaveDeleteList.Checked && string.IsNullOrEmpty(deleteListPath))
            {
                SetDeleteListPath();
            }
        }

        private void buttonSetDeleteList_Click(object sender, EventArgs e)
        {
            SetDeleteListPath();
        }

        #endregion

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            Graphics g = e.Graphics;
            g.FillRectangle(e.Index == listBox.SelectedIndex ? SystemBrushes.Highlight : Brushes.White, e.Bounds);

            BatchMergeJobItem batchMergeJobItem = listBox.Items[e.Index] as BatchMergeJobItem;

            Image statusImage = Resources.ImageQueued;
            switch (batchMergeJobItem.Status)
            {
                case BatchMergeJobItem.JobStatus.Success:
                    statusImage = Resources.ImageSuccess;
                    break;
                case BatchMergeJobItem.JobStatus.Started:
                    statusImage = Resources.ImageStarted;
                    break;
                case BatchMergeJobItem.JobStatus.Error:
                    statusImage = Resources.ImageFailed;
                    break;
            }

            g.DrawImage(statusImage, new Rectangle(e.Bounds.Left + 4, e.Bounds.Top + 4, 16, 16));
            g.DrawString(
                batchMergeJobItem.DisplayName,
                defaultFont, e.Index == listBox.SelectedIndex ? Brushes.White : Brushes.Black,
                new Point(e.Bounds.Left + 24, e.Bounds.Top + 2)
            );
        }
    }
}
