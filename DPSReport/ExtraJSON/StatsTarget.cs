using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class StatsTarget
    {
        [JsonProperty("killed")]
        public int Killed { get; set; }

        [JsonProperty("downed")]
        public int Downed { get; set; }
    }
}
