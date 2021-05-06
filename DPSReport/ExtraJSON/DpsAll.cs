using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class DpsAll
    {
        [JsonProperty("dps")]
        public int DPS { get; set; }

        [JsonProperty("damage")]
        public int Damage { get; set; }
    }
}
