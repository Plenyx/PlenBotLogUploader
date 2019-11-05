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
            // start of updates
            // end of updates
            Properties.Settings.Default.SavedVersion = Properties.Settings.Default.ReleaseVersion;
        }
    }
}
