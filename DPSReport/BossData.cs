namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// An object holding boss information
    /// </summary>
    public class BossData
    {
        /// <summary>
        /// ID of the encounter
        /// </summary>
        public int BossId { get; set; }
        /// <summary>
        /// name of the encounter
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Twitch message when encounter is a success
        /// </summary>
        public string SuccessMsg { get; set; } = "<boss> kill: <log>";
        /// <summary>
        /// Twitch message when encounter is a failure
        /// </summary>
        public string FailMsg { get; set; } = "<boss> pull: <log>";
        /// <summary>
        /// Icon used for Discord webhooks
        /// </summary>
        public string Icon { get; set; } = "";
    }
}
