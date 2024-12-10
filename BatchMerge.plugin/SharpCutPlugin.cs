using SharpCutCommon.Plugins;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BatchMerge.plugin
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
                Name = "Batch merge",
                Author = "Conflagrate",
                Version = "1.4.12.0",
                Category = SharpCutPluginInfo.PluginCategory.MediaUtility
            };
        }

        public Dictionary<string, Action> GetPluginActions()
        {
            return null;
        }

        public void Initialize(Project project)
        {

        }

        public void Uninitialize()
        {
        }

        public void Execute()
        {
            using (PluginForm pluginForm = new PluginForm())
            {
                pluginForm.ShowDialog();
            }
        }

        public bool Configure()
        {
            return false;
        }
    }
}