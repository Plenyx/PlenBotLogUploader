using System.Windows.Forms;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormEditBossData : Form
    {
        #region definitions
        // fields
        private FormBossData editLink;
        private BossData data;
        private int reservedId;
        #endregion

        public FormEditBossData(FormBossData editLink, BossData data, int reservedId)
        {
            this.editLink = editLink;
            InitializeComponent();
            this.data = data;
            this.reservedId = reservedId;
            Icon = Properties.Resources.AppIcon;
            if (data == null)
            {
                Text = "Add a new boss";
            }
            else
            {
                Text = $"{data.Name} ({data.BossId})";
            }
            textBoxBossID.Text = data?.BossId.ToString() ?? "";
            textBoxBossName.Text = data?.Name ?? "";
            textBoxSuccessMsg.Text = data?.SuccessMsg ?? "Boss kill";
            textBoxFailMsg.Text = data?.FailMsg ?? "Boss pull";
            textBoxIcon.Text = data?.Icon ?? "";
        }

        private void FormEditBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (int.TryParse(textBoxBossID.Text, out int bossId))
            {
                if (textBoxBossName.Text != "")
                {
                    if (data == null)
                    {
                        editLink.AllBosses[reservedId] = new BossData()
                        {
                            BossId = bossId,
                            Name = textBoxBossName.Text,
                            SuccessMsg = textBoxSuccessMsg.Text,
                            FailMsg = textBoxFailMsg.Text,
                            Icon = textBoxIcon.Text
                        };
                        editLink.listViewBosses.Items.Add(new ListViewItem() { Name = reservedId.ToString(), Text = textBoxBossName.Text });
                    }
                    else
                    {
                        var boss = editLink.AllBosses[reservedId];
                        boss.BossId = bossId;
                        boss.Name = textBoxBossName.Text;
                        boss.SuccessMsg = textBoxSuccessMsg.Text;
                        boss.FailMsg = textBoxFailMsg.Text;
                        boss.Icon = textBoxIcon.Text;
                        editLink.listViewBosses.Items[editLink.listViewBosses.Items.IndexOfKey(reservedId.ToString())].Text = textBoxBossName.Text;
                    }
                }
            }
        }
    }
}
