using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsBarrier
    {
        [JsonProperty("outgoingBarrier")]
        internal StatsBarrierOutgoingBarrier OutgoingBarrier { get; set; }
    }
}
