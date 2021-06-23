using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsTwitch
    {
        [JsonProperty("connectToTwitch")]
        public bool ConnectToTwitch { get; set; } = false;

        [JsonProperty("channelname")]
        public string ChannelName { get; set; } = "";

        [JsonProperty("custom")]
        public ApplicationSettingsTwitchCustom Custom { get; set; } = new ApplicationSettingsTwitchCustom();

        [JsonProperty("commands")]
        public ApplicationSettingsTwitchCommands Commands { get; set; } = new ApplicationSettingsTwitchCommands();
    }
}
