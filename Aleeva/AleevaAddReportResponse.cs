using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    internal sealed class AleevaAddReportResponse : AleevaResponseStatus
    {
        [JsonProperty("dpsReport")]
        internal string DPSReport { get; set; }

        [JsonProperty("fromCache")]
        internal bool FromCache { get; set; }
    }
}
