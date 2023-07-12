using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class OutgoingHealingAlly
    {
        [JsonProperty("healing")]
        internal int Healing { get; set; }
    }
}
