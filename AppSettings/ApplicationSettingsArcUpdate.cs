using Hardstuck.GuildWars2;
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

        [JsonProperty("useAL")]
        internal bool UseAddonLoader { get; set; } = false;

        [JsonProperty("lastUpdateCheck")]
        internal DateTime LastUpdateCheck { get; set; } = DateTime.Now;
    }
}
