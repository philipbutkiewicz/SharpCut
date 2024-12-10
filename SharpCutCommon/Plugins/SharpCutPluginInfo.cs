namespace SharpCutCommon.Plugins
{
    public class SharpCutPluginInfo
    {
        #region Enums

        public enum PluginCategory
        {
            General,
            MediaUtility,
            Analysis,
            Cutting
        };

        #endregion

        #region Props

        /// <summary>
        /// The name of the plugin.
        /// </summary>
        public string Name = "SharpCut Plugin";

        /// <summary>
        /// The version of the plugin.
        /// </summary>
        public string Version = "v1.0.0.0";

        /// <summary>
        /// The author of the plugin.
        /// </summary>
        public string Author = "Plugin Author";

        /// <summary>
        /// The category of the plugin.
        /// </summary>
        public PluginCategory Category = PluginCategory.General;

        /// <summary>
        /// Can the plugin be executed?
        /// </summary>
        public bool CanExecute = true;

        #endregion
    }
}
