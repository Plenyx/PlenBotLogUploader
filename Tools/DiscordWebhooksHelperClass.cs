namespace PlenBotLogUploader.Tools;

internal sealed class DiscordWebhooksHelperClass
{
    internal int WebhookId { get; set; }

    internal string Text { get; set; }

    public override string ToString() => Text;
}
