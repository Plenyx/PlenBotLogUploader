using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class ExtHealingStats
    {
        [JsonProperty("outgoingHealing")]
        internal OutgoingHealing[] OutgoingHealing { get; set; }
    }
}
