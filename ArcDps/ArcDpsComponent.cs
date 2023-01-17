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
    internal sealed class ArcDpsComponent
    {
        private static List<ArcDpsComponent> _All;

        internal static List<ArcDpsComponent> All => _All ??= new List<ArcDpsComponent>();

        internal static void SerialiseAll(string applicationDirectory) => File.WriteAllText($"{applicationDirectory}arcdps_components.json", JsonConvert.SerializeObject(All, Formatting.Indented));

        internal static List<ArcDpsComponent> DeserialiseAll(string applicationDirectory)
        {
            if (File.Exists($"{applicationDirectory}arcdps_components.json"))
            {
                var componentsFile = File.ReadAllText($"{applicationDirectory}arcdps_components.json");
                _All = JsonConvert.DeserializeObject<List<ArcDpsComponent>>(componentsFile);
            }
            return All;
        }

        [JsonProperty("type")]
        internal ArcDpsComponentType Type { get; set; }

        [JsonProperty("renderMode")]
        internal GameRenderMode RenderMode { get; set; } = GameRenderMode.DX11;

        [JsonProperty("location")]
        internal string RelativeLocation { get; set; }

        internal string Repository => Type switch
        {
            ArcDpsComponentType.Mechanics => "knoxfighter/GW2-ArcDPS-Mechanics-Log",
            ArcDpsComponentType.BoonTable => "knoxfighter/GW2-ArcDPS-Boon-Table",
            ArcDpsComponentType.KPme => "knoxfighter/arcdps-killproof.me-plugin",
            ArcDpsComponentType.HealStats => "Krappa322/arcdps_healing_stats",
            ArcDpsComponentType.SCT => "Artenuvielle/GW2-SCT",
            ArcDpsComponentType.Clears => "gw2scratch/arcdps-clears",
            ArcDpsComponentType.FoodReminder => "Zerthox/arcdps-food-reminder",
            ArcDpsComponentType.CommandersToolkit => "RaidcoreGG/GW2-CommandersToolkit",
            ArcDpsComponentType.KnowThyEnemy => "typedeck0/Know-thy-enemy",
            _ => null,
        };

        internal GitHubReleaseLatest LatestRelease { get; private set; }

        internal string DownloadLink => Type switch
        {
            ArcDpsComponentType.ArcDps => "https://deltaconnected.com/arcdps/x64/d3d11.dll",
            _ => null,
        };

        internal string VersionLink => Type switch
        {
            ArcDpsComponentType.ArcDps => "https://deltaconnected.com/arcdps/x64/d3d11.dll.md5sum",
            _ => null,
        };

        internal async Task<bool> DownloadComponent(HttpClientController httpController)
        {
            if (!string.IsNullOrWhiteSpace(DownloadLink))
            {
                return await httpController.DownloadFileAsync(DownloadLink, $"{ApplicationSettings.Current.Gw2Location}{RelativeLocation}");
            }
            if (!string.IsNullOrWhiteSpace(Repository))
            {
                var dll = LatestRelease?.Assets?.FirstOrDefault(x => x.Name.EndsWith(".dll"))?.DownloadUrl;
                if (dll is null)
                {
                    await GetGitHubRelease(httpController);
                    dll = (LatestRelease?.Assets?.FirstOrDefault(x => x.Name.EndsWith(".dll"))?.DownloadUrl);
                    if (dll is null)
                    {
                        return false;
                    }
                }
                return await httpController.DownloadFileAsync(dll, ApplicationSettings.Current.Gw2Location + RelativeLocation);
            }
            return false;
        }

        internal bool IsInstalled() => File.Exists(ApplicationSettings.Current.Gw2Location + RelativeLocation);

        internal bool IsCurrentVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return true;
            }
            if (!IsInstalled())
            {
                return false;
            }
            if ((Type == ArcDpsComponentType.HealStats) || (Type == ArcDpsComponentType.SCT) || (Type == ArcDpsComponentType.Mechanics) || (Type == ArcDpsComponentType.BoonTable) ||
                (Type == ArcDpsComponentType.KPme) || (Type == ArcDpsComponentType.Clears) || (Type == ArcDpsComponentType.FoodReminder) || (Type == ArcDpsComponentType.CommandersToolkit) ||
                (Type == ArcDpsComponentType.KnowThyEnemy))
            {
                return GetFileSize().ToString().Equals(version);
            }
            // arcdps
            var versionMd5 = version.Split(' ')[0];
            return MakeMD5Hash().Equals(versionMd5);
        }

        private async Task<GitHubReleaseLatest> GetGitHubRelease(HttpClientController httpController) => LatestRelease = await httpController.GetGitHubLatestReleaseAsync(Repository);

        internal async Task<string> GetVersionStringAsync(HttpClientController httpController)
        {
            if (!string.IsNullOrWhiteSpace(VersionLink))
            {
                return await httpController.DownloadFileToStringAsync(VersionLink);
            }
            if (!string.IsNullOrWhiteSpace(Repository))
            {
                var release = await GetGitHubRelease(httpController);
                return release?.Assets?.FirstOrDefault(x => x.Name.EndsWith(".dll"))?.Size.ToString();
            }
            return null;
        }

        private long GetFileSize()
        {
            try
            {
                return new FileInfo(ApplicationSettings.Current.Gw2Location + RelativeLocation).Length;
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
                using var stream = File.OpenRead(ApplicationSettings.Current.Gw2Location + RelativeLocation);
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
            catch
            {
                return "";
            }
        }
    }
}
