using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PlenBotLogUploader.Tools;
#nullable enable
internal class ArcLogsChangeObserver(Action<FileInfo> logCreatedCallback) : IDisposable
{
    private bool _disposed;
    private Thread? _pollThread;
    private CancellationTokenSource? _pollThreadCts;
    private string? _rootPath;
    private FileSystemWatcher? _watcher;
    public bool IsRunning => _rootPath is not null;
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        _disposed = true;

        _watcher?.Dispose();
        if (_pollThread is not null)
        {
            _pollThreadCts!.Cancel();
            _pollThread.Interrupt();
            _pollThread.Join();
        }
    }
    public void InitAndStart(string rootPath, ArcLogsChangeObserverMode mode = default)
    {
        if (_pollThread is not null || _watcher is not null)
        {
            return;
        }

        _rootPath = rootPath;
        ChangeMode(mode);
    }
    public void ChangeMode(ArcLogsChangeObserverMode newMode)
    {
        if (newMode == ArcLogsChangeObserverMode.Polling)
        {
            if (_pollThread is not null)
            {
                return;
            }

            _watcher?.Dispose();
            _watcher = null;

            _pollThreadCts = new CancellationTokenSource();
            _pollThread = new Thread(EnterPollThread)
            {
                IsBackground = true,
                Name = "Arc Logs Polling",
            };
            _pollThread.Start();
        }
        else
        {
            if (_watcher is not null)
            {
                return;
            }

            if (_pollThread is not null)
            {
                _pollThreadCts!.Cancel();
                _pollThread.Interrupt();
                _pollThread.Join();
                _pollThread = null;
            }

            _watcher = new FileSystemWatcher
            {
                Filter = "*.*",
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName,
            };
            // renaming is the last process done by arcdps to create evtc or zevtc files
            _watcher.Renamed += OnWatcherEvent;
            if (_rootPath is not null)
            {
                _watcher.Path = _rootPath;
                _watcher.EnableRaisingEvents = true;
            }
        }
    }
    public void ChangeRootPath(string newPath)
    {
        _rootPath = newPath;

        if (_watcher is not null)
        {
            _watcher.Path = newPath;
        }
    }
    private void OnWatcherEvent(object sender, FileSystemEventArgs e)
    {
        if (!e.FullPath.EndsWith(".evtc") && !e.FullPath.EndsWith(".zevtc"))
        {
            return;
        }

        logCreatedCallback(new FileInfo(e.FullPath));
    }
    private void EnterPollThread()
    {
        var cancellationToken = _pollThreadCts!.Token;
        var pathCache = new HashSet<string>(512); // arbitrary initial size to prevent some early reallocations
        var initialRound = true;
        try
        {
            while (!_pollThreadCts.IsCancellationRequested)
            {
                foreach (var filePath in Directory.EnumerateFiles(_rootPath!, "*.*", SearchOption.AllDirectories))
                {
                    if (!filePath.EndsWith(".evtc") && !filePath.EndsWith(".zevtc"))
                    {
                        continue;
                    }

                    if (!pathCache.Contains(filePath))
                    {
                        if (!initialRound)
                        {
                            logCreatedCallback(new FileInfo(filePath));
                        }
                        pathCache.Add(filePath);
                    }
                }
                if (initialRound)
                {
                    initialRound = false;
                }
                Thread.Sleep(30000);
            }
        }
        catch (Exception)
        {
            // do nothing
        }
    }
}
