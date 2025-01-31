using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Bot;

internal sealed class Gw2BotAddReportResponse
{
    [JsonProperty("detail")]
    internal object Detail { get; set; }
}
