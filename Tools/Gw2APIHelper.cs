using System;
using System.Threading.Tasks;
using PlenBotLogUploader.GW2API;
using Newtonsoft.Json;

namespace PlenBotLogUploader.Tools
{
    public class Gw2APIHelper : IDisposable
    {
        private readonly HttpClientController HttpClientController = new HttpClientController();
        private const string gw2api = "https://api.guildwars2.com/";
        private readonly string apiKey;

        public Gw2APIHelper(string apiKey = "")
        {
            this.apiKey = apiKey;
        }

        public async Task<GW2Account> GetUserInfoAsync()
        {
            try
            {
                using (var accountResponse = await HttpClientController.GetAsync($"{gw2api}v2/account?access_token={apiKey}"))
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

        public async Task<GW2Server> GetUserServerAsync()
        {
            try
            {
                using (var accountResponse = await HttpClientController.GetAsync($"{gw2api}v2/account?access_token={apiKey}"))
                {
                    var accountContent = await accountResponse.Content.ReadAsStringAsync();
                    var accountInfo = JsonConvert.DeserializeObject<GW2Account>(accountContent);
                    return GW2.GW2Servers[accountInfo.World];
                }
            }
            catch
            {
                return new GW2Server() { ID = 0, Name = "Unknown server" };
            }
        }

        public void Dispose() => HttpClientController?.Dispose();
    }
}
