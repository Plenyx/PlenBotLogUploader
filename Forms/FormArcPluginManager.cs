using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.ArcDps;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormArcPluginManager : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        private readonly HttpClientController httpController;
        private readonly List<ArcDpsComponent> componentsToUpdate = new List<ArcDpsComponent>();
        private int gw2Instances = 0;
        private bool updateManual = false;
        private bool updateRunning = false;
        #endregion

        public FormArcPluginManager(FormMain mainLink, string gw2Location)
        {
            this.mainLink = mainLink;
            httpController = new HttpClientController();
            var installedComponents = ArcDpsComponent.DeserialiseAll(mainLink.LocalDir);
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            var availableComponents = new List<ArcDpsComponentHelperClass>()
            {
                new ArcDpsComponentHelperClass() { Name = "Mechanics", Author = "MarsEdge, modified by knoxfighter", Type = ArcDpsComponentType.Mechanics },
                new ArcDpsComponentHelperClass() { Name = "Boon table", Author = "MarsEdge, modified by knoxfighter", Type = ArcDpsComponentType.BoonTable },
                new ArcDpsComponentHelperClass() { Name = "Killproof.me", Author = "knoxfighter", Type = ArcDpsComponentType.KPme },
                new ArcDpsComponentHelperClass() { Name = "Heal stats", Author = "Krappa322", Type = ArcDpsComponentType.HealStats },
                new ArcDpsComponentHelperClass() { Name = "Scrolling combat text", Author = "Artenuvielle", Type = ArcDpsComponentType.SCT }
            };
            var arcIsInstalled = true;
            var arcInstalledComponent = installedComponents.Where(x => x.Type.Equals(ArcDpsComponentType.ArcDps)).Any();
            if (arcInstalledComponent)
            {
                var arcdps = installedComponents.Where(x => x.Type.Equals(ArcDpsComponentType.ArcDps)).First();
                if (!arcdps.IsInstalled())
                {
                    arcIsInstalled = false;
                    checkBoxModuleEnabled.Checked = false;
                    ApplicationSettings.Current.GW2Location = "";
                    ApplicationSettings.Current.Save();
                }
            }
            else
            {
                arcIsInstalled = false;
                checkBoxModuleEnabled.Checked = false;
                ApplicationSettings.Current.GW2Location = "";
                ApplicationSettings.Current.Save();
            }
            foreach (var component in availableComponents)
            {
                var installed = arcIsInstalled && installedComponents.Where(x => x.Type.Equals(component.Type)).Any();
                if (installed)
                {
                    var installedComponent = installedComponents.Where(x => x.Type.Equals(component.Type)).First();
                    if (!installedComponent.IsInstalled())
                    {
                        installed = false;
                        installedComponents.RemoveAll(x => x.Type.Equals(component.Type));
                    }
                }
                checkedListBoxArcDpsPlugins.Items.Add(component, installed);
            }
            checkedListBoxArcDpsPlugins.ItemCheck += new ItemCheckEventHandler(CheckedListBoxArcDpsPlugins_ItemCheck);
            checkBoxEnableNotifications.CheckedChanged += new EventHandler(CheckBoxEnableNotifications_CheckedChanged);
            ArcDpsComponent.SerialiseAll(mainLink.LocalDir);
        }

        private void SetStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate () { SetStatus(status); });
            }
            labelStatusText.Text = status;
        }

        private void SetCheckNowButton(bool toggle)
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate () { buttonCheckNow.Enabled = toggle; });
            }
            else
            {
                buttonCheckNow.Enabled = toggle;
            }
        }

        public async Task StartTimerAsync(bool checkNow = false)
        {
            timerCheckUpdates.Stop();
            if (checkNow)
            {
                await CheckUpdatesAsync();
            }
            timerCheckUpdates.Start();
        }

        public async Task StopTimerAsync(bool checkNow = false)
        {
            timerCheckUpdates.Stop();
            if (checkNow)
            {
                await CheckUpdatesAsync();
            }
        }

        private async Task CheckUpdatesAsync()
        {
            if (updateRunning)
            {
                return;
            }
            SetCheckNowButton(false);
            componentsToUpdate.Clear();
            SetStatus($"{DateTime.Now}: Update check started.");
            var updateNeded = false;
            foreach (var component in ArcDpsComponent.All)
            {
                var version = await httpController.DownloadFileToStringAsync(component.VersionLink);
                if (!component.IsCurrentVersion(version))
                {
                    componentsToUpdate.Add(component);
                    updateNeded = true;
                }
            }
            if (updateNeded)
            {
                await UpdateArcAndPluginsAsync();
            }
            else
            {
                SetStatus($"{DateTime.Now}: Update check ended, no updates found.");
                SetCheckNowButton(true);
            }
        }

        private void TimerCheckUpdates_Tick(object sender, EventArgs e) => _ = CheckUpdatesAsync();

        private List<Process> GetGW2Instances() => Process.GetProcessesByName("Gw2-64").ToList();

        private async Task UpdateArcAndPluginsAsync()
        {
            var processes = GetGW2Instances();
            if (processes.Count == 0)
            {
                SetStatus($"{DateTime.Now}: Updates for installed plugins found, updating...");
                foreach (var component in componentsToUpdate)
                {
                    await component.DownloadComponent(httpController);
                }
                if (checkBoxEnableNotifications.Checked && !updateManual)
                {
                    mainLink.ShowBalloon("arcdps plugin manager", "An update for an installed plugin has been found.\nPlease close GW2 to enable the update.", 7500);
                }
                SetStatus($"{DateTime.Now}: Updates successfully installed.");
                SetCheckNowButton(true);
                updateRunning = false;
            }
            else
            {
                SetStatus($"{DateTime.Now}: Updates for installed plugins found, waiting for GW2 to close...");
                if (checkBoxEnableNotifications.Checked && !updateManual)
                {
                    mainLink.ShowBalloon("arcdps plugin manager", "An updates for installed plugins has been found.\nPlease close GW2 to enable the update.", 7500);
                }
                Interlocked.Exchange(ref gw2Instances, processes.Count);
                foreach (var process in processes)
                {
                    process.EnableRaisingEvents = true;
                    process.Exited += ProcessExited;
                }
            }
        }

        private async void ProcessExited(object sender, EventArgs e)
        {
            Interlocked.Decrement(ref gw2Instances);
            if (gw2Instances == 0)
            {
                await UpdateArcAndPluginsAsync();
            }
        }

        private async void ButtonChangeGW2Location_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Guild Wars 2|Gw2-64.exe;Gw2.exe;Guild Wars 2.exe";
                var result = dialog.ShowDialog();
                if (result.Equals(DialogResult.OK) && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    var location = Path.GetDirectoryName(dialog.FileName);
                    ApplicationSettings.Current.GW2Location = location;
                    ApplicationSettings.Current.Save();
                    if (ArcDpsComponent.All.Where(x => x.Type.Equals(ArcDpsComponentType.ArcDps)).Any())
                    {
                        var component = ArcDpsComponent.All.Where(x => x.Type.Equals(ArcDpsComponentType.ArcDps)).First();
                        if (!component.IsInstalled())
                        {
                            await component.DownloadComponent(httpController);
                            ArcDpsComponent.All.ForEach(async comp => {
                                if (!comp.IsInstalled())
                                {
                                    await comp.DownloadComponent(httpController);
                                }
                            });
                        }
                    }
                    else
                    {
                        var component = new ArcDpsComponent() { Type = ArcDpsComponentType.ArcDps, RelativeLocation = @"\bin64\d3d9.dll" };
                        if (!component.IsInstalled())
                        {
                            await component.DownloadComponent(httpController);
                        }
                        ArcDpsComponent.All.Add(component);
                        ArcDpsComponent.SerialiseAll(mainLink.LocalDir);
                    }
                    await StartTimerAsync();
                }
                else
                {
                    await StopTimerAsync();
                }
            }
        }

        private async void CheckedListBoxArcDpsPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = (ArcDpsComponentHelperClass)checkedListBoxArcDpsPlugins.Items[e.Index];
            if (e.NewValue == CheckState.Unchecked)
            {
                var processes = GetGW2Instances();
                if (processes.Count == 0)
                {
                    var component = ArcDpsComponent.All.Where(x => x.Type.Equals(item.Type)).FirstOrDefault();
                    File.Delete($"{ApplicationSettings.Current.GW2Location}{component.RelativeLocation}");
                    ArcDpsComponent.All.RemoveAll(x => x.Type.Equals(component.Type));
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                    MessageBox.Show("You are unable to uninstall an arcdps plugin while GW2 is still running.", "GW2 is still running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.NewValue == CheckState.Checked)
            {
                var component = new ArcDpsComponent() { Type = item.Type, RelativeLocation = $@"\bin64\{item.DefaultFileName}" };
                ArcDpsComponent.All.Add(component);
                await component.DownloadComponent(httpController);
            }
        }

        private async void ButtonCheckNow_Click(object sender, EventArgs e)
        {
            updateManual = true;
            await StartTimerAsync(true);
        }

        private void CheckBoxModuleEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var toggle = checkBoxModuleEnabled.Checked;
            ApplicationSettings.Current.ArcUpdate.Enabled = toggle;
            ApplicationSettings.Current.Save();
            groupBoxModuleControls.Enabled = toggle;
            checkedListBoxArcDpsPlugins.Enabled = toggle;
            if (Visible && toggle && (ApplicationSettings.Current.GW2Location == ""))
            {
                ButtonChangeGW2Location_Click(this, new EventArgs());
            }
        }

        private void CheckBoxEnableNotifications_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.ArcUpdate.Notifications = checkBoxEnableNotifications.Checked;
            ApplicationSettings.Current.Save();
        }

        private void FormArcPluginManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            ArcDpsComponent.SerialiseAll(mainLink.LocalDir);
        }

        private void FormArcPluginManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            httpController?.Dispose();
        }
    }
}
