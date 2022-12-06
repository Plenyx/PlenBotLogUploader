using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.RemotePing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormPings : Form
    {
        #region definitions
        // properties
        private static readonly string PingJsonFileLocation = $@"{ApplicationSettings.LocalDir}\remote_pings.json";
        internal IDictionary<int, PingConfiguration> AllPings { get; set; }

        // fields
        private readonly FormMain mainLink;
        private int settingsIdsKey;
        #endregion

        internal FormPings(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            AllPings = LoadPings();

            settingsIdsKey = AllPings.Count;

            foreach (var ping in AllPings.ToArray().AsSpan())
            {
                listViewPings.Items.Add(new ListViewItem
                {
                    Name = ping.Key.ToString(),
                    Text = ping.Value.Name,
                    Checked = ping.Value.Active
                });
            }
        }

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

        internal void AddPing(PingConfiguration config)
        {
            settingsIdsKey++;
            AllPings.Add(settingsIdsKey, config);
        }

        internal async Task ExecuteAllPingsAsync(DpsReportJson reportJSON)
        {
            foreach (var key in AllPings.Keys)
            {
                if (AllPings[key].Active)
                {
                    await AllPings[key].PingServerAsync(mainLink, reportJSON);
                }
            }
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                if (int.TryParse(selected.Name, out int reservedId))
                {
                    new FormEditPing(this, reservedId, false, AllPings[reservedId]).ShowDialog();
                }
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                if (int.TryParse(selected.Name, out int reservedId))
                {
                    listViewPings.Items.RemoveByKey(reservedId.ToString());
                    AllPings.Remove(reservedId);
                }
            }
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
            if (int.TryParse(e.Item.Name, out int reservedId))
            {
                AllPings[reservedId].Active = e.Item.Checked;
            }
        }

        private async void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                if (int.TryParse(selected.Name, out int reservedId))
                {
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
                if (File.Exists(PingJsonFileLocation))
                {
                    return LoadFromJsonFile(PingJsonFileLocation);
                }
                return new Dictionary<int, PingConfiguration>();
            }
            catch
            {
                return new Dictionary<int, PingConfiguration>();
            }
        }
    }
}
