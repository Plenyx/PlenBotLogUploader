using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DPSReport;
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
        private static string PingTxtFileLocation = $@"{ApplicationSettings.LocalDir}\remote_pings.txt";
        private static string MigratedPingTxtFileLocation = $@"{ApplicationSettings.LocalDir}\remote_pings-migrated.txt";
        private static string PingJsonFileLocation = $@"{ApplicationSettings.LocalDir}\remote_pings.json";
        public IDictionary<int, PingConfiguration> AllPings { get; set; }

        // fields
        private readonly FormMain mainLink;
        private int settingsIdsKey;
        #endregion

        public FormPings(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            AllPings = LoadPings();

            settingsIdsKey = AllPings.Count;

            foreach (var ping in AllPings)
            {
                listViewPings.Items.Add(new ListViewItem
                {
                    Name = ping.Key.ToString(),
                    Text = ping.Value.Name,
                    Checked = ping.Value.Active
                });
            }
        }

        private void LoadFromTxtFile()
        {
            AllPings = new Dictionary<int, PingConfiguration>();
            try
            {
                using var reader = new StreamReader(PingTxtFileLocation);
                var line = reader.ReadLine();
                while (!((line = reader.ReadLine()) is null))
                {
                    var values = line.Split(new string[] { "<;>" }, StringSplitOptions.None);
                    int.TryParse(values[0], out int active);
                    int.TryParse(values[3], out int method);
                    int.TryParse(values[4], out int authActive);
                    int.TryParse(values[5], out int useAsAuth);
                    if (method > 3 || method < 0)
                    {
                        method = 0;
                    }

                    var auth = new PingAuthentication()
                    {
                        Active = authActive == 1,
                        UseAsAuth = useAsAuth == 1,
                        AuthName = values[6],
                        AuthToken = values[7]
                    };
                    AddPing(new PingConfiguration()
                    {
                        Active = active == 1,
                        Name = values[1],
                        URL = values[2],
                        Method = (PingMethod)method,
                        Authentication = auth
                    });
                }
            }
            catch
            {
                AllPings = new Dictionary<int, PingConfiguration>();
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

        public void AddPing(PingConfiguration config)
        {
            settingsIdsKey++;
            AllPings.Add(settingsIdsKey, config);
        }

        public async Task ExecuteAllPingsAsync(DPSReportJSON reportJSON)
        {
            foreach (var key in AllPings.Keys)
            {
                if (AllPings[key].Active)
                {
                    await AllPings[key].PingServerAsync(mainLink, reportJSON);
                }
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            settingsIdsKey++;
            new FormEditPing(this, settingsIdsKey, true, null).Show();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                new FormEditPing(this, reservedId, false, AllPings[reservedId]).Show();
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
                listViewPings.Items.RemoveByKey(reservedId.ToString());
                AllPings.Remove(reservedId);
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
            int.TryParse(e.Item.Name, out int reservedId);
            AllPings[reservedId].Active = e.Item.Checked;
        }

        private async void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            if (listViewPings.SelectedItems.Count > 0)
            {
                var selected = listViewPings.SelectedItems[0];
                int.TryParse(selected.Name, out int reservedId);
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

        private void ButtonAddNew_Click(object sender, EventArgs e)
        {
            settingsIdsKey++;
            new FormEditPing(this, settingsIdsKey, true, null).Show();
        }

        private IDictionary<int, PingConfiguration> LoadPings()
        {
            try
            {
                if (File.Exists(PingTxtFileLocation))
                {
                    LoadFromTxtFile();
                    var pings = AllPings;
                    SaveToJson(pings.Values);
                    File.Move(PingTxtFileLocation, MigratedPingTxtFileLocation);
                    return pings;
                }
                else if (File.Exists(PingJsonFileLocation))
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
