using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class ExtBarrierStats
    {
        [JsonProperty("outgoingBarrierAllies")]
        internal OutgoingBarrierAlly[][] OutgoingBarrierAllies { get; set; }

        [JsonProperty("outgoingBarrier")]
        internal OutgoingBarrier[] OutgoingBarrier { get; set; } 
    }
}
