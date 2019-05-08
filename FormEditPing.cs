using System;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using PlenBotLogUploader.PlenyxAPI;
using PlenBotLogUploader.RemotePing;

namespace PlenBotLogUploader
{
    public partial class FormEditPing : Form
    {
        #region definitions
        // fields
        private FormMain mainLink;
        private FormPings pingLink;
        private PingConfiguration config;
        private int reservedId;
        private bool addNew;
        #endregion

        public FormEditPing(FormMain mainLink, FormPings pingLink, int reservedId, bool addNew, PingConfiguration config)
        {
            this.mainLink = mainLink;
            this.pingLink = pingLink;
            this.config = config;
            this.reservedId = reservedId;
            this.addNew = addNew;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            if (addNew)
            {
                Text = "Add a new ping configuration";
            }
            else
            {
                Text = "Edit an existing ping configuration";
            }
            textBoxName.Text = config?.Name ?? "";
            textBoxURL.Text = config?.URL ?? "";
            textBoxSign.Text = config?.Authentication.AuthToken ?? "";
            PingMethod method = config?.Method ?? PingMethod.Post;
            switch (method)
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
                default:
                    radioButtonMethodPost.Checked = true;
                    break;
            }
            if (config?.Authentication.UseAsAuth ?? false)
            {
                radioButtonUseAuthField.Checked = true;
            }
        }

        private void FormPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxName.Text != "")
            {
                if (addNew)
                {
                    var auth = new PingAuthentication()
                    {
                        Active = (textBoxSign.Text == "") ? true : false,
                        UseAsAuth = radioButtonUseAuthField.Checked,
                        AuthName = "Sign",
                        AuthToken = textBoxSign.Text
                    };
                    PingMethod chosenMethod;
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
                    else
                    {
                        chosenMethod = PingMethod.Post;
                    }
                    pingLink.AllPings[reservedId] = new PingConfiguration() { Active = false, Name = textBoxName.Text, URL = textBoxURL.Text, Method = chosenMethod, Authentication = auth };
                    pingLink.listViewDiscordWebhooks.Items.Add(new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = false });
                }
                else
                {
                    if (pingLink.AllPings.ContainsKey(reservedId))
                    {
                        pingLink.AllPings[reservedId].Active = config.Active;
                        pingLink.AllPings[reservedId].Name = textBoxName.Text;
                        pingLink.AllPings[reservedId].URL = textBoxURL.Text;
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
                        pingLink.AllPings[reservedId].Authentication.Active = (textBoxSign.Text == "") ? false : true;
                        pingLink.AllPings[reservedId].Authentication.UseAsAuth = radioButtonUseAuthField.Checked;
                        pingLink.AllPings[reservedId].Authentication.AuthName = config.Authentication.AuthName;
                        pingLink.AllPings[reservedId].Authentication.AuthToken = textBoxSign.Text;
                        pingLink.listViewDiscordWebhooks.Items[pingLink.listViewDiscordWebhooks.Items.IndexOfKey(reservedId.ToString())] = new ListViewItem() { Name = reservedId.ToString(), Text = textBoxName.Text, Checked = config.Active };
                    }
                }
            }
        }

        private void buttonPlenyxWay_Click(object sender, EventArgs e)
        {
            radioButtonMethodPost.Checked = true;
            textBoxURL.Text = "https://plenbot.net/uploader/ping/";
            radioButtonUseNormalField.Checked = true;
            textBoxSign.Text = "";
        }

        public async void PingTestAsync()
        {
            try
            {
                string response = await mainLink.DownloadFileToStringAsync($"{textBoxURL.Text}pingtest/?sign={textBoxSign.Text}");
                try
                {
                    PlenyxAPIPingTest pingtest = new JavaScriptSerializer().Deserialize<PlenyxAPIPingTest>(response);
                    if (pingtest.IsValid())
                    {
                        MessageBox.Show("Ping settings are valid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sign is not valid.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("There has been an error checking the server settings.\nIs the server correctly set?", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
                MessageBox.Show("There has been an error pinging the server.\nCheck your settings.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonTestPing_Click(object sender, EventArgs e) => PingTestAsync();
    }
}
