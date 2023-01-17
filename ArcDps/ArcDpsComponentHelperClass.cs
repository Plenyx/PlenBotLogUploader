using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;

namespace PlenBotLogUploader.ArcDps
{
    internal sealed class ArcDpsComponentHelperClass
    {
        internal static List<ArcDpsComponentHelperClass> All => new()
        {
            new ArcDpsComponentHelperClass()
            {
                Name = "Mechanics",
                FullName = "Mechanics log",
                LinkName = "knoxfighter/GW2-ArcDPS-Mechanics-Log",
                LinkUrl = "https://github.com/knoxfighter/GW2-ArcDPS-Mechanics-Log/",
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
                LinkUrl = "https://github.com/knoxfighter/GW2-ArcDPS-Boon-Table/",
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
                LinkUrl = "https://github.com/knoxfighter/arcdps-killproof.me-plugin/",
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
                LinkUrl = "https://github.com/Krappa322/arcdps_healing_stats/",
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
                LinkUrl = "https://github.com/Artenuvielle/GW2-SCT/",
                Author = "Artenuvielle",
                Type = ArcDpsComponentType.SCT,
                Provider = "GitHub",
                License = "MIT",
                Description = "A scrolling combat text addon for GW2 using ArcDPS API. - Artenuvielle",
            },
            new ArcDpsComponentHelperClass()
            {
                Name = "ArcDps Clears",
                FullName = "ArcDps clears",
                LinkName = "gw2scratch/arcdps-clears",
                LinkUrl = "https://github.com/gw2scratch/arcdps-clears/",
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
                LinkUrl = "https://github.com/Zerthox/arcdps-food-reminder/",
                Author = "Zerthox",
                Type = ArcDpsComponentType.FoodReminder,
                Provider = "GitHub",
                License = "MIT",
                Description = "ArcDPS plugin for Guild Wars 2 allowing tracking of buff food and utility items. - Zerthox",
            },
            new ArcDpsComponentHelperClass()
            {
                Name = "Commander's Toolkit",
                FullName = "Commander's Toolkit",
                LinkName = "RaidcoreGG/GW2-CommandersToolkit",
                LinkUrl = "https://github.com/RaidcoreGG/GW2-CommandersToolkit/",
                Author = "DeltaxHunter",
                Type = ArcDpsComponentType.CommandersToolkit,
                Provider = "GitHub",
                License = "MIT",
                Description = "An addon to help with squad management. - DeltaxHunter",
            },
            new ArcDpsComponentHelperClass()
            {
                Name = "Know Thy Enemy",
                FullName = "Know Thy Enemy",
                LinkName = "typedeck0/Know-thy-enemy",
                LinkUrl = "https://github.com/typedeck0/Know-thy-enemy/",
                Author = "typedeck",
                Type = ArcDpsComponentType.KnowThyEnemy,
                Provider = "GitHub",
                License = "CC0-1.0 license",
                Description = "Tired of commanders saying \"They're twice our size!\"? Well now you can put a number on it!\r\n\r\nCounts the amount and type of player enemies (that your squad hits or is hit by) in an arcdps fight instance (resets when arcdps does). - typedeck",
            },
        };

        internal string Name { get; set; }

        internal string FullName { get; set; }

        internal string Author { get; set; }

        internal string Description { get; set; }

        internal string LinkName { get; set; }

        internal string LinkUrl { get; set; }

        internal string License { get; set; }

        internal string Provider { get; set; }

        internal ArcDpsComponentType Type { get; set; }

        internal string DefaultFileName => Type switch
        {
            ArcDpsComponentType.Mechanics => "d3d11_arcdps_mechanics.dll",
            ArcDpsComponentType.BoonTable => "d3d11_arcdps_table.dll",
            ArcDpsComponentType.KPme => "d3d11_arcdps_killproof_me.dll",
            ArcDpsComponentType.HealStats => "d3d11_arcdps_healing_stats.dll",
            ArcDpsComponentType.SCT => "d3d11_arcdps_sct.dll",
            ArcDpsComponentType.Clears => "d3d11_arcdps_clears.dll",
            ArcDpsComponentType.FoodReminder => "d3d11_arcdps_food_reminder.dll",
            ArcDpsComponentType.CommandersToolkit => "d3d11_arcdps_commanders_toolkit.dll",
            ArcDpsComponentType.KnowThyEnemy => "d3d11_arcdps_know_thy_enemy.dll",
            // arcdps
            _ => "d3d11.dll",
        };

        internal bool IsInstalled => File.Exists(ApplicationSettings.Current.Gw2Location + DefaultFileName);

        public override string ToString() => $"{Name} by {Author}";
    }
}
