using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZLinq;

namespace PlenBotLogUploader.Tools;

internal static class LogReuploader
{
    private static readonly string FileLocation = $@"{ApplicationSettings.LocalDir}\faileduploads.txt";

    private static HashSet<string> _failedLogs;
    private static readonly Dictionary<string, string> PostData = new()
    {
        { "generator", "ei" },
        { "json", "1" },
    };

    internal static HashSet<string> FailedLogs
    {
        get
        {
            if (_failedLogs is null)
            {
                if (File.Exists(FileLocation))
                {
                    try
                    {
                        _failedLogs = File.ReadAllLines(FileLocation).Where(File.Exists).ToHashSet();
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
            File.WriteAllLines(FileLocation, FailedLogs);
        }
        catch
        {
            // do nothing
        }
    }

    internal static bool RemovedLogAndSave(string file)
    {
        var removed = FailedLogs.Remove(file);
        if (removed)
        {
            SaveFailedLogs();
        }
        return removed;
    }

    internal static void ProcessLogs(SemaphoreSlim semaphore, Func<string, Dictionary<string, string>, bool, Task> process)
    {
        foreach (var fileName in FailedLogs.ToArray().AsValueEnumerable())
        {
            if (!File.Exists(fileName))
            {
                FailedLogs.Remove(fileName);
                continue;
            }
            _ = Task.Run(async () =>
            {
                semaphore.Wait();
                await process(fileName, PostData, true);
                semaphore.Release();
            });
        }
    }
}
