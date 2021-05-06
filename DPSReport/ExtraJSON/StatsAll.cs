using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class StatsAll
    {
        [JsonProperty("killed")]
        public int Killed { get; set; }

        [JsonProperty("downed")]
        public int Downed { get; set; }
    }
}
