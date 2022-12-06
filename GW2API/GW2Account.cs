using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api
{
    internal sealed class Gw2Account
    {
        [JsonProperty("id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("world")]
        internal int World { get; set; }

        [JsonProperty("wvw_rank")]
        internal int WvWRank { get; set; }
    }
}
