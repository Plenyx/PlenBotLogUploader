using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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

        internal static async Task ProcessLogs(SemaphoreSlim semaphore, Func<string, Dictionary<string, string>, bool, Task> process)
        {
            foreach (var fileName in FailedLogs.ToArray())
            {
                if (!File.Exists(fileName))
                {
                    FailedLogs.Remove(fileName);
                    continue;
                }
                await Task.Run(async () =>
                {
                    semaphore.Wait();
                    await process(fileName, postData, false);
                    semaphore.Release();
                });
            }
        }
    }
}
