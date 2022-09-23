using Newtonsoft.Json;

namespace PlenBotLogUploader.Tools
{
    internal sealed class DPSReportUserTokenHelperClass
    {
        [JsonProperty("userToken")]
        internal string UserToken { get; set; }
    }
}
