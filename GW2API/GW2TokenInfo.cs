using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2API
{
    public class GW2APITokenInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
