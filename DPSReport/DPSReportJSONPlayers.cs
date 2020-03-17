using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONPlayers
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("character_name")]
        public string CharacterName { get; set; }

        [JsonProperty("profession")]
        public int Profession { get; set; }

        [JsonProperty("elite_spec")]
        public int Elite_spec { get; set; }
    }
}
