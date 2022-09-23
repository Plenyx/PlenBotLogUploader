using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    internal sealed class DPSReportJSONEncounter
    {
        [JsonProperty("success")]
        internal bool? Success { get; set; }

        [JsonProperty("duration")]
        internal float? Duration { get; set; }

        [JsonProperty("compDps")]
        internal int? CompDps { get; set; }

        [JsonProperty("numberOfPlayers")]
        internal int? NumberOfPlayers { get; set; }

        [JsonProperty("numberOfGroups")]
        internal int? NumberOfGroups { get; set; }

        [JsonProperty("bossId")]
        internal int BossId { get; set; }

        [JsonProperty("boss")]
        internal string Boss { get; set; }

        [JsonProperty("isCm")]
        internal bool? IsCM { get; set; }

        [JsonProperty("gw2Build")]
        internal int? Gw2Build { get; set; }

        [JsonProperty("jsonAvailable")]
        internal bool? JsonAvailable { get; set; }
    }
}
