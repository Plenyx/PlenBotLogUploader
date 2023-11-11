using PlenBotLogUploader.RemotePing;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormEditPing : Form
    {
        #region definitions
        // fields
        private readonly FormPings pingLink;
        private readonly PingConfiguration config;
        private readonly int reservedId;
        private readonly bool addNew;
        #endregion

        internal FormEditPing(FormPings pingLink, int reservedId, bool addNew, PingConfiguration config)
        {
            this.pingLink = pingLink;
            this.config = config;
            this.reservedId = reservedId;
            this.addNew = addNew;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            Text = addNew ? "Add a new ping configuration" : "Edit an existing ping configuration";
            textBoxName.Text = config?.Name ?? "";
            textBoxURL.Text = config?.Url ?? "";
            textBoxAuthName.Text = config?.Authentication.AuthName ?? "Bearer";
            textBoxAuthToken.Text = config?.Authentication.AuthToken ?? "";
            switch (config?.Method ?? PingMethod.Post)
            {
                case PingMethod.Get:
                    radioButtonMethodGet.Checked = true;
                    break;
                case PingMethod.Post:
                    radioButtonMethodPost.Checked = true;
                    break;
                case PingMethod.Delete:
                    radioButtonMethodDelete.Checked = true;
                    break;
                case PingMethod.Put:
                    radioButtonMethodPut.Checked = true;
                    break;
                default:
                    radioButtonMethodPost.Checked = true;
                    break;
            }
            if (config?.Authentication.UseAsAuth ?? false)
            {
                radioButtonUseAuthField.Checked = true;
            }
            else if (!config?.Authentication.UseAsAuth ?? false)
            {
                radioButtonUseNormalField.Checked = true;
            }
        }

        private void FormPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxName.Text == "")
            {
                return;
            }
            if (addNew)
            {
                PingMethod chosenMethod = PingMethod.Post;
                if (radioButtonMethodPut.Checked)
                {
                    chosenMethod = PingMethod.Put;
                }
                else if (radioButtonMethodGet.Checked)
                {
                    chosenMethod = PingMethod.Get;
                }
                else if (radioButtonMethodDelete.Checked)
                {
                    chosenMethod = PingMethod.Delete;
                }
                var auth = new PingAuthentication()
                {
                    Active = textBoxAuthToken.Text != "",
                    UseAsAuth = radioButtonUseAuthField.Checked,
                    AuthName = textBoxAuthName.Text,
                    AuthToken = textBoxAuthToken.Text
                };
                pingLink.AllPings[reservedId] = new PingConfiguration() { Active = false, Name = textBoxName.Text, Url = textBoxURL.Text, Method = chosenMethod, Authentication = auth };
                pingLink.listViewPings.Items.Add(new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = false });
                return;
            }
            if (pingLink.AllPings.ContainsKey(reservedId))
            {
                pingLink.AllPings[reservedId].Active = config.Active;
                pingLink.AllPings[reservedId].Name = textBoxName.Text;
                pingLink.AllPings[reservedId].Url = textBoxURL.Text;
                if (radioButtonMethodPut.Checked)
                {
                    pingLink.AllPings[reservedId].Method = PingMethod.Put;
                }
                else if (radioButtonMethodGet.Checked)
                {
                    pingLink.AllPings[reservedId].Method = PingMethod.Get;
                }
                else if (radioButtonMethodDelete.Checked)
                {
                    pingLink.AllPings[reservedId].Method = PingMethod.Delete;
                }
                else
                {
                    pingLink.AllPings[reservedId].Method = PingMethod.Post;
                }
                pingLink.AllPings[reservedId].Authentication.Active = textBoxAuthToken.Text.Trim() != "";
                pingLink.AllPings[reservedId].Authentication.UseAsAuth = radioButtonUseAuthField.Checked;
                pingLink.AllPings[reservedId].Authentication.AuthName = textBoxAuthName.Text;
                pingLink.AllPings[reservedId].Authentication.AuthToken = textBoxAuthToken.Text;
                pingLink.listViewPings.Items[pingLink.listViewPings.Items.IndexOfKey(reservedId.ToString())] = new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = config.Active };
            }
        }

        private async void ButtonTestPing_Click(object sender, EventArgs e)
        {
            var chosenMethod = PingMethod.Post;
            if (radioButtonMethodPut.Checked)
            {
                chosenMethod = PingMethod.Put;
            }
            else if (radioButtonMethodGet.Checked)
            {
                chosenMethod = PingMethod.Get;
            }
            else if (radioButtonMethodDelete.Checked)
            {
                chosenMethod = PingMethod.Delete;
            }
            var auth = new PingAuthentication()
            {
                Active = textBoxAuthToken.Text.Trim() != "",
                UseAsAuth = radioButtonUseAuthField.Checked,
                AuthName = textBoxAuthName.Text,
                AuthToken = textBoxAuthToken.Text
            };
            var tempPing = new PingConfiguration() { Active = false, Name = textBoxName.Text, Url = textBoxURL.Text, Method = chosenMethod, Authentication = auth };
            var result = await tempPing.PingServerAsync(null, null);
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
