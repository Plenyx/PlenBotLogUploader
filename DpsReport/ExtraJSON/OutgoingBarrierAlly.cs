using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class OutgoingBarrierAlly
    {
        [JsonProperty("barrier")]
        internal int Barrier { get; set; }
    }
}
