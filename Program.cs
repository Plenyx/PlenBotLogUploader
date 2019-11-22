using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

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
                .ToList()
                .Where(anon => !anon.Id.Equals(currProcess.Id))
                .ToList();
            if (otherProcesses.Count == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }
    }
}
