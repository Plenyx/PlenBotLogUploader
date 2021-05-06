using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    public class Defenses
    {
        [JsonProperty("damageTaken")]
        public int DamageTaken { get; set; }

        [JsonProperty("downCount")]
        public int DownCount { get; set; }

        [JsonProperty("deadCount")]
        public int DeadCount { get; set; }
    }
}
