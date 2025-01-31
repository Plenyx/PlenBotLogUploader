using Newtonsoft.Json;

namespace PlenBotLogUploader.Tools;

internal sealed class DpsReportUserToken
{
    [JsonProperty("userToken")]
    internal string UserToken { get; set; }
}
