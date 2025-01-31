using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport;

internal sealed class DpsReportJsonEncounter
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
    internal bool? IsCm { get; set; }

    [JsonProperty("isLegendaryCm")]
    internal bool? IsLegendaryCm { get; set; }

    [JsonProperty("emboldened")]
    internal int? Emboldened { get; set; }

    [JsonProperty("gw2Build")]
    internal ulong? GameBuild { get; set; }

    [JsonProperty("jsonAvailable")]
    internal bool? JsonAvailable { get; set; }
}
