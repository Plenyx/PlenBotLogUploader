using Newtonsoft.Json;
using PlenBotLogUploader.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordWebhookData
    {
        /// <summary>
        /// Indicates whether the webhook is currently active
        /// </summary>
        public bool Active { get; set; } = false;

        /// <summary>
        /// Name of the webhook
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL of the webhook
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Indicates whether the webhook is executed only if the ecounter is a success
        /// </summary>
        public DiscordWebhookDataSuccessToggle SuccessFailToggle { get; set; } = DiscordWebhookDataSuccessToggle.OnSuccessAndFailure;

        /// <summary>
        /// Indicates whether players are showed in the webhook
        /// </summary>
        public bool ShowPlayers { get; set; } = true;

        /// <summary>
        /// A list containing boss ids which are omitted to be posted via webhook
        /// </summary>
        public List<int> BossesDisable { get; set; } = new List<int>();

        /// <summary>
        /// A selected webhook team, with which the webhook should evaluate itself
        /// </summary>
        public WebhookTeam Team { get; set; }

        /// <summary>
        /// Tests whether webhook is valid
        /// </summary>
        /// <param name="httpController">HttpClientController class used for using http connection</param>
        /// <returns>True if webhook is valid, false otherwise</returns>
        public async Task<bool> TestWebhookAsync(Tools.HttpClientController httpController)
        {
            try
            {
                string response = await httpController.DownloadFileToStringAsync(URL);
                var pingTest = JsonConvert.DeserializeObject<DiscordAPIJSONWebhookResponse>(response);
                return pingTest.Success;
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

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <param name="savableFormat">whether the text should be in savable format</param>
        /// <returns>Returns a string that represents the current object.</returns>
        public string ToString(bool savableFormat = false)
        {
            if (!savableFormat)
            {
                return base.ToString();
            }
            return $"{(Active ? "1" : "0")}<;>{Name}<;>{URL}<;>{(int)SuccessFailToggle}<;>{(ShowPlayers ? "1" : "0")}<;>{string.Join("; ", BossesDisable.Select(x => x.ToString()).ToArray())}<;>{Team?.ID ?? 0}";
        }

        /// <summary>
        /// Creates an DiscordWebhookData object from a serialised format.
        /// </summary>
        /// <param name="savedFormat">string representing the object</param>
        /// <returns>deserilised object of DiscordWebhookData type</returns>
        public static DiscordWebhookData FromSavedFormat(string serialisedFormat)
        {
            try
            {
                string[] values = serialisedFormat.Split(new string[] { "<;>" }, StringSplitOptions.None);
                int.TryParse(values[0], out int active);
                int.TryParse(values[3], out int successFailToggle);
                int.TryParse(values[4], out int showPlayers);
                var bossesDisableList = new List<int>();
                var team = WebhookTeams.All.Values.First();
                if (values.Count() > 5)
                {
                    var bossesDisable = values[5];
                    var bossesDisableSplit = bossesDisable.Split(';');
                    foreach (var bossIdString in bossesDisableSplit)
                    {
                        if (int.TryParse(bossIdString, out int bossId))
                        {
                            bossesDisableList.Add(bossId);
                        }
                    }
                    if (values.Count() > 6)
                    {
                        int.TryParse(values[6], out int teamId);
                        var allTeams = WebhookTeams.All;
                        if (allTeams.TryGetValue(teamId, out WebhookTeam newTeam))
                        {
                            team = newTeam;
                        }
                    }
                }
                return new DiscordWebhookData()
                {
                    Active = active == 1,
                    Name = values[1],
                    URL = values[2],
                    SuccessFailToggle = (DiscordWebhookDataSuccessToggle)successFailToggle,
                    ShowPlayers = showPlayers == 1,
                    BossesDisable = bossesDisableList,
                    Team = team
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
