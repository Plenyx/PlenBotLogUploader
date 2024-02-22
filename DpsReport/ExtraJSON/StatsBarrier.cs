using Newtonsoft.Json;
using System.Linq;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsBarrier
    {
        [JsonProperty("outgoingBarrier")]
        internal OutgoingBarrier[] OutgoingBarrier { get; set; }

        [JsonProperty("outgoingBarrierAllies")]
        internal OutgoingBarrier[][] OutgoingBarrierAllies { get; set; }

        internal long TotalBarrierOnSquad => OutgoingBarrierAllies.Sum(x => x.Sum(y => y.Barrier));
    }
}
