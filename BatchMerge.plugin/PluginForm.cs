using SharpCutCommon;
using SharpCutCommon.Properties;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SharpCutCommon.Video.FFMPEG;

namespace BatchMerge.plugin
{
    public partial class PluginForm : Form
    {
        private FFMPEG fFMPEG = new FFMPEG();

        public PluginForm()
        {
            InitializeComponent();
        }

        private void UpdateList()
        {
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawMode = DrawMode.Normal;
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
                        Resources.ErrorFormatNotSupported,
                        Resources.GenericErrorTitle,
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

        private void MergeItem(BatchMergeJobItem batchMergeJobItem)
        {
            using (ProgressDialog progressDialog = new ProgressDialog())
            {
                progressDialog.ProgressTitle = Resources.MergingFiles;
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

                fFMPEG.Merge(batchMergeJobItem.Items.Select(item => item.FileName).ToList(), batchMergeJobItem.OutputName);
                progressDialog.ShowDialog();
            }
        }

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
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1) return;

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

        private void buttonMergeSelected_Click(object sender, EventArgs e)
        {
            MergeItem(listBox.SelectedItem as BatchMergeJobItem);
        }

        private void buttonMergeAll_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Maximum = listBox.Items.Count;

            List<BatchMergeJobItem> jobs = listBox.Items.Cast<BatchMergeJobItem>().ToList();
            foreach (BatchMergeJobItem batchMergeJobItem in jobs)
            {
                MergeItem(batchMergeJobItem);

                progressBar.Value++;
                Invalidate();
            }
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
    }
}
