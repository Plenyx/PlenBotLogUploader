using System;
using System.Threading.Tasks;
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

        public async Task<string> GetUserServerAsync()
        {
            try
            {
                var anonDef = new { World = 0 };
                var anonDef2 = new { Name = "" };
                using (var accountResponse = await HttpClientController.GetAsync($"{gw2api}v2/account?access_token={apiKey}"))
                {
                    var accountContent = await accountResponse.Content.ReadAsStringAsync();
                    var accountServer = JsonConvert.DeserializeAnonymousType(accountContent, anonDef);
                    using (var worldResponse = await HttpClientController.GetAsync($"{gw2api}v2/worlds?id={accountServer.World}"))
                    {
                        var worldContent = await worldResponse.Content.ReadAsStringAsync();
                        var serverName = JsonConvert.DeserializeAnonymousType(worldContent, anonDef2);
                        return serverName.Name;
                    }
                }
            }
            catch
            {
                return "Unknown server";
            }
        }

        public void Dispose() => HttpClientController.Dispose();
    }
}
