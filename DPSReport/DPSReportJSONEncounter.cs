using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONEncounter
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("compDps")]
        public int? CompDps { get; set; }

        [JsonProperty("numberOfPlayers")]
        public int? NumberOfPlayers { get; set; }

        [JsonProperty("numberOfGroups")]
        public int? NumberOfGroups { get; set; }

        [JsonProperty("bossId")]
        public int BossId { get; set; }

        [JsonProperty("boss")]
        public string Boss { get; set; }

        [JsonProperty("gw2Build")]
        public int? Gw2Build { get; set; }

        [JsonProperty("jsonAvailable")]
        public bool? JsonAvailable { get; set; }
    }
}
