using PlenBotLogUploader.Properties;
using PlenBotLogUploader.RemotePing;
using System;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormEditPing : Form
{
    private readonly bool addNew;
    private readonly PingConfiguration config;
    // fields
    private readonly FormPings pingLink;
    private readonly int reservedId;

    internal FormEditPing(FormPings pingLink, int reservedId, bool addNew, PingConfiguration config)
    {
        this.pingLink = pingLink;
        this.config = config;
        this.reservedId = reservedId;
        this.addNew = addNew;
        InitializeComponent();
        Icon = Resources.AppIcon;
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
            case PingMethod.Patch:
                radioButtonMethodPatch.Checked = true;
                break;
            default:
                radioButtonMethodPost.Checked = true;
                break;
        }
        if (!config?.Authentication.Active ?? true)
        {
            radioButtonNoAuthorization.Checked = true;
        }
        else if (config?.Authentication.UseAsAuth ?? false)
        {
            radioButtonUseAuthField.Checked = true;
        }
        else if (!config?.Authentication.UseAsAuth ?? false)
        {
            radioButtonUseNormalField.Checked = true;
        }
        if (config?.SendDataAsJson ?? true)
        {
            checkBoxSendDataAsJson.Checked = true;
            radioButtonUseNormalField.Enabled = false;
            if (radioButtonUseNormalField.Checked)
            {
                radioButtonNoAuthorization.Checked = true;
            }
        }
    }

    private void FormPing_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxName.Text))
        {
            return;
        }
        if (addNew)
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
            else if (radioButtonMethodPatch.Checked)
            {
                chosenMethod = PingMethod.Patch;
            }
            var auth = new PingAuthentication
            {
                Active = !radioButtonNoAuthorization.Checked && textBoxAuthToken.Text.Trim() != "",
                UseAsAuth = radioButtonUseAuthField.Checked,
                AuthName = textBoxAuthName.Text,
                AuthToken = textBoxAuthToken.Text,
            };
            pingLink.AllPings[reservedId] = new PingConfiguration
            {
                Active = false,
                Name = textBoxName.Text,
                Url = textBoxURL.Text,
                Method = chosenMethod,
                Authentication = auth,
                SendDataAsJson = checkBoxSendDataAsJson.Enabled,
            };
            pingLink.listViewPings.Items.Add(new ListViewItem
            {
                Name = reservedId.ToString(),
                Text = textBoxName.Text,
                Checked = false,
            });
            return;
        }
        if (pingLink.AllPings.TryGetValue(reservedId, out var pingConfig))
        {
            pingConfig.Active = config.Active;
            pingConfig.Name = textBoxName.Text;
            pingConfig.Url = textBoxURL.Text;
            pingConfig.SendDataAsJson = checkBoxSendDataAsJson.Checked;
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
            else if (radioButtonMethodPatch.Checked)
            {
                pingLink.AllPings[reservedId].Method = PingMethod.Patch;
            }
            else
            {
                pingLink.AllPings[reservedId].Method = PingMethod.Post;
            }

            pingConfig.Authentication.Active = !radioButtonNoAuthorization.Checked && textBoxAuthToken.Text.Trim() != "";
            pingConfig.Authentication.UseAsAuth = radioButtonUseAuthField.Checked;
            pingConfig.Authentication.AuthName = textBoxAuthName.Text;
            pingConfig.Authentication.AuthToken = textBoxAuthToken.Text;
            pingLink.listViewPings.Items[pingLink.listViewPings.Items.IndexOfKey(reservedId.ToString())] = new ListViewItem
            {
                Name = reservedId.ToString(),
                Text = textBoxName.Text,
                Checked = config.Active,
            };
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
        else if (radioButtonMethodPatch.Checked)
        {
            chosenMethod = PingMethod.Patch;
        }
        var auth = new PingAuthentication
        {
            Active = !radioButtonNoAuthorization.Checked && textBoxAuthToken.Text.Trim() != "",
            UseAsAuth = radioButtonUseAuthField.Checked,
            AuthName = textBoxAuthName.Text,
            AuthToken = textBoxAuthToken.Text,
        };
        var tempPing = new PingConfiguration
        {
            Active = false,
            Name = textBoxName.Text,
            Url = textBoxURL.Text,
            Method = chosenMethod,
            Authentication = auth,
            SendDataAsJson = checkBoxSendDataAsJson.Checked,
        };
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

    private void RadioButtonNoAuthorization_CheckedChanged(object sender, EventArgs e)
    {
        var toggle = !radioButtonNoAuthorization.Checked;
        textBoxAuthName.Enabled = toggle;
        textBoxAuthToken.Enabled = toggle;
    }

    private void CheckBoxSendDataAsJson_CheckedChanged(object sender, EventArgs e)
    {
        var toggle = checkBoxSendDataAsJson.Checked;
        radioButtonUseNormalField.Enabled = !toggle;
        if (radioButtonUseNormalField.Checked && toggle)
        {
            radioButtonNoAuthorization.Checked = true;
        }
    }
}
