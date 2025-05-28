using Newtonsoft.Json;
using ZLinq;

namespace PlenBotLogUploader.DpsReport.ExtraJson;

internal class StatsBarrier
{
    [JsonProperty("outgoingBarrier")]
    internal OutgoingBarrier[] OutgoingBarrier { get; set; }

    internal long TotalBarrier => (OutgoingBarrier?.Length ?? 0) > 0 ? OutgoingBarrier[0].Barrier : 0;

    [JsonProperty("outgoingBarrierAllies")]
    internal OutgoingBarrier[][] OutgoingBarrierAllies { get; set; }

    internal long TotalBarrierOnSquad
    {
        get
        {
            long result = 0;
            foreach (var squadMember in OutgoingBarrierAllies.AsValueEnumerable())
            {
                result += (squadMember?.Length ?? 0) > 0 ? squadMember[0].Barrier : 0;
            }
            return result;
        }
    }
}
