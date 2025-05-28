using Newtonsoft.Json;
using ZLinq;

namespace PlenBotLogUploader.DpsReport.ExtraJson;

internal class StatsHealing
{
    [JsonProperty("outgoingHealing")]
    internal OutgoingHealing[] OutgoingHealing { get; set; }

    internal long TotalHealing => (OutgoingHealing?.Length ?? 0) > 0 ? OutgoingHealing[0].Healing : 0;

    [JsonProperty("outgoingHealingAllies")]
    internal OutgoingHealing[][] OutgoingHealingAllies { get; set; }

    internal long TotalHealingOnSquad
    {
        get
        {
            long result = 0;
            foreach (var squadMember in OutgoingHealingAllies.AsValueEnumerable())
            {
                result += (squadMember?.Length ?? 0) > 0 ? squadMember[0].Healing : 0;
            }
            return result;
        }
    }
}
