namespace PlenBotLogUploader.Tools
{
    static class CompatibilityUpdate
    {
        public static void DoUpdate()
        {
            if(Properties.Settings.Default.SavedVersion == Properties.Settings.Default.ReleaseVersion)
            {
                return;
            }
            Properties.Settings.Default.SavedVersion = Properties.Settings.Default.ReleaseVersion;
        }
    }
}
