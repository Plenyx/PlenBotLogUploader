using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONReport
    {
        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; }

        [JsonProperty("detailed")]
        public bool Detailed { get; set; }
    }
}
