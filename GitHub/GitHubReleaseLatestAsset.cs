using Newtonsoft.Json;

namespace PlenBotLogUploader.GitHub
{
    internal sealed class GitHubReleaseLatestAsset
    {
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("size")]
        internal long Size { get; set; }

        [JsonProperty("browser_download_url")]
        internal string DownloadURL { get; set; }
    }
}
