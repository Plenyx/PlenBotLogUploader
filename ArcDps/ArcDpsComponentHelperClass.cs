using Hardstuck.GuildWars2;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;

namespace PlenBotLogUploader.ArcDps
{
    public class ArcDpsComponentHelperClass
    {
        public static List<ArcDpsComponentHelperClass> All
        {
            get
            {
                return new List<ArcDpsComponentHelperClass>()
                {
                    new ArcDpsComponentHelperClass() { Name = "Mechanics", Author = "MarsEdge, modified by knoxfighter", Type = ArcDpsComponentType.Mechanics },
                    new ArcDpsComponentHelperClass() { Name = "Boon table", Author = "MarsEdge, modified by knoxfighter", Type = ArcDpsComponentType.BoonTable },
                    new ArcDpsComponentHelperClass() { Name = "Killproof.me", Author = "knoxfighter", Type = ArcDpsComponentType.KPme },
                    new ArcDpsComponentHelperClass() { Name = "Heal stats", Author = "Krappa322", Type = ArcDpsComponentType.HealStats },
                    new ArcDpsComponentHelperClass() { Name = "Scrolling combat text", Author = "Artenuvielle", Type = ArcDpsComponentType.SCT },
                    new ArcDpsComponentHelperClass() { Name = "Unofficial extras", Author = "Krappa322", Type = ArcDpsComponentType.UExtras },
                    new ArcDpsComponentHelperClass() { Name = "Clears", Author = "Sejsel", Type = ArcDpsComponentType.Clears },
                };
            }
        }

        public string Name { get; set; }

        public string Author { get; set; }

        public ArcDpsComponentType Type { get; set; }

        private string Prefix
        {
            get
            {
                if (ApplicationSettings.Current.ArcUpdate.RenderMode == GameRenderMode.DX11)
                {
                    return "d3d11";
                }
                return "d3d9";
            }
        }

        public string DefaultFileName
        {
            get
            {
                switch (Type)
                {
                    case ArcDpsComponentType.Mechanics:
                        return $"{Prefix}_arcdps_mechanics.dll";
                    case ArcDpsComponentType.BoonTable:
                        return $"{Prefix}_arcdps_table.dll";
                    case ArcDpsComponentType.KPme:
                        return $"{Prefix}_arcdps_killproof_me.dll";
                    case ArcDpsComponentType.HealStats:
                        return $"{Prefix}_arcdps_healing_stats.dll";
                    case ArcDpsComponentType.SCT:
                        return $"{Prefix}_arcdps_sct.dll";
                    case ArcDpsComponentType.UExtras:
                        return $"{Prefix}_arcdps_unofficial_extras.dll";
                    case ArcDpsComponentType.Clears:
                        return $"{Prefix}_arcdps_clears.dll";
                    default: // arcdps
                        return $"{Prefix}.dll";
                }
            }
        }

        public override string ToString() => $"{Name} by {Author}";
    }
}
