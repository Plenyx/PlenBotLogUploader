using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.GitHub
{
    public class GitHubReleasesLatest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("assets")]
        public List<GitHubReleasesLatestAsset> Assets { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
