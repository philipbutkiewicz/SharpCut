using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SharpCutCommon.Plugins
{
    public class PluginManager
    {
        #region Static properties

        public static string PluginStoragePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SharpCut");

        public static List<ISharpCutPlugin> Plugins = new List<ISharpCutPlugin>();

        #endregion

        #region Public methods

        public static void LoadPlugins(Project project)
        {
            string[] pluginInstallDirs = Directory.GetDirectories(PluginStoragePath);
            foreach (string pluginInstallDir in pluginInstallDirs)
            {
                string[] pluginFiles = Directory.GetFiles(pluginInstallDir, "*.plugin.dll");
                foreach (string pluginFile in pluginFiles)
                {
                    Assembly assembly = Assembly.LoadFile(pluginFile);

                    Type sharpCutPluginType = assembly.GetType($"{Path.GetFileName(pluginFile).Replace(".dll", "")}.SharpCutPlugin");
                    ISharpCutPlugin sharpCutPlugin = Activator.CreateInstance(sharpCutPluginType) as ISharpCutPlugin;

                    sharpCutPlugin.Initialize(project);

                    Plugins.Add(sharpCutPlugin);
                }
            }
        }

        public static void UnloadPlugins()
        {
            foreach (ISharpCutPlugin sharpCutPlugin in Plugins)
            {
                sharpCutPlugin.Uninitialize();
            }

            Plugins.Clear();
        }

        #endregion
    }
}
