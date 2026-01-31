using System;
using System.Runtime.InteropServices;

namespace PlenBotLogUploader.Tools;

public static class WineConnoisseur
{
    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    public static bool IsRunningUnderWine()
    {
        var ntdll = GetModuleHandle("ntdll.dll");
        if (ntdll == IntPtr.Zero)
        {
            return false;
        }

        var wineFunc = GetProcAddress(ntdll, "wine_get_version");
        return wineFunc != IntPtr.Zero;
    }
}
