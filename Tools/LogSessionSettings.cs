namespace PlenBotLogUploader.Tools
{
    public class LogSessionSettings
    {
        //string sessionName, string contentText, bool showSuccess, string elapsedTime, int sortBy
        public string Name { get; set; }
        public string ContentText { get; set; }
        public bool ShowSuccess { get; set; }
        public string ElapsedTime { get; set; }
        public LogSessionSortBy SortBy { get; set; }
    }
}
