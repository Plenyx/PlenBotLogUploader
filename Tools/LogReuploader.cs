using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    internal static class LogReuploader
    {
        internal static readonly string fileLocation = $@"{ApplicationSettings.LocalDir}\faileduploads.txt";

        private static List<string> _failedLogs;
        private static readonly Dictionary<string, string> postData = new()
            {
                { "generator", "ei" },
                { "json", "1" }
            };

        internal static List<string> FailedLogs
        {
            get
            {
                if (_failedLogs is null)
                {
                    if (File.Exists(fileLocation))
                    {
                        try
                        {
                            _failedLogs = File.ReadAllLines(fileLocation).Where(File.Exists).ToList();
                        }
                        catch
                        {
                            _failedLogs = [];
                        }
                    }
                    else
                    {
                        _failedLogs = [];
                    }
                }
                return _failedLogs;
            }
        }

        internal static void SaveFailedLogs()
        {
            try
            {
                File.WriteAllLines(fileLocation, FailedLogs);
            }
            catch
            {
                // do nothing
            }
        }

        internal static void ProcessLogs(Func<string, Dictionary<string, string>, bool, Task> process)
        {
            foreach (var fileName in FailedLogs.ToArray().AsSpan())
            {
                if (!File.Exists(fileName))
                {
                    FailedLogs.Remove(fileName);
                    continue;
                }
                _ = process(fileName, postData, false);
            }
        }
    }
}
