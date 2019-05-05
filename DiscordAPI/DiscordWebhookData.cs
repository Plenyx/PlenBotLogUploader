namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordWebhookData
    {
        public bool Active { get; set; }
        public string Name { get; }
        public string URL { get; }
        public bool OnlySuccess { get; set; }

        public DiscordWebhookData(bool active, string name, string url, bool onlySuccess = false)
        {
            Active = active;
            Name = name;
            URL = url;
            OnlySuccess = onlySuccess;
        }
    }
}
