using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Bot
{
    internal sealed class Gw2BotAddReport
    {
        [JsonProperty("dpsreport_url")]
        internal string LogLink { get; set; }
    }
}
