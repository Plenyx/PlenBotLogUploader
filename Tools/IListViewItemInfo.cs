namespace PlenBotLogUploader.Tools
{
    internal interface IListViewItemInfo
    {
        internal string NameToDisplay { get; }

        internal string TextToDisplay { get; }

        internal bool CheckedToDisplay { get; }
    }
}
