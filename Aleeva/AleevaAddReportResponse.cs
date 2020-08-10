using Newtonsoft.Json;

namespace PlenBotLogUploader.Aleeva
{
    public class AleevaAddReportResponse : AleevaResponseStatus
    {
        [JsonProperty("dpsReport")]
        public string DPSReport { get; set; }

        [JsonProperty("fromCache")]
        public bool FromCache { get; set; }
    }
}
