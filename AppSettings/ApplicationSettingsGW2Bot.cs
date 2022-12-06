using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsGw2Bot
    {
        [JsonProperty("enabled")]
        internal bool Enabled { get; set; } = false;

        [JsonProperty("apiKey")]
        internal string APIKey { get; set; } = string.Empty;

        [JsonProperty("selectedTeamId")]
        internal int SelectedTeamId { get; set; } = 0;

        [JsonProperty("sendOnSuccessOnly")]
        internal bool SendOnSuccessOnly { get; set; } = false;
    }
}
