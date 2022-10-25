using Newtonsoft.Json;
using PlenBotLogUploader.GW2API;
using System;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    internal sealed class Gw2APIHelper : IDisposable
    {
        #region definitions
        private readonly HttpClientController HttpClientController = new();
        private const string gw2api = "https://api.guildwars2.com/";
        #endregion

        internal Gw2APIHelper(string apiKey = "")
        {
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                HttpClientController.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            }
        }

        internal async Task<GW2Account> GetUserInfoAsync()
        {
            try
            {
                using var accountResponse = await HttpClientController.GetAsync($"{gw2api}v2/account");
                var accountContent = await accountResponse.Content.ReadAsStringAsync();
                var accountInfo = JsonConvert.DeserializeObject<GW2Account>(accountContent);
                return accountInfo;
            }
            catch
            {
                return null;
            }
        }

        public void Dispose() => HttpClientController?.Dispose();
    }
}
