using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class OutgoingHealing
    {
        [JsonProperty("healing")]
        internal int Healing { get; set; }
    }
}
