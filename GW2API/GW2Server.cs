using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api
{
    internal readonly struct Gw2Server
    {
        [JsonProperty("id")]
        internal int ID { get; init; }

        [JsonProperty("name")]
        internal string Name { get; init; }

        internal string Region => (ID < 2000) ? "NA" : "EU";
    }
}
