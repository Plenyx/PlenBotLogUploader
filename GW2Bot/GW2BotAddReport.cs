using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2Bot
{
    public class GW2BotAddReport
    {
        [JsonProperty("dpsreport_url")]
        public string LogLink { get; set; }
    }
}
