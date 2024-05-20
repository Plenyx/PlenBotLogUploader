using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsArcUpdate
    {
        [JsonProperty("enabled")]
        internal bool Enabled { get; set; } = false;

        [JsonProperty("notifications")]
        internal bool Notifications { get; set; } = true;

        [JsonProperty("chainLoad")]
        internal ApplicationSettingsArcUpdateChainLoad ChainLoad { get; set; }

        internal string ArcPathChainLoaded => ChainLoad switch
        {
            ApplicationSettingsArcUpdateChainLoad.AddonLoader => @"\addons\arcdps\gw2addon_arcdps.dll",
            ApplicationSettingsArcUpdateChainLoad.Nexus => @"\addons\arcdps.dll",
            _ => @"\d3d11.dll",
        };

        [JsonProperty("lastUpdateCheck")]
        internal DateTime LastUpdateCheck { get; set; } = DateTime.Now;
    }
}
