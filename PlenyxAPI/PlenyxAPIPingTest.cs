namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIPingTest
    {
        public PlenyxAPIStatus Status { get; set; }
        public PlenyxAPIError Error { get; set; }

        public bool IsValid() => (Status?.Code ?? 400) == 200;
    }
}
