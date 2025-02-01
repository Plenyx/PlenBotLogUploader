using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Tools;
using PlenBotLogUploader.Twitch;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlenBotLogUploader.Forms;

public partial class FormEditTwitchCommand : Form
{
    // constants
    private const string variableListLink = "https://github.com/Plenyx/PlenBotLogUploader/blob/main/Twitch/TwitchResponseVariables.md";
    // fields
    private readonly TwitchCommand data;
    private readonly FormTwitchCommands editLink;

    internal FormEditTwitchCommand(FormTwitchCommands editLink, TwitchCommand data)
    {
        this.editLink = editLink;
        InitializeComponent();
        this.data = data;
        Icon = Resources.AppIcon;
        Text = data is null ? "Add a Twitch command" : $"Edit the Twitch command: {data.Name}";
        textBoxTwitchCommandName.Text = data?.Name ?? "";
        checkBoxIsRegEx.Checked = data?.IsRegEx ?? false;
        textBoxTwitchCommandCommand.Text = data?.Command ?? "";
        textBoxResponse.Text = data?.Response ?? "";
        radioButtonResponseTypeReplyPlain.Checked = (data?.ResponseType ?? TwitchResponseType.ReplyAt) == TwitchResponseType.Plain;
        radioButtonResponseTypeReplyAt.Checked = (data?.ResponseType ?? TwitchResponseType.ReplyAt) == TwitchResponseType.ReplyAt;
    }

    private void FormEditTwitchCommand_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxTwitchCommandName.Text))
        {
            return;
        }
        if (data is null)
        {
            var twitchCommand = new TwitchCommand
            {
                Enabled = false,
                Name = textBoxTwitchCommandName.Text,
                IsRegEx = checkBoxIsRegEx.Checked,
                Command = textBoxTwitchCommandCommand.Text,
                Response = textBoxResponse.Text,
                ResponseType = radioButtonResponseTypeReplyAt.Checked ? TwitchResponseType.ReplyAt : TwitchResponseType.Plain,
            };
            TwitchCommands.All.Add(twitchCommand);
            editLink.listViewTwitchCommands.Items.Add(new ListViewItemCustom<TwitchCommand> { Item = twitchCommand });
        }
        else
        {
            data.Name = textBoxTwitchCommandName.Text;
            data.IsRegEx = checkBoxIsRegEx.Checked;
            data.Command = textBoxTwitchCommandCommand.Text;
            data.Response = textBoxResponse.Text;
            data.ResponseType = radioButtonResponseTypeReplyAt.Checked ? TwitchResponseType.ReplyAt : TwitchResponseType.Plain;
            (data as IListViewItemInfo<TwitchCommand>).UpdateItems();
        }
    }

    private void LinkLabelInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = variableListLink });
}
