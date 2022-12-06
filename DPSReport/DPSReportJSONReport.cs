using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport
{
    internal sealed class DpsReportJsonReport
    {
        [JsonProperty("anonymous")]
        internal bool Anonymous { get; set; }

        [JsonProperty("detailed")]
        internal bool Detailed { get; set; }
    }
}
