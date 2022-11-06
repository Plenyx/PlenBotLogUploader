using System.Windows.Forms;

namespace PlenBotLogUploader.Tools
{
    internal sealed class ListViewItemCustom<T> : ListViewItem
        where T : IListViewItemInfo<T>
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

        internal void UpdateData()
        {
            Name = Item.NameToDisplay;
            Text = Item.TextToDisplay;
            Checked = Item.CheckedToDisplay;
        }

        private void SetUpItem()
        {
            if (!Item.ConnectedItems.Contains(this))
            {
                Item.ConnectedItems.Add(this);
            }
            Name = Item.NameToDisplay;
            Text = Item.TextToDisplay;
            Checked = Item.CheckedToDisplay;
        }
    }
}
