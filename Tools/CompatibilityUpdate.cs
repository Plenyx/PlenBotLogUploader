using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            Properties.Settings.Default.Upgrade();
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
            // Release 56
            if (Properties.Settings.Default.SavedVersion < 56)
            {
                /// add Voice & Claw Kodas, Boneskinner, Fraenir and Whisper strike missions
                try
                {
                    var bosses = Bosses.FromFile($@"{localDir}\boss_data.txt");
                    if (bosses.Where(anon => anon.Value.BossId.Equals((int)BossIds.TheVoiceAndTheClawOfTheFallen)).Count() == 0)
                    {
                        var kodas = new BossData() { BossId = (int)BossIds.TheVoiceAndTheClawOfTheFallen, Name = "The Voice and The Claw of the Fallen", SuccessMsg = Properties.Settings.Default.BossTemplateSuccess, FailMsg = Properties.Settings.Default.BossTemplateFail, Icon = "https://i.imgur.com/lNXXbnC.png", Type = BossType.Strike };
                        File.AppendAllText($@"{localDir}\boss_data.txt", kodas.ToString(true));
                    }
                    if (bosses.Where(anon => anon.Value.BossId.Equals((int)BossIds.Boneskinner)).Count() == 0)
                    {
                        var boneskinner = new BossData() { BossId = (int)BossIds.Boneskinner, Name = "Boneskinner", SuccessMsg = Properties.Settings.Default.BossTemplateSuccess, FailMsg = Properties.Settings.Default.BossTemplateFail, Icon = "https://i.imgur.com/meYwQmA.png", Type = BossType.Strike };
                        File.AppendAllText($@"{localDir}\boss_data.txt", boneskinner.ToString(true));
                    }
                    if (bosses.Where(anon => anon.Value.BossId.Equals((int)BossIds.FraenirOfJormag)).Count() == 0)
                    {
                        var fraenir = new BossData() { BossId = (int)BossIds.FraenirOfJormag, Name = "Fraenir of Jormag", SuccessMsg = Properties.Settings.Default.BossTemplateSuccess, FailMsg = Properties.Settings.Default.BossTemplateFail, Icon = "https://dps.report/cache/https_wiki.guildwars2.com_images_thumb_6_67_Fraenir_of_Jormag.jpg_208px-Fraenir_of_Jormag.jpg", Type = BossType.Strike };
                        File.AppendAllText($@"{localDir}\boss_data.txt", fraenir.ToString(true));
                    }
                    if (bosses.Where(anon => anon.Value.BossId.Equals((int)BossIds.WhisperOfJormag)).Count() == 0)
                    {
                        var whisper = new BossData() { BossId = (int)BossIds.WhisperOfJormag, Name = "Whisper of Jormag", SuccessMsg = Properties.Settings.Default.BossTemplateSuccess, FailMsg = Properties.Settings.Default.BossTemplateFail, Icon = "https://wiki.guildwars2.com/images/c/c0/Mini_Whisper_of_Jormag.png", Type = BossType.Strike };
                        File.AppendAllText($@"{localDir}\boss_data.txt", whisper.ToString(true));
                    }
                }
                catch
                {
                    // do nothing, since the file does not exist, or is corrupted (data does not line up)
                }
            }
            // Release 57
            if (Properties.Settings.Default.SavedVersion < 57)
            {
                /// add another parameter for webhook txt file
                try
                {
                    var lines = new List<string>();
                    using (StreamReader reader = new StreamReader($@"{localDir}\discord_webhooks.txt"))
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                        while ((line = reader.ReadLine()) != null)
                        {
                            lines.Add($"{line}<;>");
                        }
                    }
                    File.WriteAllLines($@"{localDir}\discord_webhooks.txt", lines);
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
