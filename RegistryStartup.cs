using Microsoft.Win32;

namespace PlenBotLogUploader
{
    public static class RegistryStartup
    {
        public static void DoStartup(RegistryKey registryAccess)
        {
            if (registryAccess.GetValue("logsLocation") == null)
            {
                registryAccess.SetValue("logsLocation", "");
            }
            if (registryAccess.GetValue("channel") == null)
            {
                registryAccess.SetValue("channel", "");
            }
            if (registryAccess.GetValue("uploadAll") == null)
            {
                registryAccess.SetValue("uploadAll", 1);
            }
            if (registryAccess.GetValue("uploadToTwitch") == null)
            {
                registryAccess.SetValue("uploadToTwitch", 1);
            }
            if (registryAccess.GetValue("uploadTwitchOnlySuccess") == null)
            {
                registryAccess.SetValue("uploadTwitchOnlySuccess", 0);
            }
            if (registryAccess.GetValue("uploadIgnoreSize") == null)
            {
                registryAccess.SetValue("uploadIgnoreSize", 0);
            }
            if (registryAccess.GetValue("wepSkill1") == null)
            {
                registryAccess.SetValue("wepSkill1", 1);
            }
            if (registryAccess.GetValue("dpsReportServer") == null)
            {
                registryAccess.SetValue("dpsReportServer", 0);
            }
            if (registryAccess.GetValue("trayMinimise") == null)
            {
                registryAccess.SetValue("trayMinimise", 1);
            }
            if (registryAccess.GetValue("twitchCustomNameEnabled") == null)
            {
                registryAccess.SetValue("twitchCustomNameEnabled", 0);
                registryAccess.SetValue("twitchCustomName", "");
                registryAccess.SetValue("twitchCustomOAuth", "");
            }
            if (registryAccess.GetValue("connectToTwitch") == null)
            {
                registryAccess.SetValue("connectToTwitch", 1);
            }
            if (registryAccess.GetValue("raidarEnabled") == null)
            {
                registryAccess.SetValue("raidarEnabled", 0);
                registryAccess.SetValue("raidarOAuth", "");
                registryAccess.SetValue("raidarTags", "");
            }
            if (registryAccess.GetValue("gw2Location") == null)
            {
                registryAccess.SetValue("gw2Location" , "");
            }
            registryAccess.Flush();
        }
    }
}
