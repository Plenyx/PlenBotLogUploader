using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.GitHub
{
    internal sealed class GitHubReleasesLatest
    {
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("assets")]
        internal List<GitHubReleasesLatestAsset> Assets { get; set; }

        [JsonProperty("body")]
        internal string Body { get; set; }
    }
}
