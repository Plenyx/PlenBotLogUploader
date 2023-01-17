using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class DpsTarget
    {
        [JsonProperty("dps")]
        internal int Dps { get; set; }

        [JsonProperty("damage")]
        internal int Damage { get; set; }
    }
}
