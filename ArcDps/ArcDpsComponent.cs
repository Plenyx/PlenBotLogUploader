using Hardstuck.GuildWars2;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            get
            {
                if (_All == null)
                {
                    _All = new List<ArcDpsComponent>();
                }
                return _All;
            }
        }

        public static void SerialiseAll(string applicationDirectory) => File.WriteAllText($"{applicationDirectory}arcdps_components.json", JsonConvert.SerializeObject(All));

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
        public GameRenderMode RenderMode { get; set; } = GameRenderMode.DX9;

        [JsonProperty("location")]
        public string RelativeLocation { get; set; }

        public string DownloadLink
        {
            get
            {
                switch (Type)
                {
                    case ArcDpsComponentType.Mechanics:
                        return "https://plenbot.net/uploader/update-mechanics";
                    case ArcDpsComponentType.BoonTable:
                        return "https://plenbot.net/uploader/update-boontable";
                    case ArcDpsComponentType.KPme:
                        return "https://plenbot.net/uploader/update-kpme";
                    case ArcDpsComponentType.HealStats:
                        return "https://plenbot.net/uploader/update-healstats";
                    case ArcDpsComponentType.SCT:
                        return "https://plenbot.net/uploader/update-sct";
                    default:
                        return "https://deltaconnected.com/arcdps/x64/d3d9.dll";
                }
            }
        }

        public string VersionLink
        {
            get
            {
                switch (Type)
                {
                    case ArcDpsComponentType.Mechanics:
                        return "https://plenbot.net/uploader/version-mechanics";
                    case ArcDpsComponentType.BoonTable:
                        return "https://plenbot.net/uploader/version-boontable";
                    case ArcDpsComponentType.KPme:
                        return "https://plenbot.net/uploader/version-kpme";
                    case ArcDpsComponentType.HealStats:
                        return "https://plenbot.net/uploader/version-healstats";
                    case ArcDpsComponentType.SCT:
                        return "https://plenbot.net/uploader/version-sct";
                    default:
                        return "https://deltaconnected.com/arcdps/x64/d3d9.dll.md5sum";
                }
            }
        }

        public async Task<bool> DownloadComponent(Tools.HttpClientController httpController) => await httpController.DownloadFileAsync(DownloadLink, $"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");

        public bool IsInstalled() => File.Exists($@"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");

        public bool IsCurrentVersion(string version)
        {
            if (!IsInstalled())
            {
                return false;
            }
            if (Type == ArcDpsComponentType.Mechanics || Type == ArcDpsComponentType.BoonTable || Type == ArcDpsComponentType.KPme)
            {
                var fileInfo = FileVersionInfo.GetVersionInfo($@"{ApplicationSettings.Current.GW2Location}{RelativeLocation}");
                var versionWithoutBuild = fileInfo.FileVersion?.Split('.').ToList().Take(3).Aggregate((x, y) => $"{x}.{y}") ?? "";
                return string.IsNullOrWhiteSpace(version) || (versionWithoutBuild == version);
            }
            if (Type == ArcDpsComponentType.HealStats || Type == ArcDpsComponentType.SCT)
            {
                return string.IsNullOrWhiteSpace(version) || (MakeMD5Hash() == version);
            }
            // arcdps
            var versionMd5 = version;
            var versionMd5Clean = versionMd5.Split(' ')[0];
            return string.IsNullOrWhiteSpace(version) || (MakeMD5Hash() == versionMd5Clean);
        }

        private string MakeMD5Hash()
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                try
                {
                    byte[] hash = null;
                    using (var stream = File.OpenRead($"{ApplicationSettings.Current.GW2Location}{RelativeLocation}"))
                    {
                        hash = md5.ComputeHash(stream);
                    }
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
