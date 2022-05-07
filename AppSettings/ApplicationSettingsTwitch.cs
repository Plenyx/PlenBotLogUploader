using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsTwitch
    {
        [JsonProperty("channelname")]
        public string ChannelName { get; set; } = string.Empty;

        [JsonProperty("commands")]
        public ApplicationSettingsTwitchCommands Commands { get; set; } = new ApplicationSettingsTwitchCommands();

        [JsonProperty("connectToTwitch")]
        public bool ConnectToTwitch { get; set; } = false;

        [JsonProperty("custom")]
        public ApplicationSettingsTwitchCustom Custom { get; set; } = new ApplicationSettingsTwitchCustom();
    }
}
