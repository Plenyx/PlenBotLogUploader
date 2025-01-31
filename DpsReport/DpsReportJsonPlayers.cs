using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport;

internal sealed class DpsReportJsonPlayers
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
