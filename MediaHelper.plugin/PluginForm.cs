using System;
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

        private void PluginForm_DoubleClick(object sender, EventArgs e)
        {
            modifier = !modifier;
            string modifierText = modifier ? " [!]" : "";
            Text = $"Media Helper{modifierText}";
        }

        private void buttonPreviewBrowser_Click(object sender, EventArgs e)
        {
            using (PreviewBrowserForm previewBrowserForm = new PreviewBrowserForm())
            {
                previewBrowserForm.LoadFromList = modifier;
                previewBrowserForm.ShowDialog();
            }
        }
    }
}
