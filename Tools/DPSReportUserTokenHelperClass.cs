using Newtonsoft.Json;

namespace PlenBotLogUploader.Tools
{
    public class DPSReportUserTokenHelperClass
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }
    }
}
