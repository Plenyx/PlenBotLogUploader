using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsGW2Bot
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = false;

        [JsonProperty("apiKey")]
        public string APIKey { get; set; } = "";

        [JsonProperty("sendOnSuccessOnly")]
        public bool SendOnSuccessOnly { get; set; } = false;
    }
}
