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
    public partial class UpdateDialog : Form
    {
        public string FileName = "";

        private string fileURL = "";

        private WebClient wc = new WebClient();

        public UpdateDialog(string _fileURL)
        {
            fileURL = _fileURL;
            InitializeComponent();
        }

        private void DownloadFile()
        {
            string downloadDir = Path.Combine(DirUtil.GetWorkingDir(), "Downloads");
            if (!Directory.Exists(downloadDir))
            {
                Directory.CreateDirectory(downloadDir);
            }

            FileName = Path.Combine(downloadDir, "update.exe");

            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

            try
            {
                wc.DownloadFileAsync(new Uri(fileURL), FileName);
            }
            catch
            {
                MessageBox.Show(Resources.UpdateDownloadError, Resources.GenericErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string downloadDir = Path.Combine(DirUtil.GetWorkingDir(), "Downloads");

            if (e.Cancelled) return;

            Invoke(new Action(delegate
            {
                DialogResult = DialogResult.OK;
                Close();
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

        private void UpdateDialog_Shown(object sender, EventArgs e)
        {
            DownloadFile();
        }
    }
}
