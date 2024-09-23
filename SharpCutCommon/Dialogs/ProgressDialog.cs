using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpCutCommon
{
    public partial class ProgressDialog : Form
    {
        public string ProgressTitle = Properties.Resources.GenericPleaseWait;

        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void SetProgress(int progress, TimeSpan currentTime, TimeSpan totalTime)
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = progress < 0 ? 0 : (progress > 100 ? 100 : progress);
                labelProgress.Text = $"{Properties.Resources.ProgressPercent} {progressBar.Value}%";

                string details = $"{currentTime} / {totalTime}\r\n";
                textBox.AppendText(details);
                textBox.ScrollToCaret();
            });
        }

        public void Abort()
        {
            Invoke((MethodInvoker)delegate
            {
                DialogResult = DialogResult.Abort;
                Close();
            });
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = ProgressTitle;
        }

        private void buttonShowDetails_Click(object sender, EventArgs e)
        {
            buttonShowDetails.Visible = false;
            Height = 410;
            textBox.Visible = true;
            panelProgress.Visible = false;
        }
    }
}
