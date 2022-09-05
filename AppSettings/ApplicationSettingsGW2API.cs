using Newtonsoft.Json;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlenBotLogUploader.AppSettings
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApplicationSettingsGW2API
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("apikey")]
        public string APIKey { get; set; }

        public bool Valid { get; set; } = true;

        public List<string> Characters { get; set; } = new List<string>();

        public override string ToString() => $"{Name}{(!Valid ? " (token not valid)" : "")}";

        public async Task<bool> ValidateToken(HttpClientController httpClientController)
        {
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/tokeninfo?access_token={APIKey}");
            Valid = response.IsSuccessStatusCode;
            return Valid;
        }

        public async Task GetCharacters(HttpClientController httpClientController, bool bypassCheck = false)
        {
            if ((Characters.Count > 0) && !bypassCheck)
            {
                return;
            }
            using var response = await httpClientController.GetAsync($"https://api.guildwars2.com/v2/characters?access_token={APIKey}");
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
