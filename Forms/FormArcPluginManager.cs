using Hardstuck.Http;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.ArcDps;
using PlenBotLogUploader.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private readonly HttpClientController httpController = new();
        private readonly List<ArcDpsComponent> componentsToUpdate = [];
        private int gw2Instances = 0;
        private bool updateManual = false;
        private bool updateRunning = false;
        private readonly ItemCheckEventHandler itemCheckHandler;
        private readonly EventHandler checkChangedHandler;
        #endregion

        internal FormArcPluginManager(FormMain mainLink)
        {
            this.mainLink = mainLink;
            var installedComponents = ArcDpsComponent.DeserialiseAll(ApplicationSettings.LocalDir);
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            var availableComponents = ArcDpsComponentHelperClass.All;
            var arcIsInstalled = true;
            var arcdps = installedComponents.Find(x => x.Type.Equals(ArcDpsComponentType.ArcDps));
            if (arcdps is not null)
            {
                if (!arcdps.IsInstalled())
                {
                    arcIsInstalled = false;
                    checkBoxModuleEnabled.Checked = false;
                    ApplicationSettings.Current.Gw2Location = "";
                    ApplicationSettings.Current.Save();
                }
            }
            else
            {
                arcIsInstalled = false;
                checkBoxModuleEnabled.Checked = false;
                ApplicationSettings.Current.Gw2Location = "";
                ApplicationSettings.Current.Save();
            }
            foreach (var component in availableComponents.AsSpan())
            {
                var installedComponent = installedComponents.Find(x => x.Type.Equals(component.Type));
                var installed = arcIsInstalled && installedComponent is not null;
                if (installed)
                {
                    if (!installedComponent.IsInstalled())
                    {
                        installed = false;
                        installedComponents.RemoveAll(x => x.Type.Equals(component.Type));
                    }
                }
                checkedListBoxArcDpsPlugins.Items.Add(component, installed);
            }
            switch (ApplicationSettings.Current.ArcUpdate.ChainLoad)
            {
                case ApplicationSettingsArcUpdateChainLoad.AddonLoader:
                    radioButtonChainLoadAL.Checked = true;
                    break;
                case ApplicationSettingsArcUpdateChainLoad.Nexus:
                    radioButtonChainLoadNexus.Checked = true;
                    break;
                default:
                    break;
            }
            itemCheckHandler = new ItemCheckEventHandler(CheckedListBoxArcDpsPlugins_ItemCheck);
            checkChangedHandler = new EventHandler(CheckBoxEnableNotifications_CheckedChanged);
            checkedListBoxArcDpsPlugins.ItemCheck += itemCheckHandler;
            checkBoxEnableNotifications.CheckedChanged += checkChangedHandler;
            radioButtonChainLoadNone.CheckedChanged += RadioButtonChainLoadNone_CheckedChanged;
            radioButtonChainLoadAL.CheckedChanged += RadioButtonChainLoadAL_CheckedChanged;
            radioButtonChainLoadNexus.CheckedChanged += RadioButtonChainLoadNexus_CheckedChanged;
            ArcDpsComponent.SerialiseAll(ApplicationSettings.LocalDir);
        }

        private void SetStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetStatus(status));
            }
            labelStatusText.Text = status;
        }

        private void SetCheckNowButton(bool toggle)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => buttonCheckNow.Enabled = toggle));
            }
            else
            {
                buttonCheckNow.Enabled = toggle;
            }
        }

        internal async Task StartTimerAsync(bool checkNow = false, bool applicationStart = false)
        {
            timerCheckUpdates.Stop();
            if (checkNow)
            {
                await CheckUpdatesAsync(applicationStart);
            }
            timerCheckUpdates.Start();
        }

        internal async Task StopTimerAsync(bool checkNow = false)
        {
            timerCheckUpdates.Stop();
            if (checkNow)
            {
                await CheckUpdatesAsync();
            }
        }

        private async Task CheckUpdatesAsync(bool applicationStart = false)
        {
            if (updateRunning)
            {
                return;
            }
            if (applicationStart && (DateTime.Now.Subtract(ApplicationSettings.Current.ArcUpdate.LastUpdateCheck).TotalSeconds < 300))
            {
                return;
            }
            SetCheckNowButton(false);
            componentsToUpdate.Clear();
            SetStatus($"{DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture)}: Update check started.");
            var updateNeeded = false;
            foreach (var component in ArcDpsComponent.All)
            {
                var version = await component.GetVersionStringAsync(httpController);
                if (!component.IsCurrentVersion(version))
                {
                    componentsToUpdate.Add(component);
                    updateNeeded = true;
                }
            }
            if (updateNeeded)
            {
                await UpdateArcAndPluginsAsync();
            }
            else
            {
                SetStatus($"{DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture)}: Update check ended, no updates found.");
                SetCheckNowButton(true);
            }
            ApplicationSettings.Current.ArcUpdate.LastUpdateCheck = DateTime.Now;
            ApplicationSettings.Current.Save();
        }

        private void TimerCheckUpdates_Tick(object sender, EventArgs e) => _ = CheckUpdatesAsync();

        private async Task UpdateArcAndPluginsAsync()
        {
            var processes = Process.GetProcessesByName("Gw2-64");
            if (processes.Length == 0)
            {
                SetStatus($"{DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture)}: Updates for installed plugins found, updating...");
                foreach (var component in componentsToUpdate)
                {
                    await component.DownloadComponent(httpController);
                }
                if (checkBoxEnableNotifications.Checked && !updateManual)
                {
                    mainLink.ShowBalloon("arcdps plugin manager", "An update for an installed plugin has been found and has been updated.", 7500);
                }
                SetStatus($"{DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture)}: Updates successfully installed.");
                SetCheckNowButton(true);
                updateRunning = false;
            }
            else
            {
                SetStatus($"{DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture)}: Updates for installed plugins found, waiting for GW2 to close...");
                if (checkBoxEnableNotifications.Checked && !updateManual)
                {
                    mainLink.ShowBalloon("arcdps plugin manager", "An updates for installed plugins has been found.\nPlease close GW2 to enable the update.", 7500);
                }
                Interlocked.Exchange(ref gw2Instances, processes.Length);
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
            using var dialog = new OpenFileDialog() { Filter = "Guild Wars 2|Gw2-64.exe;Gw2.exe;Guild Wars 2.exe" };
            var result = dialog.ShowDialog();
            if (!result.Equals(DialogResult.OK) || string.IsNullOrWhiteSpace(dialog.FileName))
            {
                await StopTimerAsync();
                return;
            }
            var location = Path.GetDirectoryName(dialog.FileName);
            if (File.Exists(location + @"\addonLoader.dll"))
            {
                ApplicationSettings.Current.ArcUpdate.ChainLoad = ApplicationSettingsArcUpdateChainLoad.AddonLoader;
                radioButtonChainLoadAL.Checked = true;
                labelStatusText.Text = "Addon Loader found. Using Addon Loader";
            }
            if (File.Exists(location + @"\d3d11.dll"))
            {
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(location + @"\d3d11.dll");
                if (fileVersionInfo.ProductName == "Nexus")
                {
                    ApplicationSettings.Current.ArcUpdate.ChainLoad = ApplicationSettingsArcUpdateChainLoad.Nexus;
                    radioButtonChainLoadNexus.Checked = true;
                    labelStatusText.Text = "Nexus found. Using Nexus addon host";
                }
            }
            ApplicationSettings.Current.Gw2Location = location;
            ApplicationSettings.Current.Save();
            var component = ArcDpsComponent.All.Find(x => x.Type.Equals(ArcDpsComponentType.ArcDps));
            if (component is not null)
            {
                if (!component.IsInstalled())
                {
                    await component.DownloadComponent(httpController);

                    foreach (var comp in ArcDpsComponent.All)
                    {
                        if (!comp.IsInstalled())
                        {
                            await comp.DownloadComponent(httpController);
                        }
                    }
                }
            }
            else
            {
                component = new ArcDpsComponent() { Type = ArcDpsComponentType.ArcDps, RelativeLocation = ApplicationSettings.Current.ArcUpdate.ArcPathChainLoaded };
                if (!component.IsInstalled())
                {
                    await component.DownloadComponent(httpController);
                }
                ArcDpsComponent.All.Add(component);
                ArcDpsComponent.SerialiseAll(ApplicationSettings.LocalDir);
            }
            await StartTimerAsync();
        }

        private async void CheckedListBoxArcDpsPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBoxArcDpsPlugins.ClearSelected();
            var item = (ArcDpsComponentHelperClass)checkedListBoxArcDpsPlugins.Items[e.Index];
            if (e.NewValue.Equals(CheckState.Unchecked))
            {
                var processes = Process.GetProcessesByName("Gw2-64");
                if (processes.Length == 0)
                {
                    var component = ArcDpsComponent.All.Find(x => x.Type.Equals(item.Type));
                    File.Delete(ApplicationSettings.Current.Gw2Location + component.RelativeLocation);
                    ArcDpsComponent.All.RemoveAll(x => x.Type.Equals(component.Type));
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                    MessageBox.Show("You are unable to uninstall an arcdps plugin while GW2 is still running.", "GW2 is still running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.NewValue.Equals(CheckState.Checked))
            {
                var component = new ArcDpsComponent() { Type = item.Type, RelativeLocation = ApplicationSettings.Current.ArcUpdate.ArcPathChainLoaded };
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
            if (Visible && toggle && string.IsNullOrWhiteSpace(ApplicationSettings.Current.Gw2Location))
            {
                ButtonChangeGW2Location_Click(this, EventArgs.Empty);
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
            ArcDpsComponent.SerialiseAll(ApplicationSettings.LocalDir);
        }

        private void FormArcPluginManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            httpController?.Dispose();
        }

        private void ButtonShowPluginInfo_Click(object sender, EventArgs e)
        {
            var item = checkedListBoxArcDpsPlugins.SelectedItem;
            if (item is ArcDpsComponentHelperClass itemHelper)
            {
                new FormArcPluginInfo(itemHelper).ShowDialog();
            }
        }

        private void CheckedListBoxArcDpsPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonShowPluginInfo.Enabled = checkedListBoxArcDpsPlugins.SelectedIndex > -1;
        }

        private async Task ChangeArcDpsPathBasedOnChainLoad()
        {
            var component = ArcDpsComponent.All.Find(x => x.Type.Equals(ArcDpsComponentType.ArcDps));
            if (component is not null)
            {
                component.RelativeLocation = ApplicationSettings.Current.ArcUpdate.ArcPathChainLoaded;
                await component.DownloadComponent(httpController);
            }
        }

        private void RadioButtonChainLoadNone_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonChainLoadNone.Checked)
            {
                return;
            }
            ApplicationSettings.Current.ArcUpdate.ChainLoad = ApplicationSettingsArcUpdateChainLoad.None;
            ApplicationSettings.Current.Save();
            _ = ChangeArcDpsPathBasedOnChainLoad();
        }

        private void RadioButtonChainLoadAL_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonChainLoadAL.Checked)
            {
                return;
            }
            ApplicationSettings.Current.ArcUpdate.ChainLoad = ApplicationSettingsArcUpdateChainLoad.AddonLoader;
            ApplicationSettings.Current.Save();
            _ = ChangeArcDpsPathBasedOnChainLoad();
        }

        private void RadioButtonChainLoadNexus_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonChainLoadNexus.Checked)
            {
                return;
            }
            ApplicationSettings.Current.ArcUpdate.ChainLoad = ApplicationSettingsArcUpdateChainLoad.Nexus;
            ApplicationSettings.Current.Save();
            _ = ChangeArcDpsPathBasedOnChainLoad();
        }
    }
}
