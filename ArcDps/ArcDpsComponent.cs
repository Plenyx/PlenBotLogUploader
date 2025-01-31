using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.GitHub;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PlenBotLogUploader.ArcDps;

[JsonObject(MemberSerialization.OptIn)]
internal sealed class ArcDpsComponent
{
    internal static List<ArcDpsComponent> All { get; private set; } = [];

    [JsonProperty("type")]
    internal ArcDpsComponentType Type { get; set; }

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
        ArcDpsComponentType.BHUDBridge => "blish-hud/arcdps-bhud",
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

    internal static void SerialiseAll(string applicationDirectory) => File.WriteAllText($"{applicationDirectory}arcdps_components.json", JsonConvert.SerializeObject(All, Formatting.Indented));

    internal static List<ArcDpsComponent> DeserialiseAll(string applicationDirectory)
    {
        if (!File.Exists($"{applicationDirectory}arcdps_components.json"))
        {
            return All;
        }
        var componentsFile = File.ReadAllText($"{applicationDirectory}arcdps_components.json");
        All = JsonConvert.DeserializeObject<List<ArcDpsComponent>>(componentsFile);
        return All;
    }

    internal async Task<bool> DownloadComponent(HttpClientController httpController)
    {
        if (!string.IsNullOrWhiteSpace(DownloadLink))
        {
            return await httpController.DownloadFileAsync(DownloadLink, ApplicationSettings.Current.Gw2Location + RelativeLocation);
        }
        if (string.IsNullOrWhiteSpace(Repository))
        {
            return false;
        }
        var dll = LatestRelease?.Assets?.FirstOrDefault(x => x.Name.EndsWith(".dll"))?.DownloadUrl;
        if (dll is not null)
        {
            return await httpController.DownloadFileAsync(dll, ApplicationSettings.Current.Gw2Location + RelativeLocation);
        }
        await GetGitHubRelease(httpController);
        dll = LatestRelease?.Assets?.FirstOrDefault(x => x.Name.EndsWith(".dll"))?.DownloadUrl;
        return dll is not null;
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
        if (Type is ArcDpsComponentType.HealStats
            or ArcDpsComponentType.SCT
            or ArcDpsComponentType.Mechanics
            or ArcDpsComponentType.BoonTable
            or ArcDpsComponentType.KPme
            or ArcDpsComponentType.Clears
            or ArcDpsComponentType.FoodReminder
            or ArcDpsComponentType.CommandersToolkit
            or ArcDpsComponentType.BHUDBridge)
        {
            return GetFileSize().ToString().Equals(version);
        }
        // arcdps
        var versionMd5 = version.Split(' ')[0];
        return MakeMd5Hash().Equals(versionMd5);
    }

    private async Task<GitHubReleaseLatest> GetGitHubRelease(HttpClientController httpController) => LatestRelease = await httpController.GetGitHubLatestReleaseAsync(Repository);

    internal async Task<string> GetVersionStringAsync(HttpClientController httpController)
    {
        if (!string.IsNullOrWhiteSpace(VersionLink))
        {
            return await httpController.DownloadFileToStringAsync(VersionLink);
        }
        if (string.IsNullOrWhiteSpace(Repository))
        {
            return null;
        }
        var release = await GetGitHubRelease(httpController);
        return release?.Assets?.FirstOrDefault(x => x.Name.EndsWith(".dll"))?.Size.ToString();
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

    private string MakeMd5Hash()
    {
        using var md5 = MD5.Create();
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
