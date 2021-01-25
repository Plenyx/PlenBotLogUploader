using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PlenBotLogUploader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var currProcess = Process.GetCurrentProcess();
            var otherProcesses = Process.GetProcessesByName("PlenBotLogUploader")
                .Where(anon => !anon.Id.Equals(currProcess.Id))
                .ToList();
            var args = Environment.GetCommandLineArgs().ToList();
            var localDir = $"{Path.GetDirectoryName(Application.ExecutablePath.Replace('/', '\\'))}\\";
            if (args.Count == 3)
            {
                if(args[1].ToLower().Equals("-update"))
                {
                    if (otherProcesses.Count == 0)
                    {
                        File.Copy(Application.ExecutablePath.Replace('/', '\\'), $"{localDir}{args[2]}", true);
                        Process.Start($"{localDir}{args[2]}", "-finishupdate");
                        return;
                    }
                    else
                    {
                        foreach (var process in otherProcesses)
                        {
                            try
                            {
                                process.WaitForExit(350);
                                process.Kill();
                            }
                            catch
                            {
                                // do nothing
                            }
                        }
                        File.Copy(Application.ExecutablePath.Replace('/', '\\'), localDir + args[2], true);
                        Process.Start($"{localDir}{args[2]}", "-finishupdate");
                        return;
                    }
                }
            }
            else if (args.Count == 2)
            {
                if (args[1].ToLower().Equals("-finishupdate"))
                {
                    File.Delete(localDir + "PlenBotLogUploader_Update.exe");
                }
                else if (args[1].ToLower().Equals("-resetsettings"))
                {
                    using (RegistryKey registryRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        if (registryRun.GetValue("PlenBot Log Uploader") != null)
                        {
                            registryRun.DeleteValue("PlenBot Log Uploader");
                        }
                    }
                    Properties.Settings.Default.Reset();
                }
            }
            if (otherProcesses.Count == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }
    }
}
