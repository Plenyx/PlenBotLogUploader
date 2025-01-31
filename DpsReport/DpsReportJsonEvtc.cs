using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport;

internal sealed class DpsReportJsonEvtc
{
    [JsonProperty("type")]
    internal string Type { get; set; }

    [JsonProperty("version")]
    internal string Version { get; set; }

    [JsonProperty("bossId")]
    internal int BossId { get; set; }
}
