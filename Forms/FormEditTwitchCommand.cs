using PlenBotLogUploader.Tools;
using PlenBotLogUploader.Twitch;
using System.Windows.Forms;

namespace PlenBotLogUploader.Forms
{
    public partial class FormEditTwitchCommand : Form
    {
        #region definitions
        // fields
        private readonly FormTwitchCommands editLink;
        private readonly TwitchCommand data;
        #endregion

        internal FormEditTwitchCommand(FormTwitchCommands editLink, TwitchCommand data)
        {
            this.editLink = editLink;
            InitializeComponent();
            this.data = data;
            Icon = Properties.Resources.AppIcon;
            Text = (data is null) ? "Add a Twitch command" : $"Edit the Twitch command: {data.Name}";
            textBoxTwitchCommandName.Text = data?.Name ?? "";
            checkBoxIsRegex.Checked = data?.IsRegex ?? false;
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
                var twitchCommand = new TwitchCommand()
                {
                    Enabled = false,
                    Name = textBoxTwitchCommandName.Text,
                    IsRegex = checkBoxIsRegex.Checked,
                    Command = textBoxTwitchCommandCommand.Text,
                    Response = textBoxResponse.Text,
                    ResponseType = radioButtonResponseTypeReplyAt.Checked ? TwitchResponseType.ReplyAt : TwitchResponseType.Plain,
                };
                TwitchCommands.All.Add(twitchCommand);
                editLink.listViewTwitchCommands.Items.Add(new ListViewItemCustom<TwitchCommand>() { Item = twitchCommand });
            }
            else
            {
                data.Name = textBoxTwitchCommandName.Text;
                data.IsRegex = checkBoxIsRegex.Checked;
                data.Command = textBoxTwitchCommandCommand.Text;
                data.Response = textBoxResponse.Text;
                data.ResponseType = radioButtonResponseTypeReplyAt.Checked ? TwitchResponseType.ReplyAt : TwitchResponseType.Plain;
                (data as IListViewItemInfo<TwitchCommand>).UpdateItems();
            }
        }
    }
}
