using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsGW2Bot
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = false;

        [JsonProperty("apiKey")]
        public string APIKey { get; set; } = "";

        [JsonProperty("selectedTeamId")]
        public int SelectedTeamId { get; set; } = 0;

        [JsonProperty("sendOnSuccessOnly")]
        public bool SendOnSuccessOnly { get; set; } = false;
    }
}
