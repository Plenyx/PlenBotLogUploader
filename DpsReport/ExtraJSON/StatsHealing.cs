using Newtonsoft.Json;
using System.Linq;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsHealing
    {
        [JsonProperty("outgoingHealing")]
        internal OutgoingHealing[] OutgoingHealing { get; set; }

        [JsonProperty("outgoingHealingAllies")]
        internal OutgoingHealing[][] OutgoingHealingAllies { get; set; }

        internal long TotalHealingOnSquad => OutgoingHealingAllies.Sum(x => x.Sum(y => y.Healing));
    }
}
