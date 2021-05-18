using Newtonsoft.Json;
using PlenBotLogUploader.GW2API;
using System;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Tools
{
    public class Gw2APIHelper : IDisposable
    {
        private readonly HttpClientController HttpClientController = new HttpClientController();
        private const string gw2api = "https://api.guildwars2.com/";

        public Gw2APIHelper(string apiKey = "")
        {
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                HttpClientController.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            }
        }

        public async Task<GW2Account> GetUserInfoAsync()
        {
            try
            {
                using (var accountResponse = await HttpClientController.GetAsync($"{gw2api}v2/account"))
                {
                    var accountContent = await accountResponse.Content.ReadAsStringAsync();
                    var accountInfo = JsonConvert.DeserializeObject<GW2Account>(accountContent);
                    return accountInfo;
                }
            }
            catch
            {
                return null;
            }
        }

        public void Dispose() => HttpClientController?.Dispose();
    }
}
