using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsBarrier
    {
        [JsonProperty("outgoingBarrier")]
        internal OutgoingBarrier[] OutgoingBarrier { get; set; }
    }
}
