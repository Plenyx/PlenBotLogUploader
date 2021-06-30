using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsTwitchCommands
    {
        [JsonProperty("buildEnabled")]
        public bool BuildEnabled { get; set; } = false;

        [JsonProperty("buildCommand")]
        public string BuildCommand { get; set; } = "!build";

        [JsonProperty("ignEnabled")]
        public bool IGNEnabled { get; set; } = false;

        [JsonProperty("ignCommand")]
        public string IGNCommand { get; set; } = "!ign";

        [JsonProperty("lastLogEnabled")]
        public bool LastLogEnabled { get; set; } = false;

        [JsonProperty("lastLogCommand")]
        public string LastLogCommand { get; set; } = "!lastlog";

        [JsonProperty("pullCounterEnabled")]
        public bool PullCounterEnabled { get; set; } = true;

        [JsonProperty("pullCounterCommand")]
        public string PullCounterCommand { get; set; } = "!pulls";

        [JsonProperty("songEnabled")]
        public bool SongEnabled { get; set; } = false;

        [JsonProperty("songCommand")]
        public string SongCommand { get; set; } = "!song";

        [JsonProperty("smartSongRecognition")]
        public bool SmartRecognition { get; set; } = true;

        [JsonProperty("uploaderEnabled")]
        public bool UploaderEnabled { get; set; } = true;

        [JsonProperty("uploaderCommand")]
        public string UploaderCommand { get; set; } = "!uploader";
    }
}
