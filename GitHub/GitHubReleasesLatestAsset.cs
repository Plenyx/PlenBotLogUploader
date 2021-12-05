using Newtonsoft.Json;

namespace PlenBotLogUploader.GitHub
{
    public class GitHubReleasesLatestAsset
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("browser_download_url")]
        public string DownloadURL { get; set; }
    }
}
