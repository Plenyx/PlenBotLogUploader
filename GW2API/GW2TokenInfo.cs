using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2API
{
    internal sealed class GW2APITokenInfo
    {
        [JsonProperty("name")]
        internal string Name { get; set; }
    }
}
