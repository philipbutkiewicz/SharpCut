﻿using SharpCutCommon;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static SharpCutCommon.Video.FFMPEG;

namespace BatchMerge.plugin
{
    public partial class PluginForm : Form
    {

        #region Fields

        private FFMPEG fFMPEG = new FFMPEG();

        private string deleteListPath = null;

        private Font defaultFont = new Font("Segoe UI", 9.5f);

        private Brush progressBrush = new SolidBrush(Color.FromArgb(6, 176, 37));

        private float slideOffset = 0;

        private bool busy = false;

        #endregion

        public PluginForm()
        {
            InitializeComponent();
        }

        #region Private methods

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
                    listBox.Invalidate();
                }
            }
        }

        private void MergeItem(BatchMergeJobItem batchMergeJobItem)
        {
            busy = true;

            Invoke(new Action(() =>
            {
                ToggleButtons(false);
                listBox.TopIndex = listBox.Items.Count - 1;
            }));

            fFMPEG.Progress += (object _sender, ProgressEventArgs _e) =>
            {
                Invoke(new Action(() =>
                {
                    batchMergeJobItem.Progress = _e.ProgressPercentage > 0 ? _e.ProgressPercentage / 100f : 0f;
                }));
            };

            fFMPEG.Completed += (object __sender, CompletedEventArgs __e) =>
            {
                busy = false;
                
                Invoke(new Action(() =>
                {
                    ToggleButtons(true);
                }));

                if (!__e.Success)
                {
                    Invoke(new Action(() =>
                    {
                        batchMergeJobItem.Status = BatchMergeJobItem.JobStatus.Error;
                        listBox.Invalidate();
                    }));

                    return;
                }

                Invoke(new Action(() =>
                {
                    batchMergeJobItem.Status = BatchMergeJobItem.JobStatus.Success;
                    batchMergeJobItem.Progress = 1f;
                    listBox.Invalidate();
                }));
            };

            batchMergeJobItem.Status = BatchMergeJobItem.JobStatus.Started;
            listBox.Invalidate();

            fFMPEG.Merge(batchMergeJobItem.Items.Select(item => item.FileName).ToList(), batchMergeJobItem.OutputName);
        }

        private void MergeAll()
        {
            List<BatchMergeJobItem> jobs = listBox.Items.Cast<BatchMergeJobItem>().ToList();
            StreamWriter streamWriter = !string.IsNullOrEmpty(deleteListPath) && checkBoxSaveDeleteList.Checked ? new StreamWriter(deleteListPath, true, System.Text.Encoding.UTF8) : null;

            Task.Run(() =>
            {
                foreach (BatchMergeJobItem batchMergeJobItem in jobs)
                {
                    MergeItem(batchMergeJobItem);
                    while (busy)
                    {
                        Thread.Sleep(100);
                    }

                    if (streamWriter != null)
                    {
                        foreach (BatchMergeFileItem batchMergeFileItem in batchMergeJobItem.Items)
                        {
                            streamWriter.WriteLine(Path.GetFileName(batchMergeFileItem.FileName));
                        }
                    }

                    Invoke(new Action(() =>
                    {
                        progressBar.Value++;
                        Invalidate();
                    }));
                }

                Invoke(new Action(() =>
                {
                    progressBar.Hide();

                    MessageBox.Show(
                        Resources.JobQueueCompleted,
                        Resources.JobQueueCompletedTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    streamWriter?.Dispose();
                }));
            });
        }

        private void ToggleButtons(bool state)
        {
            buttonAddJob.Enabled = state;
            buttonRemoveJob.Enabled = state;
            buttonMergeAll.Enabled = state;
            buttonMergeSelected.Enabled = state;
            buttonSetDeleteList.Enabled = state;
            checkBoxSaveDeleteList.Enabled = state;
        }

        private void SetDeleteListPath()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = Resources.DeleteListFilter;
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
            listBox.Invalidate();
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (busy) return;

            EditJob(listBox.SelectedIndex);
        }

        private void buttonMergeSelected_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Maximum = listBox.Items.Count;
            progressBar.Show();

            ToggleButtons(false);
            MergeItem(listBox.SelectedItem as BatchMergeJobItem);
        }

        private void buttonMergeAll_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Maximum = listBox.Items.Count;
            progressBar.Show();

            ToggleButtons(false);
            MergeAll();
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (busy) return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (busy) return;

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

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            Graphics g = e.Graphics;

            BatchMergeJobItem batchMergeJobItem = listBox.Items[e.Index] as BatchMergeJobItem;
            g.FillRectangle(e.Index == listBox.SelectedIndex ? SystemBrushes.Highlight : Brushes.White, e.Bounds);

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

        #endregion

    }
}
