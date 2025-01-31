using Newtonsoft.Json;

namespace PlenBotLogUploader.RemotePing;

internal class PingData
{
    [JsonProperty("permalink")]
    internal string Permalink { get; set; }

    [JsonProperty("bossId")]
    internal int BossId { get; set; }

    [JsonProperty("success")]
    internal bool Success { get; set; }

    [JsonProperty("arcVersion")]
    internal string ArcVersion { get; set; }

    [JsonProperty("gw2Build")]
    internal ulong Gw2Build { get; set; }

    [JsonProperty("fightName")]
    internal string FightName { get; set; }

    [JsonProperty("logTimestamp")]
    internal string LogTimestamp { get; set; }

    [JsonProperty("durationMs")]
    internal ulong DurationMs { get; set; }

    [JsonProperty("isEmboldened")]
    internal bool IsEmboldened { get; set; }

    [JsonProperty("isCM")]
    internal bool IsChallengeMode { get; set; }

    [JsonProperty("isLCM")]
    internal bool IsLegendaryChallengeMode { get; set; }

    [JsonProperty("players")]
    internal string[] Players { get; set; }

    [JsonProperty("logErrors")]
    internal string[] LogErrors { get; set; }
}
