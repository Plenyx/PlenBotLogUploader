using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class ExtHealingStats
    {
        [JsonProperty("outgoingHealingAllies")]
        internal OutgoingHealingAlly[][] OutgoingHealingAllies { get; set; }

        [JsonProperty("outgoingHealing")]
        internal OutgoingHealing[] OutgoingHealing { get; set; }
    }
}
