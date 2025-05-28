using PlenBotLogUploader.Forms;
using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.Twitch;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ZLinq;

namespace PlenBotLogUploader;

public partial class FormTwitchCommands : Form
{
    internal FormTwitchCommands()
    {
        InitializeComponent();
        Icon = Resources.AppIcon;
        TwitchCommands.Load();
        foreach (var command in TwitchCommands.All.AsValueEnumerable())
        {
            listViewTwitchCommands.Items.Add(new ListViewItemCustom<TwitchCommand>
            {
                Item = command,
            });
        }
    }

    private void FormTwitchCommands_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
        TwitchCommands.Save();
    }

    private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
    {
        var toggle = listViewTwitchCommands.SelectedItems.Count > 0;
        toolStripMenuItemEdit.Enabled = toggle;
        toolStripMenuItemDelete.Enabled = toggle;
    }

    private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
    {
        if (listViewTwitchCommands.SelectedItems[0] is not ListViewItemCustom<TwitchCommand> item)
        {
            return;
        }
        listViewTwitchCommands.SelectedItems.Clear();
        TwitchCommands.All.Remove(item.Item);
        listViewTwitchCommands.Items.Remove(item);
    }

    private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
    {
        if (listViewTwitchCommands.SelectedItems[0] is not ListViewItemCustom<TwitchCommand> item)
        {
            return;
        }
        new FormEditTwitchCommand(this, item.Item).ShowDialog();
    }

    private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
    {
        new FormEditTwitchCommand(this, null).ShowDialog();
    }

    private void ButtonAddTwitchCommand_Click(object sender, EventArgs e)
    {
        new FormEditTwitchCommand(this, null).ShowDialog();
    }

    private void ListViewTwitchCommands_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if (e.Item is not ListViewItemCustom<TwitchCommand> item)
        {
            return;
        }
        item.Item.Enabled = item.Checked;
    }
}
