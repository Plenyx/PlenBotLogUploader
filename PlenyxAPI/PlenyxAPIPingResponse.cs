namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIPingResponse
    {
        public PlenyxAPIStatus Status { get; set; }
        public PlenyxAPIStatus Error { get; set; }
        public int? User_id { get; set; }
        public string Log_id { get; set; } = "";
    }
}
