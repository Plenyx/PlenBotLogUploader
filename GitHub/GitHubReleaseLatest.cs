using Newtonsoft.Json;

namespace PlenBotLogUploader.GitHub;

internal sealed class GitHubReleaseLatest
{
    [JsonProperty("name")]
    internal string Name { get; set; }

    [JsonProperty("assets")]
    internal GitHubReleaseLatestAsset[] Assets { get; set; }

    [JsonProperty("body")]
    internal string Body { get; set; }
}
