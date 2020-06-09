namespace PlenBotLogUploader.Tools
{
    public class DiscordWebhooksHelperClass
    {
        public int WebhookID { get; set; }

        public string Text { get; set; }

        public override string ToString() => Text;
    }
}
