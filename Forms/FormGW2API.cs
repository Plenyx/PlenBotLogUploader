using Hardstuck.GuildWars2.Builds;
using PlenBotLogUploader.AppSettings;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlenBotLogUploader.Tools;

namespace PlenBotLogUploader
{
    public partial class FormGW2API : Form
    {
        #region definitions
        private readonly FormMain mainLink;
        #endregion

        public FormGW2API(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            RedrawList();
        }

        private void FormGW2API_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void RedrawList()
        {
            listBoxAPIKeys.Items.Clear();
            foreach (var apiKey in ApplicationSettings.Current.GW2APIs)
            {
                listBoxAPIKeys.Items.Add(apiKey);
            }
        }

        private void ListBoxAPIKeys_DoubleClick(object sender, System.EventArgs e)
        {
            if (!(listBoxAPIKeys.SelectedItem is null))
            {
                var item = (ApplicationSettingsGW2API)listBoxAPIKeys.SelectedItem;
                new FormEditGW2API(this, item).ShowDialog();
            }
            listBoxAPIKeys.SelectedItem = null;
        }

        private void ContextMenuStripEditAPIKeys_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var toggle = listBoxAPIKeys.SelectedItem is null;
            toolStripMenuItemEditKey.Enabled = !toggle;
            toolStripMenuItemRemoveKey.Enabled = !toggle;
        }

        private void ToolStripMenuItemAddKey_Click(object sender, System.EventArgs e) => (new FormEditGW2API(this, null)).ShowDialog();

        private void ToolStripMenuItemEditKey_Click(object sender, System.EventArgs e) => (new FormEditGW2API(this, (ApplicationSettingsGW2API)listBoxAPIKeys.SelectedItem)).ShowDialog();

        private void ToolStripMenuItemRemoveKey_Click(object sender, System.EventArgs e)
        {
            ApplicationSettings.Current.GW2APIs.Remove((ApplicationSettingsGW2API)listBoxAPIKeys.SelectedItem);
            ApplicationSettings.Current.Save();
            RedrawList();
        }

        private void ButtonAddAPIKey_Click(object sender, System.EventArgs e) => (new FormEditGW2API(this, null)).ShowDialog();

        private void ButtonGetHardStuckCode_Click(object sender, System.EventArgs e)
        {
            mainLink.MumbleReader?.Update();
            if (!string.IsNullOrWhiteSpace(mainLink.MumbleReader?.Data.Identity?.Name))
            {
                _ = Task.Run(async () =>
                {
                    using var httpClientController = new HttpClientController();
                    foreach (var apiKey in ApplicationSettings.Current.GW2APIs.Where(x => x.Valid))
                    {
                        await apiKey.GetCharacters(httpClientController);
                    }
                    var trueApiKey = ApplicationSettings.Current.GW2APIs.FirstOrDefault(x => x.Characters.Contains(mainLink.MumbleReader.Data.Identity.Name));
                    try
                    {
                        using var parser = new GW2BuildParser(trueApiKey?.APIKey ?? "");
                        var build = await parser.GetAPIBuildAsync(mainLink.MumbleReader.Data.Identity.Name, mainLink.MumbleReader.Data.Context.GameMode);
                        var buildLink = build.GetBuildLink();
                        mainLink.AddToText(buildLink);
                    }
                    catch (NotEnoughPermissionsException ex)
                    {
                        var response = new StringBuilder("The API request failed due to low API key permissions, main reason: ");
                        switch (ex.MissingPermission)
                        {
                            case NotEnoughPermissionsReason.Characters:
                                response.Append("the API key is missing \"characters\" permission");
                                break;
                            case NotEnoughPermissionsReason.Builds:
                                response.Append("the API key is missing \"builds\" permission");
                                break;
                            default:
                                response.Append("the API key is invalid");
                                break;
                        }
                        mainLink.AddToText(response.ToString());
                    }
                });
            }
        }
    }
}
