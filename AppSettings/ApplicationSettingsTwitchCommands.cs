using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsTwitchCommands
    {
        [JsonProperty("buildEnabled")]
        internal bool BuildEnabled { get; set; } = false;

        [JsonProperty("buildCommand")]
        internal string BuildCommand { get; set; } = "!build";

        [JsonProperty("smartBuildRecognition")]
        internal bool BuildSmartRecognition { get; set; } = true;

        [JsonProperty("ignEnabled")]
        internal bool IgnEnabled { get; set; } = false;

        [JsonProperty("ignCommand")]
        internal string IgnCommand { get; set; } = "!ign";

        [JsonProperty("lastLogEnabled")]
        internal bool LastLogEnabled { get; set; } = false;

        [JsonProperty("lastLogCommand")]
        internal string LastLogCommand { get; set; } = "!lastlog";

        [JsonProperty("pullCounterEnabled")]
        internal bool PullCounterEnabled { get; set; } = true;

        [JsonProperty("pullCounterCommand")]
        internal string PullCounterCommand { get; set; } = "!pulls";

        [JsonProperty("songEnabled")]
        internal bool SongEnabled { get; set; } = false;

        [JsonProperty("songCommand")]
        internal string SongCommand { get; set; } = "!song";

        [JsonProperty("smartSongRecognition")]
        internal bool SongSmartRecognition { get; set; } = true;

        [JsonProperty("uploaderEnabled")]
        internal bool UploaderEnabled { get; set; } = true;

        [JsonProperty("uploaderCommand")]
        internal string UploaderCommand { get; set; } = "!uploader";
    }
}
