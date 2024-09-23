using SharpCutCommon.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SharpCut
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = $"{Resources.Version}{Assembly.GetExecutingAssembly().GetName().Version}";
            labelBuildDate.Text = $"{Resources.BuildDate}{(File.Exists("Resources\\BuildDate.txt") ? File.ReadAllText("Resources\\BuildDate.txt") : "???")}";

            if (Settings.Default.IsBetaBuild)
            {
                labelVersion.Text += " (BETA)";
            }

            creditsControl.Credits = Resources.Credits.Replace("\r\n", "\n").Split(new char[] { '\n' }).ToList();
        }

        private void linkLabelWebsite_Click(object sender, EventArgs e)
        {
            Process.Start(Resources.WebsiteURL);
        }

        private void buttonChangelog_Click(object sender, EventArgs e)
        {
            using (ChangelogForm changelogForm = new ChangelogForm())
            {
                changelogForm.ShowDialog();
            }
        }
    }
}
