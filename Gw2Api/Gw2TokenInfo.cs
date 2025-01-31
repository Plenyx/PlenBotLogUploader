using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api;

internal sealed class Gw2TokenInfo
{
    [JsonProperty("name")]
    internal string Name { get; set; }
}
