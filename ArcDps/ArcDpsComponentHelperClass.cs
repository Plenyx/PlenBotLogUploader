using Hardstuck.GuildWars2;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;

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
                    new ArcDpsComponentHelperClass()
                    {
                        Name = "Food Reminder",
                        FullName = "Food Reminder",
                        LinkName = "Zerthox/arcdps-food-reminder",
                        LinkURL = "https://github.com/Zerthox/arcdps-food-reminder/",
                        Author = "Zerthox",
                        Type = ArcDpsComponentType.FoodReminder,
                        Provider = "GitHub",
                        License = "MIT",
                        Description = "ArcDPS plugin for Guild Wars 2 allowing tracking of buff food & utility items. - Zerthox",
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
            get => (ApplicationSettings.Current.ArcUpdate.RenderMode == GameRenderMode.DX11) ? "d3d11" : "d3d9";
        }

        public string DefaultFileName
        {
            get => Type switch
            {
                ArcDpsComponentType.Mechanics => $"{Prefix}_arcdps_mechanics.dll",
                ArcDpsComponentType.BoonTable => $"{Prefix}_arcdps_table.dll",
                ArcDpsComponentType.KPme => $"{Prefix}_arcdps_killproof_me.dll",
                ArcDpsComponentType.HealStats => $"{Prefix}_arcdps_healing_stats.dll",
                ArcDpsComponentType.SCT => $"{Prefix}_arcdps_sct.dll",
                ArcDpsComponentType.Clears => $"{Prefix}_arcdps_clears.dll",
                ArcDpsComponentType.FoodReminder => $"{Prefix}_arcdps_food_reminder.dll",
                // arcdps
                _ => $"{Prefix}.dll",
            };
        }

        public bool IsInstalled
        {
            get => File.Exists($"{ApplicationSettings.Current.GW2Location}{DefaultFileName}");
        }

        public override string ToString() => $"{Name} by {Author}";
    }
}
