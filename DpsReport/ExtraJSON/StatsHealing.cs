using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal class StatsHealing
    {
        [JsonProperty("outgoingHealing")]
        internal OutgoingHealing[] OutgoingHealing;
    }
}
