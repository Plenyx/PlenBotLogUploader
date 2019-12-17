using System;
using System.IO;
using System.Linq;

namespace PlenBotLogUploader.Tools
{
    static class CompatibilityUpdate
    {
        public static void DoUpdate(string localDir)
        {
            // current version check
            if(Properties.Settings.Default.SavedVersion == Properties.Settings.Default.ReleaseVersion)
            {
                return;
            }
            /// start of updates
            // Release 55
            if(Properties.Settings.Default.SavedVersion < 55)
            {
                File.AppendAllText($"{localDir}/boss_data.txt", "21333<;>Freezie<;><boss> kill: <log><;><boss> pull: <log><;>https://dps.report/cache/https_wiki.guildwars2.com_images_thumb_8_8b_Freezie.jpg_189px-Freezie.jpg<;>3<;>0");
            }
            // end of updates
            Properties.Settings.Default.SavedVersion = Properties.Settings.Default.ReleaseVersion;
        }
    }
}
