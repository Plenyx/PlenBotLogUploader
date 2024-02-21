using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsBarrierOutgoingBarrier
    {
        [JsonProperty("barrier")]
        internal long Barrier { get; set; }

        [JsonProperty("bps")]
        internal long BarrierPerSecond { get; set; }
    }
}
