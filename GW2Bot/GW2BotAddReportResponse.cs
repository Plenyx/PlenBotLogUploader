using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2Bot
{
    public class GW2BotAddReportResponse
    {
        [JsonProperty("detail")]
        public object Detail { get; set; }
    }
}
