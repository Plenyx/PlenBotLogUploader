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
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Mechanics",
                        FullName = "Mechanics log",
                        LinkName = "knoxfighter/GW2-ArcDPS-Mechanics-Log",
                        LinkURL = "https://github.com/knoxfighter/GW2-ArcDPS-Mechanics-Log/",
                        Author = "MarsEdge, modified by knoxfighter",
                        Type = ArcDpsComponentType.Mechanics,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "The plugin shows a list of fractal/strike/raid mechanics for players and also logs these mechanics to a file.",
                    },
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Boon table",
                        FullName = "Boon table",
                        LinkName = "knoxfighter/GW2-ArcDPS-Boon-Table",
                        LinkURL = "https://github.com/knoxfighter/GW2-ArcDPS-Boon-Table/",
                        Author = "MarsEdge, modified by knoxfighter",
                        Type = ArcDpsComponentType.BoonTable,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "The plugin shows a table of boon uptime in a group.",
                    },
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Killproof.me",
                        FullName = "Killproof.me arcdps plugin",
                        LinkName = "knoxfighter/arcdps-killproof.me-plugin",
                        LinkURL = "https://github.com/knoxfighter/arcdps-killproof.me-plugin/",
                        Author = "knoxfighter",
                        Type = ArcDpsComponentType.KPme,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "An official arcdps plugin for killproof.me website which retrieves the data from it and displays it on the screen.",
                    },
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Heal stats",
                        FullName = "Heal stats",
                        LinkName = "Krappa322/arcdps_healing_stats",
                        LinkURL = "https://github.com/Krappa322/arcdps_healing_stats/",
                        Author = "Krappa322",
                        Type = ArcDpsComponentType.HealStats,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "Addon for ArcDPS that shows personal healing stats. - Krappa322",
                    },
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Scrolling combat text",
                        FullName = "Scrolling combat text",
                        LinkName = "Artenuvielle/GW2-SCT",
                        LinkURL = "https://github.com/Artenuvielle/GW2-SCT/",
                        Author = "Artenuvielle",
                        Type = ArcDpsComponentType.SCT,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "A scrolling combat text addon for GW2 using ArcDPS API. - Artenuvielle",
                    },
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Clears",
                        FullName = "ArcDps clears",
                        LinkName = "gw2scratch/arcdps-clears",
                        LinkURL = "https://github.com/gw2scratch/arcdps-clears/",
                        Author = "Sejsel",
                        Type = ArcDpsComponentType.Clears,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "A plugin for arcdps which adds a window that shows your current weekly clears. - Sejsel",
                    },
                };
            }
        }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string LinkName { get; set; }

        public string LinkURL { get; set; }

        public string License { get; set; }

        public string Provider { get; set; }

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
