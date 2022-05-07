using Newtonsoft.Json;
using PlenBotLogUploader.Tools;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsSession
    {
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = "Log session";

        [JsonProperty("onlySuccess")]
        public bool OnlySuccess { get; set; } = true;

        [JsonProperty("saveToFile")]
        public bool SaveToFile { get; set; } = true;

        [JsonProperty("makeWvWSummaryEmbed")]
        public bool MakeWvWSummaryEmbed { get; set; } = true;

        [JsonProperty("sort")]
        public LogSessionSortBy Sort { get; set; } = LogSessionSortBy.Wing;

        [JsonProperty("supressWebhooks")]
        public bool SupressWebhooks { get; set; } = true;
    }
}
