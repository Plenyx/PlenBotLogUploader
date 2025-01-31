using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api;

internal readonly struct Gw2Server
{
    [JsonProperty("id")]
    internal int Id { get; init; }

    [JsonProperty("name")]
    internal string Name { get; init; }

    internal string Region => Id is < 2000 or < 12000 and >= 11000 ? "NA" : "EU";
}
