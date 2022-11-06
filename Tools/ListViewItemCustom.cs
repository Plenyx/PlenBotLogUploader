using System.Windows.Forms;

namespace PlenBotLogUploader.Tools
{
    internal sealed class ListViewItemCustom<T> : ListViewItem
        where T : IListViewItemInfo
    {
        private T _item;

        public T Item
        {
            get => _item;
            set
            {
                _item = value;
                SetUpItem();
            }
        }

        internal ListViewItemCustom() { }

        internal ListViewItemCustom(T item) => Item = item;

        private void SetUpItem()
        {
            Name = Item.NameToDisplay;
            Text = Item.TextToDisplay;
            Checked = Item.CheckedToDisplay;
        }
    }
}
