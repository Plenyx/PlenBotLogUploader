using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api;

internal sealed class Gw2Account
{
    [JsonProperty("id")]
    internal string Id { get; set; }

    [JsonProperty("name")]
    internal string Name { get; set; }

    [JsonProperty("world")]
    internal int? World { get; set; }

    [JsonProperty("wvw")]
    internal Gw2AccountWvw Wvw { get; set; }
}
