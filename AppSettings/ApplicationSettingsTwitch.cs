using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsTwitch
    {
        [JsonProperty("channelname")]
        internal string ChannelName { get; set; } = string.Empty;

        [JsonProperty("commands")]
        internal ApplicationSettingsTwitchCommands Commands { get; set; } = new ApplicationSettingsTwitchCommands();

        [JsonProperty("connectToTwitch")]
        internal bool ConnectToTwitch { get; set; } = false;

        [JsonProperty("custom")]
        internal ApplicationSettingsTwitchCustom Custom { get; set; } = new ApplicationSettingsTwitchCustom();
    }
}
