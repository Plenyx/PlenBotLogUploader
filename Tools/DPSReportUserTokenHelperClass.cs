using Newtonsoft.Json;

namespace PlenBotLogUploader.Tools
{
    internal sealed class DpsReportUserTokenHelperClass
    {
        [JsonProperty("userToken")]
        internal string UserToken { get; set; }
    }
}
