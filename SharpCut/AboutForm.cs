using SharpCutCommon.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            labelVersion.Text = $"{SharpCutCommon.Properties.Resources.Version}{Assembly.GetExecutingAssembly().GetName().Version}";
            labelBuildDate.Text = $"{SharpCutCommon.Properties.Resources.BuildDate}{(File.Exists("Resources\\BuildDate.txt") ? File.ReadAllText("Resources\\BuildDate.txt") : "Unknown")}";

            if (Settings.Default.IsBetaBuild)
            {
                labelVersion.Text += " (BETA)";
            }
        }

        private void linkLabelWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://conflagrate.co/sharpcut.html");
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
