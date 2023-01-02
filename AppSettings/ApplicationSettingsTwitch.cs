using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsTwitch
    {
        [JsonProperty("channelname")]
        internal string ChannelName { get; set; } = "";

        [JsonProperty("commands")]
        internal ApplicationSettingsTwitchCommands Commands { get; set; } = new();

        [JsonProperty("connectToTwitch")]
        internal bool ConnectToTwitch { get; set; } = false;

        [JsonProperty("custom")]
        internal ApplicationSettingsTwitchCustom Custom { get; set; } = new();
    }
}
