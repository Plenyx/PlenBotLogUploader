using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings;

internal sealed class ApplicationSettingsTwitch
{
    [JsonProperty("channelname")]
    internal string ChannelName { get; set; } = "";

    [JsonProperty("connectToTwitch")]
    internal bool ConnectToTwitch { get; set; }

    [JsonProperty("custom")]
    internal ApplicationSettingsTwitchCustom Custom { get; set; } = new();
}
