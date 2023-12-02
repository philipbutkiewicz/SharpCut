using SharpCutCommon.Util;
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
    public partial class ChangelogForm : Form
    {
        public ChangelogForm()
        {
            InitializeComponent();
        }

        private void ChangelogForm_Shown(object sender, EventArgs e)
        {
            Task.Run(GetChangelog);
        }

        private void GetChangelog()
        {
            string changelog = Updater.GetChangelog();

            Invoke(new Action(() =>
            {
                textBox.Text = string.IsNullOrEmpty(changelog) ? SharpCutCommon.Properties.Resources.ChangelogError : changelog;
            }));
        }
    }
}
