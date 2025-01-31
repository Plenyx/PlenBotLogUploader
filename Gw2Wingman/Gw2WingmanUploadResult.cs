using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Wingman;

internal class Gw2WingmanUploadResult
{
    [JsonProperty("result")]
    internal bool? Result { get; set; }

    [JsonProperty("error")]
    internal string Error { get; set; }

    internal bool Success => Result ?? false;
}
