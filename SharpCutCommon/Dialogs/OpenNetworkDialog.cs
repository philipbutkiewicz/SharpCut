using SharpCutCommon.Properties;
using SharpCutCommon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpCutCommon.Dialogs
{
    public partial class OpenNetworkDialog : Form
    {
        public string URL = "";

        private WebClient wc = new WebClient();

        public OpenNetworkDialog()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Uri uri = new Uri(textBoxURL.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (!checkBoxDownload.Checked)
            {
                DialogResult = DialogResult.OK;
                URL = textBoxURL.Text;
                Close();
            }
            else
            {
                progressBar.Value = 0;
                labelDownloadStatus.Text = Resources.GenericPleaseWait;

                Height = 260;
                textBoxURL.Enabled = false;
                buttonOpen.Enabled = false;

                DownloadFile();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string downloadDir = Path.Combine(DirUtil.GetWorkingDir(), "Downloads");
                string targetFileName = Path.GetFileName(textBoxURL.Text);
                if (File.Exists(Path.Combine(downloadDir, targetFileName)))
                {
                    File.Delete(Path.Combine(downloadDir, targetFileName));
                }
            }
            catch
            { }

            wc.CancelAsync();

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DownloadFile()
        {
            string downloadDir = Path.Combine(DirUtil.GetWorkingDir(), "Downloads");
            if (!Directory.Exists(downloadDir))
            {
                Directory.CreateDirectory(downloadDir);
            }

            string targetFileName = Path.GetFileName(textBoxURL.Text);
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

            try
            {
                wc.DownloadFileAsync(new Uri(textBoxURL.Text), Path.Combine(downloadDir, targetFileName));
            }
            catch
            {
                MessageBox.Show(Resources.DownloadFileError, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Height = 200;
                textBoxURL.Enabled = true;
                buttonOpen.Enabled = true;
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string downloadDir = Path.Combine(DirUtil.GetWorkingDir(), "Downloads");

            if (e.Cancelled) return;

            Invoke(new Action(delegate
            {
                DialogResult = DialogResult.OK;
                URL = Path.Combine(downloadDir, Path.GetFileName(textBoxURL.Text));
            }));
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            long mbReceived = e.BytesReceived > 0 ? e.BytesReceived / 1024 / 1024 : 0;
            long mbTotal = e.TotalBytesToReceive > 0 ? e.TotalBytesToReceive / 1024 / 1024 : 0;
            try
            {
                Invoke(new Action(delegate
                {
                    labelDownloadStatus.Text = $"{Resources.Downloading} {mbReceived} MiB / {mbTotal} MiB ({e.ProgressPercentage}%)...";
                    progressBar.Value = e.ProgressPercentage;
                }));
            }
            catch
            { }
        }
    }
}
