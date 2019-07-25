using System;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.DiscordAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsForPlenBotLogUploader
{
    [TestClass]
    public class DiscordTests
    {
        [TestMethod]
        public void TestDiscordWebhookPost()
        {
            using (var httpClient = new HttpClientController())
            {
                var discordContentEmbedThumbnail = new DiscordAPIJSONContentEmbedThumbnail()
                {
                    Url = "https://wiki.guildwars2.com/images/5/5e/Legendary_Insight.png"
                };
                var discordContentEmbed = new DiscordAPIJSONContentEmbed()
                {
                    Title = "Test title",
                    Description = "Test description",
                    Color = 32768,
                    Thumbnail = discordContentEmbedThumbnail
                };
                var discordContent = new DiscordAPIJSONContent()
                {
                    Content = "Test content",
                    Embeds = new List<DiscordAPIJSONContentEmbed>() { discordContentEmbed }
                };
                try
                {
                    var serialiser = new JavaScriptSerializer();
                    serialiser.RegisterConverters(new[] { new DiscordAPIJSONContentConverter() });
                    string jsonContent = serialiser.Serialize(discordContent);
                    var uri = new Uri("https://discordapp.com/api/webhooks/603961017415761937/q3DuX5G_aja2UoJ1D1iXChd846MwJe9Yb5q6cupPHWGiU0vJM4l2UtSRaGF4a82yh6X1");
                    using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
                    {
                        using (httpClient.MainHttpClient.PostAsync(uri, content).Result) { }
                    }
                    Assert.IsTrue(true);
                }
                catch
                {
                    Assert.IsTrue(false);
                }
            }
        }
    }
}
