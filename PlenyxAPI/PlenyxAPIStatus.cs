namespace PlenBotLogUploader.PlenyxAPI
{
    public class PlenyxAPIStatus
    {
        public int? Code { get; set; }
        public string Msg { get; set; } = "";

        public bool IsSuccess() => (Code ?? 400) == 200 || (Code ?? 400) == 201 || (Code ?? 400) == 204;
    }
}
