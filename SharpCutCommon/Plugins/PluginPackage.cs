using Newtonsoft.Json;
using SharpCompress.Archives;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SharpCutCommon.Plugins
{
    public class PluginPackage : IDisposable
    {
        #region Properties

        /// <summary>
        /// Plugin information.
        /// </summary>
        public SharpCutPluginInfo PluginInfo { get; private set; }

        #endregion

        #region Fields

        private IArchive archive;

        #endregion

        #region Constructor

        public PluginPackage(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            archive = ArchiveFactory.Open(fileName);
            PluginInfo = GetPluginInfo();
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            if (archive != null)
            {
                archive.Dispose();
            }
        }

        public void Install()
        {
            string installPath = Path.Combine(PluginManager.PluginStoragePath, PluginInfo.Name);
            if (Directory.Exists(installPath))
            {
                Directory.Delete(installPath, true);
            }
            else
            {
                Directory.CreateDirectory(installPath);
            }

            archive.ExtractToDirectory(installPath);
        }

        #endregion

        #region Private methods

        private SharpCutPluginInfo GetPluginInfo()
        {
            IArchiveEntry pluginInfoEntry = archive.Entries.Where(item => item.Key == "plugin.json").First();
            if (pluginInfoEntry == null || pluginInfoEntry.IsDirectory)
            {
                throw new Exception("Not a valid SharpCut plugin, plugin info missing.");
            }

            SharpCutPluginInfo pluginInfo;
            using (MemoryStream stream = new MemoryStream())
            {
                pluginInfoEntry.WriteTo(stream);
                pluginInfo = JsonConvert.DeserializeObject<SharpCutPluginInfo>(Encoding.UTF8.GetString(stream.ToArray()));
            }

            return pluginInfo;
        }

        #endregion
    }
}
