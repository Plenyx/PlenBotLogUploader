using System.Collections.Generic;

namespace PlenBotLogUploader.Tools;

internal interface IListViewItemInfo<T>
    where T : IListViewItemInfo<T>
{
    /// <summary>
    ///     What name to assign in the list view.
    /// </summary>
    internal string NameToDisplay { get; }

    /// <summary>
    ///     What text to display in the list view.
    /// </summary>
    internal string TextToDisplay { get; }

    /// <summary>
    ///     Whether to display a checkmark in the list view.
    /// </summary>
    internal bool CheckedToDisplay { get; }

    /// <summary>
    ///     All items created as IListViewItemInfo interface.
    /// </summary>
    internal List<ListViewItemCustom<T>> ConnectedItems { get; }

    /// <summary>
    ///     Update all the UI elements of all IListViewItemInfo<T>.
    /// </summary>
    internal void UpdateItems()
    {
        foreach (var item in ConnectedItems.AsSpan())
        {
            item?.UpdateData();
        }
    }
}
