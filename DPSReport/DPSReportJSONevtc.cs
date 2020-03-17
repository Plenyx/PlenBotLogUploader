using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONEVTC
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("bossId")]
        public int BossId { get; set; }
    }
}
