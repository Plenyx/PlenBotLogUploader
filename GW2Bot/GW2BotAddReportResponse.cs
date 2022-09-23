using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2Bot
{
    internal sealed class GW2BotAddReportResponse
    {
        [JsonProperty("detail")]
        internal object Detail { get; set; }
    }
}
