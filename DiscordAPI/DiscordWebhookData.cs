using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordWebhookData
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public bool OnlySuccess { get; set; }

        public async Task<bool> TestWebhookAsync(FormMain mainLink)
        {
            try
            {
                string response = await mainLink.DownloadFileToStringAsync($"{URL}");
                DiscordAPIJSONWebhookResponse pingtest = new JavaScriptSerializer().Deserialize<DiscordAPIJSONWebhookResponse>(response);
                return pingtest.IsSuccess();
            }
            catch
            {
                return false;
            }
        }
    }
}
