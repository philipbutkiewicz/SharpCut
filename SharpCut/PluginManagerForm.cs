using SharpCutCommon.Plugins;
using System;
using System.Windows.Forms;

namespace SharpCut
{
    public partial class PluginManagerForm : Form
    {
        public PluginManagerForm()
        {
            InitializeComponent();
        }

        private void PluginManagerForm_Load(object sender, EventArgs e)
        {
            PopulatePluginList();
        }

        private void PopulatePluginList()
        {
            foreach (ISharpCutPlugin plugin in PluginManager.Plugins)
            {
                SharpCutPluginInfo pluginInfo = plugin.GetPluginInfo();
                listBoxPlugins.Items.Add($"{pluginInfo.Name} v{pluginInfo.Version} ({pluginInfo.Author})");
            }
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            if (listBoxPlugins.SelectedIndex <= -1 || listBoxPlugins.SelectedIndex > PluginManager.Plugins.Count - 1) return;

            if (!PluginManager.Plugins[listBoxPlugins.SelectedIndex].Configure())
            {
                MessageBox.Show(
                    SharpCutCommon.Properties.Resources.PluginHasNoConfiguration,
                    SharpCutCommon.Properties.Resources.PluginHasNoConfigurationTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
