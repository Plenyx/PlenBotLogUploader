using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport.ExtraJSON
{
    internal sealed class Target
    {
        [JsonProperty("id")]
        internal int Id { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("isFake")]
        internal bool IsFake { get; set; }

        [JsonProperty("dpsAll")]
        internal List<DpsAll> DpsAll { get; set; }

        [JsonProperty("statsAll")]
        internal List<StatsAll> StatsAll { get; set; }

        [JsonProperty("defenses")]
        internal List<Defenses> Defenses { get; set; }

        [JsonProperty("totalHealth")]
        internal int TotalHealth { get; set; }

        [JsonProperty("healthPercentBurned")]
        internal double HealthPercentBurned { get; set; }

        internal double RemainingHealthPercent => 100 - HealthPercentBurned;
    }
}
