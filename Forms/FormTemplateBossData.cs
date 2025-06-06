﻿using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.DpsReport;
using PlenBotLogUploader.Properties;
using System;
using System.Linq;
using System.Windows.Forms;
using ZLinq;

namespace PlenBotLogUploader;

public partial class FormTemplateBossData : Form
{
    internal FormTemplateBossData()
    {
        InitializeComponent();
        Icon = Resources.AppIcon;
        textBoxSuccessMessage.Text = ApplicationSettings.Current.BossTemplate.SuccessText;
        textBoxFailMessage.Text = ApplicationSettings.Current.BossTemplate.FailText;
    }

    private void FormTemplateBossData_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
        ApplicationSettings.Current.BossTemplate.SuccessText = textBoxSuccessMessage.Text;
        ApplicationSettings.Current.BossTemplate.FailText = textBoxFailMessage.Text;
        ApplicationSettings.Current.Save();
    }

    private void ButtonSuccessSave_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show($"This will change all non-golem, non-wvw, non-event Twitch message on success to \"{textBoxSuccessMessage.Text}\".\nAre you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (!result.Equals(DialogResult.Yes))
        {
            return;
        }
        var bossesToChange = Bosses.All
            .Where(x => !x.Type.Equals(BossType.Golem) && !x.Type.Equals(BossType.WvW) && !x.Event)
            .ToArray();
        foreach (var boss in bossesToChange.AsValueEnumerable())
        {
            boss.SuccessMsg = textBoxSuccessMessage.Text;
        }
        MessageBox.Show("All changes are saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ButtonFailSave_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show($"This will change all non-golem, non-wvw, non-event Twitch message on fail to \"{textBoxFailMessage.Text}\".\nAre you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (!result.Equals(DialogResult.Yes))
        {
            return;
        }
        var bossesToChange = Bosses.All
            .Where(x => !x.Type.Equals(BossType.Golem) && !x.Type.Equals(BossType.WvW) && !x.Event)
            .ToArray();
        foreach (var boss in bossesToChange.AsValueEnumerable())
        {
            boss.FailMsg = textBoxFailMessage.Text;
        }
        MessageBox.Show("All changes are saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
