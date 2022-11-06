using System.Collections.Generic;

namespace PlenBotLogUploader.Tools
{
    internal interface IListViewItemInfo<T>
        where T : IListViewItemInfo<T>
    {
        internal string NameToDisplay { get; }

        internal string TextToDisplay { get; }

        internal bool CheckedToDisplay { get; }

        internal List<ListViewItemCustom<T>> ConnectedItems { get; }

        internal void UpdateItems()
        {
            foreach (var item in ConnectedItems.AsSpan())
            {
                item.UpdateData();
            }
        }
    }
}
