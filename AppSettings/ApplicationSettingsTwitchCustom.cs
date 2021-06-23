using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsTwitchCustom
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("oauth")]
        public string OAuthPassword { get; set; } = "";
    }
}
