using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class DpsAll
    {
        [JsonProperty("dps")]
        internal int DPS { get; set; }

        [JsonProperty("damage")]
        internal int Damage { get; set; }
    }
}
