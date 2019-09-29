namespace PlenBotLogUploader.DiscordAPI
{
    public class DiscordAPIJSONContentEmbedFooter
    {
        public string Text { get; set; } = $"PlenBot Log Uploader release {Properties.Settings.Default.ReleaseVersion}";
        public string Icon_url { get; set; } = "https://plenbot.net/uploader/img/favicon.png";
    }
}
