using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class Defenses
    {
        [JsonProperty("damageTaken")]
        internal int DamageTaken { get; set; }

        [JsonProperty("downCount")]
        internal int DownCount { get; set; }

        [JsonProperty("deadCount")]
        internal int DeadCount { get; set; }
    }
}
