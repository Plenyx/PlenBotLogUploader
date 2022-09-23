using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2API
{
    internal sealed class GW2Server
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        internal string Region => (ID < 2000) ? "NA" : "EU";
    }
}
