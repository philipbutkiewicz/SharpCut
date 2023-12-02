using SharpCutCommon.Plugins;
using SharpCutCommon.Video;
using System.IO;
using System.Reflection;
using System;

namespace MediaHelper.plugin
{
    public class SharpCutPlugin : ISharpCutPlugin
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public SharpCutPluginInfo GetPluginInfo()
        {
            return new SharpCutPluginInfo()
            {
                Name = "Media Helper",
                Author = "bagnz0r",
                Version = "1.2.0.0"
            };
        }

        public void InitPlugin(Project project)
        {
 
        }

        public void DisposePlugin()
        {
        }

        public void ShowPluginConfiguration()
        {
            using (PluginForm pluginForm = new PluginForm())
            {
                pluginForm.ShowDialog();
            }
        }
    }
}
