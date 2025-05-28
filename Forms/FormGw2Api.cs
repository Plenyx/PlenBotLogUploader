using Hardstuck.GuildWars2.BuildCodes.V2;
using Hardstuck.Http;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Properties;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZLinq;

namespace PlenBotLogUploader;

public partial class FormGw2Api : Form
{
    // fields
    private readonly FormMain mainLink;

    internal FormGw2Api(FormMain mainLink)
    {
        this.mainLink = mainLink;
        InitializeComponent();
        Icon = Resources.AppIcon;
        RedrawList();
    }

    private void FormGW2API_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }

    internal void RedrawList()
    {
        listBoxAPIKeys.Items.Clear();
        foreach (var apiKey in ApplicationSettings.Current.Gw2Apis.AsValueEnumerable())
        {
            listBoxAPIKeys.Items.Add(apiKey);
        }
        buttonGetHardstuckBuildLink.Enabled = ApplicationSettings.Current.Gw2Apis.Count > 0;
    }

    private void ListBoxAPIKeys_DoubleClick(object sender, EventArgs e)
    {
        if (listBoxAPIKeys.SelectedItem is ApplicationSettingsGw2Api item)
        {
            new FormEditGw2Api(this, item).ShowDialog();
        }
        listBoxAPIKeys.SelectedItem = null;
    }

    private void ContextMenuStripEditAPIKeys_Opening(object sender, CancelEventArgs e)
    {
        var toggle = listBoxAPIKeys.SelectedItem is null;
        toolStripMenuItemEditKey.Enabled = !toggle;
        toolStripMenuItemRemoveKey.Enabled = !toggle;
    }

    private void ToolStripMenuItemAddKey_Click(object sender, EventArgs e) => new FormEditGw2Api(this, null).ShowDialog();

    private void ToolStripMenuItemEditKey_Click(object sender, EventArgs e) => new FormEditGw2Api(this, (ApplicationSettingsGw2Api)listBoxAPIKeys.SelectedItem).ShowDialog();

    private void ToolStripMenuItemRemoveKey_Click(object sender, EventArgs e)
    {
        ApplicationSettings.Current.Gw2Apis.Remove((ApplicationSettingsGw2Api)listBoxAPIKeys.SelectedItem);
        ApplicationSettings.Current.Save();
        RedrawList();
    }

    private void ButtonAddAPIKey_Click(object sender, EventArgs e) => new FormEditGw2Api(this, null).ShowDialog();

    private void ButtonGetHardStuckCode_Click(object sender, EventArgs e)
    {
        mainLink.MumbleReader?.Update();
        if (string.IsNullOrWhiteSpace(mainLink.MumbleReader?.Data.Identity?.Name))
        {
            return;
        }
        _ = Task.Run(async () =>
        {
            using var httpClientController = new HttpClientController();
            foreach (var apiKey in ApplicationSettings.Current.Gw2Apis.Where(x => x.Valid))
            {
                await apiKey.GetCharacters(httpClientController);
            }
            var trueApiKey = ApplicationSettings.Current.Gw2Apis.Find(x => x.Characters.Contains(mainLink.MumbleReader.Data.Identity.Name));
            if (trueApiKey is null)
            {
                foreach (var apiKey in ApplicationSettings.Current.Gw2Apis.Where(x => x.Valid))
                {
                    await apiKey.GetCharacters(httpClientController, true);
                }
                trueApiKey = ApplicationSettings.Current.Gw2Apis.Find(x => x.Characters.Contains(mainLink.MumbleReader.Data.Identity.Name));
            }
            mainLink.AddToText(">:> Generating a Hardstuck build code for the current character...");
            try
            {
                var code = await APILoader.LoadBuildCodeFromCurrentCharacter(trueApiKey.ApiKey);
                if (ApplicationSettings.Current.BuildCodes.DemoteRunes)
                {
                    code.Rune = Static.LegendaryToSuperior(code.Rune);
                }
                if (ApplicationSettings.Current.BuildCodes.DemoteSigils)
                {
                    code.WeaponSet1.Sigil1 = Static.LegendaryToSuperior(code.WeaponSet1.Sigil1);
                    code.WeaponSet1.Sigil2 = Static.LegendaryToSuperior(code.WeaponSet1.Sigil2);
                    code.WeaponSet2.Sigil1 = Static.LegendaryToSuperior(code.WeaponSet2.Sigil1);
                    code.WeaponSet2.Sigil2 = Static.LegendaryToSuperior(code.WeaponSet2.Sigil2);
                }
                Static.Compress(code, ApplicationSettings.Current.BuildCodes.Compression);
                mainLink.AddToText($"https://hardstuck.gg/gw2/builds/?b={TextLoader.WriteBuildCode(code)}");
            }
            catch (InvalidAccessTokenException)
            {
                mainLink.AddToText("GW2 API access token is not valid.");
            }
            catch (MissingScopesException)
            {
                var missingScopes = APILoader.ValidateScopes(trueApiKey.ApiKey);
                mainLink.AddToText($"GW2 API access token is missing the following required scopes: {string.Join(", ", missingScopes)}.");
            }
            catch (NotFoundException)
            {
                mainLink.AddToText($"The currently logged in character ('{mainLink.MumbleReader.Data.Identity.Name}') could be found using the GW2 API access token '{trueApiKey.Name}'");
            }
            catch (Exception ex)
            {
                mainLink.AddToText($"A unexpected error occured. {ex.GetType()}: {ex.Message}");
            }
        });
    }

    private void ButtonBuildCodeCompressionSettings_Click(object sender, EventArgs e)
    {
        new FormHsBuildCodeCompressionSettings().ShowDialog();
    }
}
