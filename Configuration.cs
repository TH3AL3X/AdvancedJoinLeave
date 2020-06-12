using Rocket.API;
using System.Collections.Generic;
using System.Reflection;

namespace Main
{
    public class Configuration : IRocketPluginConfiguration
    {
        public string joinicon;
        public string leaveicon;

        public bool richjoin;
        public bool richleave;
        public void LoadDefaults()
        {
            joinicon = "https://www.clipartmax.com/png/middle/258-2580323_cli-global-society-home-new-york-times-icon.png";
            richjoin = false;
            leaveicon = "https://www.clipartmax.com/png/middle/258-2580323_cli-global-society-home-new-york-times-icon.png";
            richleave = false;
        }
    }
}
