using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    internal sealed class DPSReportJSONReport
    {
        [JsonProperty("anonymous")]
        internal bool Anonymous { get; set; }

        [JsonProperty("detailed")]
        internal bool Detailed { get; set; }
    }
}
