using Microsoft.Win32;

namespace PlenBotLogUploader
{
    public static class RegistryStartup
    {
        public static void DoStartup()
        {
            using (RegistryKey RegistryAccess = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Plenyx\PlenBotUploader"))
            {
                if (RegistryAccess.GetValue("logsLocation") == null)
                {
                    RegistryAccess.SetValue("logsLocation", "");
                }
                if (RegistryAccess.GetValue("channel") == null)
                {
                    RegistryAccess.SetValue("channel", "");
                }
                if (RegistryAccess.GetValue("uploadAll") == null)
                {
                    RegistryAccess.SetValue("uploadAll", 1);
                }
                if (RegistryAccess.GetValue("uploadToTwitch") == null)
                {
                    RegistryAccess.SetValue("uploadToTwitch", 1);
                }
                if (RegistryAccess.GetValue("uploadTwitchOnlySuccess") == null)
                {
                    RegistryAccess.SetValue("uploadTwitchOnlySuccess", 0);
                }
                if (RegistryAccess.GetValue("uploadIgnoreSize") == null)
                {
                    RegistryAccess.SetValue("uploadIgnoreSize", 0);
                }
                if (RegistryAccess.GetValue("wepSkill1") == null)
                {
                    RegistryAccess.SetValue("wepSkill1", 1);
                }
                if (RegistryAccess.GetValue("dpsReportServer") == null)
                {
                    RegistryAccess.SetValue("dpsReportServer", 0);
                }
                if (RegistryAccess.GetValue("trayMinimise") == null)
                {
                    RegistryAccess.SetValue("trayMinimise", 1);
                }
                if (RegistryAccess.GetValue("remotePingEnabled") == null)
                {
                    RegistryAccess.SetValue("remotePingEnabled", 0);
                    RegistryAccess.SetValue("remotePingMethod", 0);
                    RegistryAccess.SetValue("remotePingURL", "");
                    RegistryAccess.SetValue("remotePingSign", "");
                }
                if (RegistryAccess.GetValue("twitchCustomNameEnabled") == null)
                {
                    RegistryAccess.SetValue("twitchCustomNameEnabled", 0);
                    RegistryAccess.SetValue("twitchCustomName", "");
                    RegistryAccess.SetValue("twitchCustomOAuth", "");
                }
                if (RegistryAccess.GetValue("connectToTwitch") == null)
                {
                    RegistryAccess.SetValue("connectToTwitch", 1);
                }
                if (RegistryAccess.GetValue("raidarEnabled") == null)
                {
                    RegistryAccess.SetValue("raidarEnabled", 0);
                    RegistryAccess.SetValue("raidarOAuth", "");
                    RegistryAccess.SetValue("raidarTags", "");
                }
                RegistryAccess.Flush();
            }
        }
    }
}
