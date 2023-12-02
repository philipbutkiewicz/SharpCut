using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaHelper.plugin
{
    public partial class PluginForm : Form
    {
        bool modifier = false;

        public PluginForm()
        {
            InitializeComponent();
        }

        private void PluginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void buttonPreviewBrowser_Click(object sender, EventArgs e)
        {
            PreviewBrowserForm previewBrowserForm = new PreviewBrowserForm();
            previewBrowserForm.LoadFromList = modifier;
            previewBrowserForm.Show();
        }

        private void PluginForm_DoubleClick(object sender, EventArgs e)
        {
            modifier = !modifier;
            string modifierText = modifier ? " [!]" : "";
            Text = $"Media Helper{modifierText}";
        }
    }
}
