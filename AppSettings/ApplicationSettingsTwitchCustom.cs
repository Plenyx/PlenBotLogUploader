using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsTwitchCustom
    {
        [JsonProperty("enabled")]
        internal bool Enabled { get; set; } = false;

        [JsonProperty("name")]
        internal string Name { get; set; } = string.Empty;

        [JsonProperty("oauth")]
        internal string OAuthPassword { get; set; } = string.Empty;
    }
}
