using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpCut
{
    public partial class LicensesForm : Form
    {
        public LicensesForm()
        {
            InitializeComponent();
        }

        private void listBoxDependencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string licensePath = Path.Combine(Path.Combine(Program.AssemblyDirectory, "Resources"), Path.Combine("Licenses", $"{listBoxDependencies.Text}.txt"));
            if (File.Exists(licensePath))
            {
                textBoxLicense.Text = File.ReadAllText(licensePath);
                textBoxLicense.SelectionStart = 0;
                textBoxLicense.ScrollToCaret();
            }
        }
    }
}
