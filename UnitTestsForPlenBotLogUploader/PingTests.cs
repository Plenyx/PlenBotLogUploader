using PlenBotLogUploader.RemotePing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsForPlenBotLogUploader
{
    [TestClass]
    public class PingTests
    {
        [TestMethod]
        public void TestGetNonAuth()
        {
            PingConfiguration config = new PingConfiguration()
            {
                Active = true,
                Name = "Test ping",
                Method = PingMethod.Get,
                Authentication = new PingAuthentication()
                {
                    Active = true,
                    AuthName = "sign",
                    AuthToken = "testsign",
                    UseAsAuth = false
                },
                URL = "https://plenbot.net/uploader/ping/"
            };
            Assert.IsTrue(config.TestPingAsync().Result.Success);
        }
    }
}
