namespace PlenBotLogUploader.RemotePing
{
    public class TestPingResult
    {
        public bool Success { get; }
        public string Message { get; }

        public TestPingResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
