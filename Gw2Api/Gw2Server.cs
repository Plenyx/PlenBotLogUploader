using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api
{
    internal readonly struct Gw2Server
    {
        [JsonProperty("id")]
        internal int Id { get; init; }

        [JsonProperty("name")]
        internal string Name { get; init; }

        internal string Region => ((Id < 2000) || (Id < 12000) && (Id >= 11000)) ? "NA" : "EU";
    }
}
