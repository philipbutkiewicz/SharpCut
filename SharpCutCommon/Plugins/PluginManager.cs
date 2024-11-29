using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SharpCutCommon.Plugins
{
    public class PluginManager
    {
        public static List<ISharpCutPlugin> Plugins = new List<ISharpCutPlugin>();

        public static void LoadPlugins(Project project)
        {
            string[] pluginFiles = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "*.plugin.dll");
            foreach (string pluginFile in pluginFiles)
            {
                Assembly assembly = Assembly.LoadFile(pluginFile);
                
                Type sharpCutPluginType = assembly.GetType($"{Path.GetFileName(pluginFile).Replace(".dll", "")}.SharpCutPlugin");
                ISharpCutPlugin sharpCutPlugin = Activator.CreateInstance(sharpCutPluginType) as ISharpCutPlugin;
    
                sharpCutPlugin.InitPlugin(project);

                Plugins.Add(sharpCutPlugin);
            }
        }

        public static void UnloadPlugins()
        {
            foreach (ISharpCutPlugin sharpCutPlugin in Plugins)
            {
                sharpCutPlugin.DisposePlugin();
            }

            Plugins.Clear();
        }
    }
}
