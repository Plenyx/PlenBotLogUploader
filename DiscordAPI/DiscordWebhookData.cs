using Newtonsoft.Json;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlenBotLogUploader.DiscordAPI
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DiscordWebhookData
    {
        /// <summary>
        /// Indicates whether the webhook is currently active
        /// </summary>
        [JsonProperty("isActive")]
        public bool Active { get; set; } = false;

        /// <summary>
        /// Name of the webhook
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// URL of the webhook
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Indicates whether the webhook is executed only if the ecounter is a success
        /// </summary>
        [JsonProperty("successFailToggle")]
        public DiscordWebhookDataSuccessToggle SuccessFailToggle { get; set; } = DiscordWebhookDataSuccessToggle.OnSuccessAndFailure;

        /// <summary>
        /// Indicates whether players are showed in the webhook
        /// </summary>
        [JsonProperty("showPlayers")]
        public bool ShowPlayers { get; set; } = true;

        /// <summary>
        /// A list containing boss ids which are omitted to be posted via webhook
        /// </summary>
        [JsonProperty("disabledBosses")]
        public List<int> BossesDisable { get; set; } = new List<int>();

        [JsonProperty("teamId")]
        public int TeamID { get; set; } = 0;

        /// <summary>
        /// A selected webhook team, with which the webhook should evaluate itself
        /// </summary>
        public Team Team
        {
            get
            {
                if (_team is null)
                {
                    if (Teams.Teams.All.TryGetValue(TeamID, out Team team))
                    {
                        _team = team;
                    }
                }
                return _team;
            }
            set
            {
                _team = value;
                TeamID = value.ID;
            }
        }

        private Team _team;

        /// <summary>
        /// Tests whether webhook is valid
        /// </summary>
        /// <param name="httpController">HttpClientController class used for using http connection</param>
        /// <returns>True if webhook is valid, false otherwise</returns>
        public async Task<bool> TestWebhookAsync(HttpClientController httpController)
        {
            try
            {
                var response = await httpController.DownloadFileToStringAsync(URL);
                var pingTest = JsonConvert.DeserializeObject<DiscordAPIJSONWebhookResponse>(response);
                return pingTest?.Success ?? false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// True if boss is enabled for webhook broadcast, false otherwise; default: true
        /// </summary>
        /// <param name="bossId">Queried boss ID</param>
        /// <returns></returns>
        public bool IsBossEnabled(int bossId) => !BossesDisable.Contains(bossId);

        public static IDictionary<int, DiscordWebhookData> FromJsonString(string jsonString)
        {
            var webhookId = 1;

            var parsedData = JsonConvert.DeserializeObject<IEnumerable<DiscordWebhookData>>(jsonString)
                             ?? throw new JsonException("Could not parse json to WebhookData");

            var result = parsedData.Select(x => (Key: webhookId++, DiscordWebhookData: x))
                .ToDictionary(x => x.Key, x => x.DiscordWebhookData);

            return result;
        }
    }
}