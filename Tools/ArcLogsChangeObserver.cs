using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PlenBotLogUploader.Tools
{
#nullable enable
    internal class ArcLogsChangeObserver : IDisposable
    {
        private bool disposed = false;
        private readonly Action<FileInfo> callback;
        private string? rootPath;
        private FileSystemWatcher? watcher;
        private Thread? pollThread;
        private CancellationTokenSource? pollThreadCTS;

        public ArcLogsChangeObserver(Action<FileInfo> logCreatedCallback)
        {
            callback = logCreatedCallback;
        }

        public void InitAndStart(string rootPath, ArcLogsChangeObserverMode mode = default)
        {
            if ((pollThread is not null) || (watcher is not null))
            {
                return;
            }

            this.rootPath = rootPath;
            ChangeMode(mode);
        }

        public bool IsRunning => rootPath is not null;

        public void ChangeMode(ArcLogsChangeObserverMode newMode)
        {
            if (newMode == ArcLogsChangeObserverMode.Polling)
            {
                if (pollThread is not null)
                {
                    return;
                }

                watcher?.Dispose();
                watcher = null;

                pollThreadCTS = new();
                pollThread = new(EnterPollThread)
                {
                    IsBackground = true,
                    Name = "Arc Logs Polling",
                };
                pollThread.Start();
            }
            else
            {
                if (watcher is not null)
                {
                    return;
                }

                if (pollThread is not null)
                {
                    pollThreadCTS!.Cancel();
                    pollThread.Interrupt();
                    pollThread.Join();
                    pollThread = null;
                }

                watcher = new()
                {
                    Filter = "*.*",
                    IncludeSubdirectories = true,
                    NotifyFilter = NotifyFilters.FileName,
                };
                // renaming is the last process done by arcdps to create evtc or zevtc files
                watcher.Renamed += OnWatcherEvent;
                if (rootPath is not null)
                {
                    watcher.Path = rootPath;
                    watcher.EnableRaisingEvents = true;
                }
            }
        }

        public void ChangeRootPath(string newPath)
        {
            rootPath = newPath;

            if (watcher is not null)
            {
                watcher.Path = newPath;
            }
        }

        void OnWatcherEvent(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.EndsWith(".evtc") && !e.FullPath.EndsWith(".zevtc"))
            {
                return;
            }

            callback(new(e.FullPath));
        }

        void EnterPollThread()
        {
            var cancellationToken = pollThreadCTS!.Token;
            var pathCache = new HashSet<string>(512); // arbitrary initial size to prevent some early reallocations
            var initialRound = true;
            try
            {
                while (!pollThreadCTS.IsCancellationRequested)
                {
                    foreach (var filePath in Directory.EnumerateFiles(rootPath!, "*.*", SearchOption.AllDirectories))
                    {
                        if (!filePath.EndsWith(".evtc") && !filePath.EndsWith(".zevtc"))
                        {
                            continue;
                        }

                        if (!pathCache.Contains(filePath))
                        {
                            if (!initialRound)
                            {
                                callback(new(filePath));
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

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }
            disposed = true;

            watcher?.Dispose();
            if (pollThread is not null)
            {
                pollThreadCTS!.Cancel();
                pollThread.Interrupt();
                pollThread.Join();
            }
        }
    }
}
