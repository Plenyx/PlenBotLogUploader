using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2Bot
{
    internal sealed class GW2BotAddReport
    {
        [JsonProperty("dpsreport_url")]
        internal string LogLink { get; set; }
    }
}
