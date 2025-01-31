using Newtonsoft.Json;

namespace PlenBotLogUploader.Gw2Api;

internal class Gw2AccountWvw
{
    [JsonProperty("rank")]
    internal int Rank { get; set; }

    [JsonProperty("team_id")]
    internal int TeamId { get; set; }
}
