using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson
{
    internal sealed class OutgoingBarrier
    {
        [JsonProperty("barrier")]
        internal int Barrier { get; set; }
    }
}
