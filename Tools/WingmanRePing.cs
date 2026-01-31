using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZLinq;

namespace PlenBotLogUploader.Tools;

public static class WingmanRePing
{
    private static readonly string FileLocation = $@"{ApplicationSettings.LocalDir}\wingmanreping.json";
    
    private static HashSet<WingmanPingInfo> _logsToPing;

    internal static HashSet<WingmanPingInfo> LogsToPing
    {
        get
        {
            if (_logsToPing is not null)
            {
                return _logsToPing;
            }
            if (File.Exists(FileLocation))
            {
                try
                {
                    _logsToPing = JsonConvert.DeserializeObject<List<WingmanPingInfo>>(File.ReadAllText(FileLocation))
                        .AsValueEnumerable()
                        .Where(x => File.Exists(x.FilePath))
                        .ToHashSet();
                }
                catch
                {
                    _logsToPing = [];
                }
            }
            else
            {
                _logsToPing = [];
            }
            return _logsToPing;
        }
    }
    
    internal static void SaveLogsToPing()
    {
        try
        {
            File.WriteAllText(FileLocation, JsonConvert.SerializeObject(LogsToPing, Formatting.Indented));
        }
        catch
        {
            // do nothing
        }
    }

    internal static void RemoveLogAndSave(string file)
    {
        var logToRemove = LogsToPing
            .AsValueEnumerable()
            .FirstOrDefault(x => file.Equals(x.FilePath) && File.Exists(x.FilePath));
        if (logToRemove is null)
        {
            return;
        }
        var removed = LogsToPing.Remove(logToRemove);
        if (removed)
        {
            SaveLogsToPing();
        }
    }

    internal static void ProcessLogs(SemaphoreSlim semaphore, Func<string, DpsReportJsonExtraJson, Task> process)
    {
        foreach (var wingmanPingInfo in LogsToPing.AsValueEnumerable())
        {
            if (!File.Exists(wingmanPingInfo.FilePath))
            {
                LogsToPing.Remove(wingmanPingInfo);
                continue;
            }
            _ = Task.Run(async () =>
            {
                var convertedExtraJson = new DpsReportJsonExtraJson()
                {
                    TriggerId = wingmanPingInfo.TriggerId,
                    RecordedByAccountName = wingmanPingInfo.UploadedBy,
                };
                await semaphore.WaitAsync();
                await process(wingmanPingInfo.FilePath, convertedExtraJson);
                semaphore.Release();
            });
        }
    }
}
