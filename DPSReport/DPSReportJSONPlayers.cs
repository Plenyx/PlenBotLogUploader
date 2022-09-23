using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    internal sealed class DPSReportJSONPlayers
    {
        [JsonProperty("display_name")]
        internal string DisplayName { get; set; }

        [JsonProperty("character_name")]
        internal string CharacterName { get; set; }

        [JsonProperty("profession")]
        internal int Profession { get; set; }

        [JsonProperty("elite_spec")]
        internal int EliteSpec { get; set; }
    }
}
