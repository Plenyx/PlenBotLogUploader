using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    internal sealed class DPSReportJSONEVTC
    {
        [JsonProperty("type")]
        internal string Type { get; set; }

        [JsonProperty("version")]
        internal string Version { get; set; }

        [JsonProperty("bossId")]
        internal int BossId { get; set; }
    }
}
