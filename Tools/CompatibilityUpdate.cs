using System;
using System.IO;
using System.Linq;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader.Tools
{
    static class CompatibilityUpdate
    {
        public static void DoUpdate(string localDir)
        {
            // current version check
            if (Properties.Settings.Default.SavedVersion == Properties.Settings.Default.ReleaseVersion)
            {
                return;
            }
            /// start of updates
            // Release 55
            if (Properties.Settings.Default.SavedVersion < 55)
            {
                /// add Freezie
                try
                {
                    var bosses = Bosses.FromFile($@"{localDir}\boss_data.txt");
                    if (bosses.Where(anon => anon.Value.BossId.Equals((int)BossIds.Freezie)).Count() == 0)
                    {
                        var freezie = new BossData() { BossId = (int)BossIds.Freezie, Name = "Freezie", SuccessMsg = Properties.Settings.Default.BossTemplateSuccess, FailMsg = Properties.Settings.Default.BossTemplateFail, Icon = "https://dps.report/cache/https_wiki.guildwars2.com_images_thumb_8_8b_Freezie.jpg_189px-Freezie.jpg", Type = BossType.Strike };
                        File.AppendAllText($@"{localDir}\boss_data.txt", freezie.ToString(true));
                    }
                }
                catch
                {
                    // do nothing, since the file does not exist, or is corrupted (data does not line up)
                }
            }
            // end of updates
            Properties.Settings.Default.SavedVersion = Properties.Settings.Default.ReleaseVersion;
        }
    }
}
