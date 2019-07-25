using System;
using System.Linq;
using System.Windows.Forms;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormTemplateBossData : Form
    {
        #region definitions
        // fields
        private FormBossData bossDataLink;
        #endregion

        public FormTemplateBossData(FormBossData bossDataLink)
        {
            this.bossDataLink = bossDataLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
            textBoxSuccessMessage.Text = Properties.Settings.Default.BossTemplateSuccess;
            textBoxFailMessage.Text = Properties.Settings.Default.BossTemplateFail;
        }

        private void FormTemplateBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.BossTemplateSuccess = textBoxSuccessMessage.Text;
            Properties.Settings.Default.BossTemplateFail = textBoxFailMessage.Text;
        }

        private void ButtonSuccessSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"This will change all non-golem, non-wvw, non-event Twitch message on success to \"{textBoxSuccessMessage.Text}\".\nAre you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                var BossesToChange = bossDataLink.AllBosses
                    .Where(anon => !Bosses.IsGolem(anon.Value.BossId))
                    .Where(anon => !Bosses.IsWvW(anon.Value.BossId))
                    .Where(anon => !Bosses.IsEvent(anon.Value.BossId))
                    .ToDictionary(anon => anon.Key, anon => anon.Value);
                foreach (var key in BossesToChange.Keys)
                {
                    var boss = bossDataLink.AllBosses[key];
                    boss.SuccessMsg = textBoxSuccessMessage.Text;
                }
                MessageBox.Show("All changes are saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonFailSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"This will change all non-golem, non-wvw, non-event Twitch message on fail to \"{textBoxFailMessage.Text}\".\nAre you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                var BossesToChange = bossDataLink.AllBosses
                    .Where(anon => !Bosses.IsGolem(anon.Value.BossId))
                    .Where(anon => !Bosses.IsWvW(anon.Value.BossId))
                    .Where(anon => !Bosses.IsEvent(anon.Value.BossId))
                    .ToDictionary(anon => anon.Key, anon => anon.Value);
                foreach (var key in BossesToChange.Keys)
                {
                    var boss = bossDataLink.AllBosses[key];
                    boss.FailMsg = textBoxFailMessage.Text;
                }
                MessageBox.Show("All changes are saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
