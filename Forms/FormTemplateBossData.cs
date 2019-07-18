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
        }

        private void FormTemplateBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ButtonSuccessSave_Click(object sender, EventArgs e)
        {
            var BossesToChange = bossDataLink.AllBosses
                .Where(anon => !Bosses.IsGolem(anon.Value.BossId))
                .Where(anon => !Bosses.IsWvW(anon.Value.BossId))
                .Where(anon => !Bosses.IsEvent(anon.Value.BossId))
                .ToDictionary(anon => anon.Key, anon => anon.Value);
            foreach(var key in BossesToChange.Keys)
            {
                var boss = bossDataLink.AllBosses[key];
                boss.SuccessMsg = textBoxSuccessMessage.Text;
            }
        }

        private void ButtonFailSave_Click(object sender, EventArgs e)
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
        }
    }
}
