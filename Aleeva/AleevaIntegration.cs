using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Teams;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlenBotLogUploader.Aleeva
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class AleevaIntegration : IListViewItemInfo<AleevaIntegration>
    {
        [JsonProperty("active")]
        internal bool Active { get; set; } = true;

        [JsonProperty("name")]
        internal string Name { get; set; } = "";

        [JsonProperty("channel")]
        internal string Channel { get; set; } = "";

        [JsonProperty("sendNotification")]
        internal bool SendNotification { get; set; } = false;

        [JsonProperty("sendOnSuccessOnly")]
        internal bool SendOnSuccessOnly { get; set; } = false;

        [JsonProperty("server")]
        internal string Server { get; set; } = "";

        [JsonProperty("teamId")]
        internal int TeamId { get; set; } = 0;

        /// <summary>
        /// A selected integration team, with which the Aleeva integration should evaluate itself
        /// </summary>
        internal Team Team
        {
            get
            {
                if ((_team is null) && Teams.Teams.All.TryGetValue(TeamId, out var team))
                {
                    _team = team;
                }
                return _team;
            }
            set
            {
                _team = value;
                TeamId = value.Id;
            }
        }

        private Team _team;

        internal bool Valid => !string.IsNullOrWhiteSpace(Server) && !string.IsNullOrWhiteSpace(Channel);

        internal List<ListViewItemCustom<AleevaIntegration>> connectedItems;

        string IListViewItemInfo<AleevaIntegration>.NameToDisplay => Name;

        string IListViewItemInfo<AleevaIntegration>.TextToDisplay => ((!string.IsNullOrWhiteSpace(Name)) ? Name : (!string.IsNullOrWhiteSpace(Channel) ? $"C{Channel}" : $"S{Server}"));

        bool IListViewItemInfo<AleevaIntegration>.CheckedToDisplay => Active;

        List<ListViewItemCustom<AleevaIntegration>> IListViewItemInfo<AleevaIntegration>.ConnectedItems => connectedItems ??= new();

        internal async Task PostLogToAleeva(FormMain mainLink, HttpClientController controller, DpsReportJson reportJSON)
        {
            if (!ApplicationSettings.Current.Aleeva.Authorised)
            {
                return;
            }
            if (ApplicationSettings.Current.Aleeva.AccessTokenExpire <= DateTime.Now)
            {
                await AleevaStatics.GetAleevaTokenFromRefreshToken(mainLink, controller);
            }
            if ((SendOnSuccessOnly && !(reportJSON.Encounter.Success ?? false)) ||
                (!(Team?.IsSatisfied(reportJSON.ExtraJson) ?? false)))
            {
                return;
            }
            try
            {
                var uri = new Uri($"{AleevaStatics.ApiBaseUrl}/report");
                var logObject = new AleevaAddReport() { DpsReportPermalink = reportJSON.ConfigAwarePermalink, SendNotification = SendNotification };
                if (SendNotification)
                {
                    logObject.NotificationServerId = Server;
                    logObject.NotificationChannelId = Channel;
                }
                var jsonLogObject = JsonConvert.SerializeObject(logObject);
                using var content = new StringContent(jsonLogObject, Encoding.UTF8, "application/json");
                await controller.PostAsync(uri, content);
            }
            catch
            {
                // do nothing
            }
        }
    }
}
