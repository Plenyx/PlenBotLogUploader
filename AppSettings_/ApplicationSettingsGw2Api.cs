using Newtonsoft.Json;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlenBotLogUploader.AppSettings
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class ApplicationSettingsGw2Api
    {
        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("apikey")]
        internal string ApiKey { get; set; }

        internal bool Valid { get; set; } = true;

        internal List<string> Characters { get; set; } = new List<string>();

        public override string ToString() => Name + (!Valid ? " (token not valid)" : "");

        internal async Task<bool> ValidateToken(HttpClientController httpClientController)
        {
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/tokeninfo?access_token={ApiKey}");
            Valid = response.IsSuccessStatusCode;
            return Valid;
        }

        internal async Task GetCharacters(HttpClientController httpClientController, bool bypassCheck = false)
        {
            if ((Characters.Count > 0) && !bypassCheck)
            {
                return;
            }
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/characters?access_token={ApiKey}");
            if (!response.IsSuccessStatusCode)
            {
                Valid = false;
                Characters = new List<string>();
                return;
            }
            var responseMessage = await response.Content.ReadAsStringAsync();
            Characters = JsonConvert.DeserializeObject<List<string>>(responseMessage);
        }
    }
}
