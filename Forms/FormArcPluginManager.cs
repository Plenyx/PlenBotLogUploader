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
        private readonly HttpClientController httpController = new HttpClientController();
        private readonly List<ArcDpsComponent> componentsToUpdate = new List<ArcDpsComponent>();
        private int gw2Instances = 0;
        private bool updateManual = false;
        private bool updateRunning = false;
        private readonly ItemCheckEventHandler itemCheckHandler;
        private readonly EventHandler checkChangedHandler;
        #endregion

        public FormArcPluginManager(FormMain mainLink)
        {
            this.mainLink = mainLink;
            var installedComponents = ArcDpsComponent.DeserialiseAll(ApplicationSettings.LocalDir);
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            var availableComponents = ArcDpsComponentHelperClass.All;
            var arcIsInstalled = true;
            var arcInstalledComponent = installedComponents.Any(x => x.Type.Equals(ArcDpsComponentType.ArcDps) && x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode));
            if (arcInstalledComponent)
            {
                var arcdps = installedComponents.First(x => x.Type.Equals(ArcDpsComponentType.ArcDps) && x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode));
                if (!arcdps.IsInstalled())
                {
                    arcIsInstalled = false;
                    checkBoxModuleEnabled.Checked = false;
                    ApplicationSettings.Current.GW2Location = string.Empty;
                    ApplicationSettings.Current.Save();
                }
            }
            else
            {
                arcIsInstalled = false;
                checkBoxModuleEnabled.Checked = false;
                ApplicationSettings.Current.GW2Location = string.Empty;
                ApplicationSettings.Current.Save();
            }
            foreach (var component in availableComponents)
            {
                var installed = arcIsInstalled && installedComponents.Any(x => x.Type.Equals(component.Type) && x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode));
                if (installed)
                {
                    var installedComponent = installedComponents.First(x => x.Type.Equals(component.Type) && x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode));
                    if (!installedComponent.IsInstalled())
                    {
                        installed = false;
                        installedComponents.RemoveAll(x => x.Type.Equals(component.Type));
                    }
                }
                checkedListBoxArcDpsPlugins.Items.Add(component, installed);
            }
            itemCheckHandler = new ItemCheckEventHandler(CheckedListBoxArcDpsPlugins_ItemCheck);
            checkChangedHandler = new EventHandler(CheckBoxEnableNotifications_CheckedChanged);
            checkedListBoxArcDpsPlugins.ItemCheck += itemCheckHandler;
            checkBoxEnableNotifications.CheckedChanged += checkChangedHandler;
            ArcDpsComponent.SerialiseAll(ApplicationSettings.LocalDir);
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

        private List<Process> GetGW2Instances() => Process.GetProcessesByName("Gw2-64").ToList();

        private async Task UpdateArcAndPluginsAsync()
        {
            var processes = GetGW2Instances();
            if (processes.Count == 0)
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
            using var dialog = new OpenFileDialog() { Filter = "Guild Wars 2|Gw2-64.exe;Gw2.exe;Guild Wars 2.exe" };
            var result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK) && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                var location = Path.GetDirectoryName(dialog.FileName);
                ApplicationSettings.Current.GW2Location = location;
                ApplicationSettings.Current.ArcUpdate.Enabled = true;
                ApplicationSettings.Current.Save();
                if (ArcDpsComponent.All.Any(x => x.Type.Equals(ArcDpsComponentType.ArcDps) && x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode)))
                {
                    var component = ArcDpsComponent.All.First(x => x.Type.Equals(ArcDpsComponentType.ArcDps) && x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode));
                    if (!component.IsInstalled())
                    {
                        await component.DownloadComponent(httpController);
                        ArcDpsComponent.All.Where(x => x.RenderMode.Equals(ApplicationSettings.Current.ArcUpdate.RenderMode)).ToList().ForEach(async comp =>
                        {
                            if (!comp.IsInstalled())
                            {
                                await comp.DownloadComponent(httpController);
                            }
                        });
                    }
                }
                else
                {
                    var relLoc = ApplicationSettings.Current.ArcUpdate.UseAL ? @"\addons\arcdps\gw2addon_arcdps.dll" : @"\d3d11.dll";
                    var component = new ArcDpsComponent() { Type = ArcDpsComponentType.ArcDps, RenderMode = ApplicationSettings.Current.ArcUpdate.RenderMode, RelativeLocation = relLoc };
                    if (!component.IsInstalled())
                    {
                        await component.DownloadComponent(httpController);
                    }
                    ArcDpsComponent.All.Add(component);
                    ArcDpsComponent.SerialiseAll(ApplicationSettings.LocalDir);
                }
                labelStatusText.Text = "";
                checkedListBoxArcDpsPlugins.Enabled = true;
                buttonCheckNow.Enabled = true;
                await StartTimerAsync();
            }
            else
            {
                await StopTimerAsync();
            }
        }

        private async void CheckedListBoxArcDpsPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBoxArcDpsPlugins.ClearSelected();
            var item = (ArcDpsComponentHelperClass)checkedListBoxArcDpsPlugins.Items[e.Index];
            if (e.NewValue.Equals(CheckState.Unchecked))
            {
                var processes = GetGW2Instances();
                if (processes.Count == 0)
                {
                    var component = ArcDpsComponent.All.FirstOrDefault(x => x.Type.Equals(item.Type));
                    File.Delete($"{ApplicationSettings.Current.GW2Location}{component.RelativeLocation}");
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
                var relLoc = ApplicationSettings.Current.ArcUpdate.UseAL ? $@"\addons\arcdps\{item.DefaultFileName}" : $@"\{item.DefaultFileName}";
                var component = new ArcDpsComponent() { Type = item.Type, RenderMode = ApplicationSettings.Current.ArcUpdate.RenderMode, RelativeLocation = relLoc };
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
            ApplicationSettings.Current.ArcUpdate.Enabled = false;
            ApplicationSettings.Current.Save();
            groupBoxModuleControls.Enabled = toggle;
            checkedListBoxArcDpsPlugins.Enabled = toggle;
            if (Visible && toggle && (string.IsNullOrWhiteSpace(ApplicationSettings.Current.GW2Location)))
            {
                labelStatusText.Text = "You need to select the GW2 Location.";
                checkedListBoxArcDpsPlugins.Enabled = false;
                buttonCheckNow.Enabled = false;
                // ButtonChangeGW2Location_Click(this, new EventArgs());
            } else
            {
                ApplicationSettings.Current.ArcUpdate.Enabled = toggle;
                ApplicationSettings.Current.Save();
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
            if (!(item is null) && item.GetType().Equals(typeof(ArcDpsComponentHelperClass)))
            {
                (new FormArcPluginInfo(item as ArcDpsComponentHelperClass)).ShowDialog();
            }
        }

        private void CheckedListBoxArcDpsPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonShowPluginInfo.Enabled = checkedListBoxArcDpsPlugins.SelectedIndex > -1;
        }

        private void checkBoxUseAL_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Current.ArcUpdate.UseAL = checkBoxUseAL.Checked;
            ApplicationSettings.Current.Save();
        }
    }
}
