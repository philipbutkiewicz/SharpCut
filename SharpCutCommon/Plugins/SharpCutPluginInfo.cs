using Newtonsoft.Json;
using System;

namespace SharpCutCommon.Plugins
{
    [Serializable]
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
        [JsonProperty("name")]
        public string Name = "SharpCut Plugin";

        /// <summary>
        /// The version of the plugin.
        /// </summary>
        [JsonProperty("version")]
        public string Version = "v1.0.0.0";

        /// <summary>
        /// The author of the plugin.
        /// </summary>
        [JsonProperty("author")]
        public string Author = "Plugin Author";

        /// <summary>
        /// The category of the plugin.
        /// </summary>
        [JsonProperty("category")]
        public PluginCategory Category = PluginCategory.General;

        /// <summary>
        /// Can the plugin be executed?
        /// </summary>
        [JsonProperty("canExecute")]
        public bool CanExecute = true;

        #endregion


        #region Public methods

        /// <summary>
        /// Serializes this object and returns result as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}
