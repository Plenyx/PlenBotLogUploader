using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsBarrier
    {
        [JsonProperty("outgoingBarrier")]
        internal OutgoingBarrier[] OutgoingBarrier { get; set; }

        [JsonProperty("outgoingBarrierAllies")]
        internal OutgoingBarrier[][] OutgoingBarrierAllies { get; set; }

        internal long TotalBarrierOnSquad
        {
            get
            {
                long result = 0;
                foreach (var squadMember in OutgoingBarrierAllies.AsSpan())
                {
                    foreach (var squadMemberPhase in squadMember.AsSpan())
                    {
                        result += squadMemberPhase.Barrier;
                    }
                }
                return result;
            }
        }
    }
}
