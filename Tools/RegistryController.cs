using System;
using Microsoft.Win32;

namespace PlenBotLogUploader.Tools
{
    public class RegistryController: IDisposable
    {
        // private
        private readonly RegistryKey registryAccess = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Plenyx\PlenBotUploader");

        public bool SetRegistryValue(string name, object value)
        {
            try
            {
                registryAccess.SetValue(name, value);
                registryAccess.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T GetRegistryValue<T>(string name, T defaultValue = default(T))
        {
            try
            {
                return (T)registryAccess.GetValue(name, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        public void Dispose()
        {
            registryAccess?.Flush();
            registryAccess?.Dispose();
        }
    }
}
