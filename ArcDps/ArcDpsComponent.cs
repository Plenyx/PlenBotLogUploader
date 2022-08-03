using Hardstuck.GuildWars2;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.GitHub;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlenBotLogUploader.ArcDps
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ArcDpsComponent
    {
        private static List<ArcDpsComponent> _All;

        public static List<ArcDpsComponent> All
        {
            get => _All ??= new List<ArcDpsComponent>();
        }

        public static void SerialiseAll(string applicationDirectory) => File.WriteAllText($"{applicationDirectory}arcdps_components.json", JsonConvert.SerializeObject(All, Formatting.Indented));

        public static List<ArcDpsComponent> DeserialiseAll(string applicationDirectory)
        {
            if (File.Exists($"{applicationDirectory}arcdps_components.json"))
            {
                var componentsFile = File.ReadAllText($"{applicationDirectory}arcdps_components.json");
                _All = JsonConvert.DeserializeObject<List<ArcDpsComponent>>(componentsFile);
            }
            return All;
        }

        [JsonProperty("type")]
        public ArcDpsComponentType Type { get; set; }

        [JsonProperty("renderMode")]
        public GameRenderMode RenderMode { get; set; } = GameRenderMode.DX11;

        [JsonProperty("location")]
        public string RelativeLocation { get; set; }

        public string Repository
        {
            get => Type switch
            {
                ArcDpsComponentType.Mechanics => "knoxfighter/GW2-ArcDPS-Mechanics-Log",
                ArcDpsComponentType.BoonTable => "knoxfighter/GW2-ArcDPS-Boon-Table",
                ArcDpsComponentType.KPme => "knoxfighter/arcdps-killproof.me-plugin",
                ArcDpsComponentType.HealStats => "Krappa322/arcdps_healing_stats",
                ArcDpsComponentType.SCT => "Artenuvielle/GW2-SCT",
                ArcDpsComponentType.Clears => "gw2scratch/arcdps-clears",
                ArcDpsComponentType.FoodReminder => "Zerthox/arcdps-food-reminder",
                _ => null,
            };
        }

        public GitHubReleasesLatest LatestRelease { get; private set; }

        public string DownloadLink
        {
            get => Type switch
            {
                ArcDpsComponentType.ArcDps => RenderMode.Equals(GameRenderMode.DX11) ? "https://deltaconnected.com/arcdps/x64/d3d11.dll" : "https://deltaconnected.com/arcdps/x64/d3d9.dll",
                _ => null,
            };
        }

        public string VersionLink
        {
            get => Type switch
            {
                ArcDpsComponentType.ArcDps => RenderMode.Equals(GameRenderMode.DX11) ? "https://deltaconnected.com/arcdps/x64/d3d11.dll.md5sum" : "https://deltaconnected.com/arcdps/x64/d3d9.dll.md5sum",
                _ => null,
            };
        }

        public async Task<bool> DownloadComponent(HttpClientController httpController)
        {
            if (!string.IsNullOrWhiteSpace(DownloadLink))
            {
                return await httpController.DownloadFileAsync(DownloadLink, $"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");
            }
            if (!string.IsNullOrWhiteSpace(Repository))
            {
                var dll = LatestRelease?.Assets?.Where(x => x.Name.EndsWith(".dll")).FirstOrDefault()?.DownloadURL ?? null;
                if (dll is null)
                {
                    await GetGitHubRelease(httpController);
                    dll = LatestRelease?.Assets?.Where(x => x.Name.EndsWith(".dll")).FirstOrDefault()?.DownloadURL ?? null;
                    if (dll is null)
                    {
                        return false;
                    }
                }
                return await httpController.DownloadFileAsync(dll, $"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");
            }
            return false;
        }

        public bool IsInstalled() => File.Exists($@"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");

        public bool IsCurrentVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return true;
            }
            if (!IsInstalled())
            {
                return false;
            }
            if ((Type == ArcDpsComponentType.HealStats) || (Type == ArcDpsComponentType.SCT) || (Type == ArcDpsComponentType.Mechanics) ||
                (Type == ArcDpsComponentType.BoonTable) || (Type == ArcDpsComponentType.KPme) || (Type == ArcDpsComponentType.Clears) || (Type == ArcDpsComponentType.FoodReminder))
            {
                return GetFileSize().ToString().Equals(version);
            }
            // arcdps
            var versionMd5 = version;
            var versionMd5Clean = versionMd5.Split(' ')[0];
            return MakeMD5Hash().Equals(versionMd5Clean);
        }

        private async Task<GitHubReleasesLatest> GetGitHubRelease(HttpClientController httpController) => LatestRelease = await httpController.GetGitHubLatestReleaseAsync(Repository);

        public async Task<string> GetVersionStringAsync(HttpClientController httpController)
        {
            if (!string.IsNullOrWhiteSpace(VersionLink))
            {
                return await httpController.DownloadFileToStringAsync(VersionLink);
            }
            if (!string.IsNullOrWhiteSpace(Repository))
            {
                var release = await GetGitHubRelease(httpController);
                return release?.Assets?.Where(x => x.Name.EndsWith(".dll")).FirstOrDefault()?.Size.ToString() ?? null;
            }
            return null;
        }

        private long GetFileSize()
        {
            try
            {
                var file = new FileInfo($"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");
                return file.Length;
            }
            catch
            {
                return 0;
            }
        }

        private string MakeMD5Hash()
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            try
            {
                byte[] hash = null;
                using var stream = File.OpenRead($"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");
                hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
