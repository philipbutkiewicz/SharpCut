using SharpCutCommon.Plugins;
using SharpCutCommon.Video;
using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace MediaHelper.plugin
{
    public class SharpCutPlugin : ISharpCutPlugin
    {
        #region Props

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

        #endregion

        #region Public methods

        public SharpCutPluginInfo GetPluginInfo()
        {
            return new SharpCutPluginInfo()
            {
                Name = "Media helper",
                Author = "Conflagrate",
                Version = "1.4.12.0",
                Category = SharpCutPluginInfo.PluginCategory.MediaUtility,
                CanExecute = false
            };
        }

        public Dictionary<string, Action> GetPluginActions()
        {
            Dictionary<string, Action> actions = new Dictionary<string, Action>();

            actions.Add(Properties.Resources.BrowsePreviewsFromDirectory, () =>
            {
                BrowsePreviews();
            });
            actions.Add(Properties.Resources.BrowsePreviewsFromList, () =>
            {
                BrowsePreviews(true);
            });

            return actions;
        }

        public void Initialize(Project project)
        {
        }

        public void Uninitialize()
        {
        }

        public void Execute()
        {
        }

        public bool Configure()
        {
            return false;
        }

        #endregion

        #region Private methods

        private void BrowsePreviews(bool fromList = false)
        {
            using (PreviewBrowserForm previewBrowserForm = new PreviewBrowserForm())
            {
                previewBrowserForm.LoadFromList = fromList;
                previewBrowserForm.ShowDialog();
            }
        }

        #endregion
    }
}
