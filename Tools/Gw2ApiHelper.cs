using Hardstuck.Http;
using Newtonsoft.Json;
using PlenBotLogUploader.Gw2Api;
using System;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    internal sealed class Gw2ApiHelper : IDisposable
    {
        #region definitions
        private readonly HttpClientController HttpClientController = new();
        private const string gw2api = "https://api.guildwars2.com/";
        #endregion

        internal Gw2ApiHelper(string apiKey = "")
        {
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                HttpClientController.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            }
        }

        internal async Task<Gw2Account> GetUserInfoAsync()
        {
            try
            {
                using var accountResponse = await HttpClientController.GetAsync($"{gw2api}v2/account?v=latest");
                var accountContent = await accountResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Gw2Account>(accountContent);
            }
            catch
            {
                return null;
            }
        }

        public void Dispose() => HttpClientController?.Dispose();
    }
}
