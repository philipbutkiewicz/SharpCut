using SharpCutCommon.Video;
using System;
using System.Collections.Generic;

namespace SharpCutCommon.Plugins
{
    public interface ISharpCutPlugin
    {
        /// <summary>
        /// Returns plugin information.
        /// </summary>
        /// <returns></returns>
        SharpCutPluginInfo GetPluginInfo();

        /// <summary>
        /// Returns named actions the plugin can perform.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, Action> GetPluginActions();

        /// <summary>
        /// Plugin initialization routine.
        /// Called by SharpCut when the project is loaded.
        /// </summary>
        /// <param name="project"></param>
        void Initialize(Project project);

        /// <summary>
        /// Plugin cleanup routine.
        /// Called by SharpCut when the project is closed.
        /// </summary>
        void Uninitialize();

        /// <summary>
        /// Main plugin execution routine.
        /// Called by SharpCut when the user selects the plugin in the main menu.
        /// </summary>
        void Execute();

        /// <summary>
        /// Plugin configuration routine.
        /// Executed by SharpCut when the user clicks "Configure" in the Plugin Manager.
        /// </summary>
        /// <returns>true if the plugin can be configured, otherwise false</returns>
        bool Configure();
    }
}
