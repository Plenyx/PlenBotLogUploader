using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2API
{
    public class GW2Account
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("world")]
        public int World { get; set; }

        [JsonProperty("wvw_rank")]
        public int WvWRank { get; set; }
    }
}
