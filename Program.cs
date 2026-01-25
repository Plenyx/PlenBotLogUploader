using Microsoft.Win32;
using PlenBotLogUploader.AppSettings;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZLinq;

namespace PlenBotLogUploader;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        var currProcess = Process.GetCurrentProcess();
        var processName = Path.GetFileNameWithoutExtension(Application.ExecutablePath.AsSpan()).ToString();
        var otherProcesses = Process.GetProcessesByName(processName)
            .Where(x => !x.Id.Equals(currProcess.Id))
            .ToArray();
        var args = Environment.GetCommandLineArgs();
        var localDir = $"{Path.GetDirectoryName(Application.ExecutablePath.Replace('/', '\\'))}\\";
        switch (args.Length)
        {
            case 4 when args[1].Equals("-update", StringComparison.OrdinalIgnoreCase) && args[3].Equals("-m", StringComparison.OrdinalIgnoreCase):
            {
                if (otherProcesses.Length == 0)
                {
                    File.Copy(Application.ExecutablePath.Replace('/', '\\'), localDir + args[2], true);
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        FileName = localDir + args[2],
                        Arguments = "-m -finishupdate",
                    });
                    return;
                }
                foreach (var process in otherProcesses.AsValueEnumerable())
                {
                    try
                    {
                        if (!process.WaitForExit(350))
                        {
                            process.Kill();
                        }
                    }
                    catch
                    {
                        // do nothing
                    }
                }
                File.Copy(Application.ExecutablePath.Replace('/', '\\'), localDir + args[2], true);
                Process.Start(new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = localDir + args[2],
                    Arguments = "-m -finishupdate",
                });
                return;
            }
            case 3 when args[2].Equals("-finishupdate", StringComparison.OrdinalIgnoreCase):
                File.Delete($"{localDir}PlenBotLogUploader_Update.exe");
                break;
            case 3 when args[1].Equals("-update", StringComparison.OrdinalIgnoreCase):
            {
                if (otherProcesses.Length == 0)
                {
                    File.Copy(Application.ExecutablePath.Replace('/', '\\'), localDir + args[2], true);
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        FileName = localDir + args[2],
                        Arguments = "-finishupdate",
                    });
                    return;
                }
                foreach (var process in otherProcesses.AsValueEnumerable())
                {
                    try
                    {
                        if (!process.WaitForExit(350))
                        {
                            process.Kill();
                        }
                    }
                    catch
                    {
                        // do nothing
                    }
                }
                File.Copy(Application.ExecutablePath.Replace('/', '\\'), localDir + args[2], true);
                Process.Start(new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = localDir + args[2],
                    Arguments = "-finishupdate",
                });
                return;
            }
            case 2 when args[1].Equals("-finishupdate", StringComparison.OrdinalIgnoreCase):
                File.Delete($"{localDir}PlenBotLogUploader_Update.exe");
                break;
            case 2:
            {
                if (args[1].Equals("-resetsettings", StringComparison.OrdinalIgnoreCase))
                {
                    using (var registrySubKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        if (registrySubKey?.GetValue("PlenBot Log Uploader") != null)
                        {
                            registrySubKey.DeleteValue("PlenBot Log Uploader");
                        }
                    }
                    new ApplicationSettings().Save();
                }
                break;
            }
        }
        if (otherProcesses.Length != 0)
        {
            return;
        }
        Application.EnableVisualStyles();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormMain());
    }
}
