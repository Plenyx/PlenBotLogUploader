using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings;

internal sealed class ApplicationSettingsGw2Bot
{
    [JsonProperty("enabled")]
    internal bool Enabled { get; set; }

    [JsonProperty("apiKey")]
    internal string ApiKey { get; set; } = "";

    [JsonProperty("selectedTeamId")]
    internal int TeamId { get; set; }

    [JsonProperty("sendOnSuccessOnly")]
    internal bool SendOnSuccessOnly { get; set; }
}
