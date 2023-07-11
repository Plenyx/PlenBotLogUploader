using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class ExtBarrierStats
    {
        [JsonProperty("outgoingBarrier")]
        internal OutgoingBarrier[] OutgoingBarrier { get; set; }
    }
}
