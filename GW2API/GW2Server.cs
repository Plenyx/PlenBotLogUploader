using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api
{
    internal sealed class Gw2Server
    {
        [JsonProperty("id")]
        internal int ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        internal string Region => (ID < 2000) ? "NA" : "EU";
    }
}
