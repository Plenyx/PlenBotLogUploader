using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class DpsTarget
    {
        [JsonProperty("dps")]
        public int DPS { get; set; }

        [JsonProperty("damage")]
        public int Damage { get; set; }
    }
}
