using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    internal sealed class DpsTarget
    {
        [JsonProperty("dps")]
        internal int DPS { get; set; }

        [JsonProperty("damage")]
        internal int Damage { get; set; }
    }
}
