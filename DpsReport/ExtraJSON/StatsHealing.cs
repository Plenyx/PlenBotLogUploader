using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsHealing
    {
        [JsonProperty("outgoingHealing")]
        internal OutgoingHealing[] OutgoingHealing { get; set; }

        [JsonProperty("outgoingHealingAllies")]
        internal OutgoingHealing[][] OutgoingHealingAllies { get; set; }

        internal long TotalHealingOnSquad
        {
            get
            {
                long result = 0;
                foreach (var squadMember in OutgoingHealingAllies.AsSpan())
                {
                    foreach (var squadMemberPhase in squadMember.AsSpan())
                    {
                        result += squadMemberPhase.Healing;
                    }
                }
                return result;
            }
        }
    }
}
