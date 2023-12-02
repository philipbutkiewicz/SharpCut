using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCutCommon.Plugins
{
    public interface ISharpCutPlugin
    {
        SharpCutPluginInfo GetPluginInfo();

        void InitPlugin(Project project);

        void DisposePlugin();

        void ShowPluginConfiguration();
    }
}
