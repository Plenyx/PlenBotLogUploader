using Newtonsoft.Json;

namespace PlenBotLogUploader.GitHub
{
    internal sealed class GitHubReleasesLatest
    {
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("assets")]
        internal GitHubReleasesLatestAsset[] Assets { get; set; }

        [JsonProperty("body")]
        internal string Body { get; set; }
    }
}
