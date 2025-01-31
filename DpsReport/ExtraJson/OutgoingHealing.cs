using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson;

internal class OutgoingHealing
{
    [JsonProperty("healing")]
    internal long Healing { get; set; }

    [JsonProperty("hps")]
    internal long HealingPerSecond { get; set; }
}
