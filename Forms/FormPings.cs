using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Properties;
using PlenBotLogUploader.RemotePing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormPings : Form
{
    // fields
    private static readonly string PingJsonFileLocation = $@"{ApplicationSettings.LocalDir}\remote_pings.json";
    private readonly FormMain mainLink;
    private int settingsIdsKey;

    internal FormPings(FormMain mainLink)
    {
        this.mainLink = mainLink;
        InitializeComponent();
        Icon = Resources.AppIcon;
        AllPings = LoadPings();

        settingsIdsKey = AllPings.Count;

        foreach (var ping in AllPings)
        {
            listViewPings.Items.Add(new ListViewItem
            {
                Name = ping.Key.ToString(),
                Text = ping.Value.Name,
                Checked = ping.Value.Active,
            });
        }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal IDictionary<int, PingConfiguration> AllPings { get; init; }

    private static IDictionary<int, PingConfiguration> LoadFromJsonFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var remotePingId = 1;

        var parsedData = JsonConvert.DeserializeObject<IEnumerable<PingConfiguration>>(jsonData) ??
                         throw new JsonException("Could not parse json to PingConfiguration");

        var result = parsedData.Select(x => (Key: remotePingId++, PinConfiguration: x))
            .ToDictionary(x => x.Key, x => x.PinConfiguration);

        return result;
    }

    private static void SaveToJson(IEnumerable<PingConfiguration> pingConfigurations)
    {
        var jsonString = JsonConvert.SerializeObject(pingConfigurations, Formatting.Indented);

        File.WriteAllText(PingJsonFileLocation, jsonString, Encoding.UTF8);
    }

    private void FormPings_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
        SaveToJson(AllPings.Values);
    }

    internal async Task ExecuteAllPingsAsync(DpsReportJson reportJson)
    {
        foreach (var key in AllPings.Keys)
        {
            if (AllPings[key].Active)
            {
                await AllPings[key].PingServerAsync(mainLink, reportJson);
            }
        }
    }

    private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
    {
        if (listViewPings.SelectedItems.Count == 0)
        {
            return;
        }
        var selected = listViewPings.SelectedItems[0];
        if (!int.TryParse(selected.Name, out var reservedId))
        {
            return;
        }
        new FormEditPing(this, reservedId, false, AllPings[reservedId]).ShowDialog();
    }

    private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
    {
        if (listViewPings.SelectedItems.Count == 0)
        {
            return;
        }
        var selected = listViewPings.SelectedItems[0];
        if (!int.TryParse(selected.Name, out var reservedId))
        {
            return;
        }
        listViewPings.Items.RemoveByKey(reservedId.ToString());
        AllPings.Remove(reservedId);
    }

    private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
    {
        var toggle = listViewPings.SelectedItems.Count > 0;
        toolStripMenuItemEdit.Enabled = toggle;
        toolStripMenuItemDelete.Enabled = toggle;
        toolStripMenuItemTest.Enabled = toggle;
    }

    private void ListViewDiscordWebhooks_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if (!int.TryParse(e.Item.Name, out var reservedId))
        {
            return;
        }
        AllPings[reservedId].Active = e.Item.Checked;
    }

    private async void ToolStripMenuItemTest_Click(object sender, EventArgs e)
    {
        if (listViewPings.SelectedItems.Count == 0)
        {
            return;
        }
        var selected = listViewPings.SelectedItems[0];
        if (!int.TryParse(selected.Name, out var reservedId))
        {
            return;
        }
        var result = await AllPings[reservedId].PingServerAsync(null, null);
        if (result)
        {
            MessageBox.Show("Ping test successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Ping test unsuccessful\nCheck your settings", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }

    private void AddNewClick()
    {
        settingsIdsKey++;
        new FormEditPing(this, settingsIdsKey, true, null).ShowDialog();
    }

    private void ButtonAddNew_Click(object sender, EventArgs e) => AddNewClick();

    private void ToolStripMenuItemAdd_Click(object sender, EventArgs e) => AddNewClick();

    private static IDictionary<int, PingConfiguration> LoadPings()
    {
        try
        {
            return File.Exists(PingJsonFileLocation) ? LoadFromJsonFile(PingJsonFileLocation) : new Dictionary<int, PingConfiguration>();
        }
        catch
        {
            return new Dictionary<int, PingConfiguration>();
        }
    }
}
