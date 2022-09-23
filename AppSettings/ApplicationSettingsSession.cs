using Newtonsoft.Json;
using PlenBotLogUploader.Tools;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsSession
    {
        [JsonProperty("message")]
        internal string Message { get; set; } = string.Empty;

        [JsonProperty("name")]
        internal string Name { get; set; } = "Log session";

        [JsonProperty("onlySuccess")]
        internal bool OnlySuccess { get; set; } = true;

        [JsonProperty("saveToFile")]
        internal bool SaveToFile { get; set; } = true;

        [JsonProperty("makeWvWSummaryEmbed")]
        internal bool MakeWvWSummaryEmbed { get; set; } = true;

        [JsonProperty("sort")]
        internal LogSessionSortBy Sort { get; set; } = LogSessionSortBy.Wing;

        [JsonProperty("supressWebhooks")]
        internal bool SupressWebhooks { get; set; } = true;
    }
}
