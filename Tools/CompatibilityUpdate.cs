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
                /// add Freezie
                var bosses = new System.Collections.Generic.Dictionary<int, DPSReport.BossData>();
                try
                {
                    using (StreamReader reader = new StreamReader($@"{localDir}\boss_data.txt"))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                            int.TryParse(values[0], out int bossId);
                            int.TryParse(values[5], out int type);
                            int.TryParse(values[6], out int isEvent);
                            bosses.Add(bosses.Count + 1, new DPSReport.BossData() { BossId = bossId, Name = values[1], SuccessMsg = values[2], FailMsg = values[3], Icon = values[4], Type = (DPSReport.BossType)(type), Event = (isEvent == 1) ? true : false });
                        }
                    }
                }
                catch
                {
                    // do nothing, since the file does not exist, or is corrupted (data does not line up)
                }
                if (bosses.Where(anon => anon.Value.BossId.Equals(21333)).Count() == 0)
                {
                    File.AppendAllText($@"{localDir}\boss_data.txt", "21333<;>Freezie<;><boss> kill: <log><;><boss> pull: <log><;>https://dps.report/cache/https_wiki.guildwars2.com_images_thumb_8_8b_Freezie.jpg_189px-Freezie.jpg<;>3<;>0");
                }
            }
            // end of updates
            Properties.Settings.Default.SavedVersion = Properties.Settings.Default.ReleaseVersion;
        }
    }
}
