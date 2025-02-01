using PlenBotLogUploader.DiscordApi;
using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormTeams : Form
{
    // fields
    private readonly Dictionary<int, Team> allTeams;
    private readonly Dictionary<int, DiscordWebhookData> allWebhooks = DiscordWebhooks.All;
    private int teamIdsKey;

    internal FormTeams()
    {
        InitializeComponent();
        Icon = Resources.AppIcon;
        allTeams = LoadTeams();

        teamIdsKey = allTeams.Values.Select(x => x.Id).OrderByDescending(x => x).First() + 1;

        foreach (var key in allTeams.Keys.Skip(1).ToArray())
        {
            listBoxTeams.Items.Add(allTeams[key]);
        }
    }

    private static Dictionary<int, Team> LoadTeams()
    {
        try
        {
            return File.Exists(Teams.Teams.JsonFileLocation) ? Teams.Teams.FromJsonFile(Teams.Teams.JsonFileLocation) : Teams.Teams.ResetDictionary();
        }
        catch
        {
            return Teams.Teams.ResetDictionary();
        }
    }

    private void FormTeams_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
        Teams.Teams.SaveToJson(allTeams);
    }

    private void ContextMenuStripInteract_Opening(object sender, CancelEventArgs e)
    {
        var toggle = listBoxTeams.SelectedItems.Count > 0;
        toolStripMenuItemEdit.Enabled = toggle;
        toolStripMenuItemDelete.Enabled = toggle;
    }

    private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
    {
        var item = (Team)listBoxTeams.SelectedItem;
        if (item is null)
        {
            return;
        }
        foreach (var webhook in allWebhooks.Values.Where(x => x.Team.Equals(item)))
        {
            webhook.Team = allTeams.Values.First();
        }
        listBoxTeams.SelectedItem = null;
        allTeams.Remove(item.Id);
        listBoxTeams.Items.Remove(item);
    }

    private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
    {
        var item = (Team)listBoxTeams.SelectedItem;
        if (item is null)
        {
            return;
        }
        listBoxTeams.SelectedItem = null;
        new FormEditTeam(this, item, item.Id).ShowDialog();
    }

    private void ListBoxTeams_DoubleClick(object sender, EventArgs e)
    {
        if (listBoxTeams.SelectedItem is not null)
        {
            var item = (Team)listBoxTeams.SelectedItem;
            new FormEditTeam(this, item, item.Id).ShowDialog();
        }
        listBoxTeams.SelectedItem = null;
    }

    private void AddNewClick()
    {
        teamIdsKey++;
        listBoxTeams.SelectedItem = null;
        new FormEditTeam(this, null, teamIdsKey).ShowDialog();
    }

    private void ButtonAddTeam_Click(object sender, EventArgs e) => AddNewClick();

    private void ToolStripMenuItemAdd_Click(object sender, EventArgs e) => AddNewClick();
}
