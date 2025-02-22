﻿using PlenBotLogUploader.Properties;
using PlenBotLogUploader.Teams;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlenBotLogUploader;

public partial class FormEditTeam : Form
{
    // fields
    private readonly Dictionary<int, Team> allTeams = Teams.Teams.All;
    private readonly int reservedId;
    private readonly Team teamData;
    private readonly FormTeams teamsLink;

    internal FormEditTeam(FormTeams teamsLink, Team teamData, int reservedId)
    {
        this.teamsLink = teamsLink;
        this.teamData = teamData;
        this.reservedId = reservedId;
        InitializeComponent();
        Icon = Resources.AppIcon;
        Text = teamData is null ? "Add a new team" : "Edit an existing team";
        textBoxName.Text = teamData?.Name ?? "";
        this.teamData ??= new Team
        {
            Id = reservedId,
            Name = textBoxName.Text,
            MainCondition = new TeamCondition
            {
                Limiter = TeamLimiter.Exact,
                LimiterValue = 0,
                AccountNames = [],
            },
        };
    }

    private void FormEditTeam_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxName.Text.Trim()))
        {
            return;
        }
        if (allTeams.TryAdd(reservedId, teamData))
        {
            teamsLink.listBoxTeams.Items.Add(allTeams[reservedId]);
        }
        teamData.Name = textBoxName.Text;
        teamsLink.listBoxTeams.DisplayMember = "";
        teamsLink.listBoxTeams.DisplayMember = "Name";
    }

    private void ButtonOpenMainCondition_Click(object sender, EventArgs e)
    {
        new FormEditTeamCondition(teamData, teamData?.MainCondition).ShowDialog();
    }

    private void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        teamData.Name = textBoxName.Text;
        buttonOpenMainCondition.Enabled = !string.IsNullOrWhiteSpace(teamData.Name);
    }
}
