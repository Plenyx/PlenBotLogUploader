using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
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
        internal DpsAll[] DpsAll { get; set; }

        [JsonProperty("statsAll")]
        internal StatsAll[] StatsAll { get; set; }

        [JsonProperty("defenses")]
        internal Defenses[] Defenses { get; set; }

        [JsonProperty("totalHealth")]
        internal int TotalHealth { get; set; }

        [JsonProperty("healthPercentBurned")]
        internal double HealthPercentBurned { get; set; }

        internal double RemainingHealthPercent => 100 - HealthPercentBurned;
    }
}
