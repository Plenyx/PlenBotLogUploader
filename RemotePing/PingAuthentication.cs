namespace PlenBotLogUploader.RemotePing
{
    public class PingAuthentication
    {
        public bool Active { get; set; }
        public bool UseAsAuth { get; set; } = false;
        public string AuthName { get; set; } = "";
        public string AuthToken { get; set; } = "";
    }
}
