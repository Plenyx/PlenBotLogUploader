namespace PlenBotLogUploader
{
    partial class FormEditDiscordWebhook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.checkBoxPlayers = new System.Windows.Forms.CheckBox();
            this.checkedListBoxBossesEnable = new System.Windows.Forms.CheckedListBox();
            this.groupBoxWebhookInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxBossesEnable = new System.Windows.Forms.GroupBox();
            this.buttonUnSelectAllGolems = new System.Windows.Forms.Button();
            this.buttonUnSelectWvW = new System.Windows.Forms.Button();
            this.buttonUnSelectAllFractals = new System.Windows.Forms.Button();
            this.buttonUnSelectAllStrikes = new System.Windows.Forms.Button();
            this.buttonUnSelectAllRaids = new System.Windows.Forms.Button();
            this.buttonUnSelectAll = new System.Windows.Forms.Button();
            this.groupBoxConditionalPost = new System.Windows.Forms.GroupBox();
            this.radioButtonOnlySuccessAndFail = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyFail = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlySuccess = new System.Windows.Forms.RadioButton();
            this.groupBoxTeam = new System.Windows.Forms.GroupBox();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.groupBoxWebhookInfo.SuspendLayout();
            this.groupBoxBossesEnable.SuspendLayout();
            this.groupBoxConditionalPost.SuspendLayout();
            this.groupBoxTeam.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 20);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(106, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Webhook name:";
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(8, 68);
            this.labelUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(99, 16);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "Webhook URL:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 39);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(501, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(12, 87);
            this.textBoxUrl.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(501, 22);
            this.textBoxUrl.TabIndex = 3;
            // 
            // checkBoxPlayers
            // 
            this.checkBoxPlayers.AutoSize = true;
            this.checkBoxPlayers.Location = new System.Drawing.Point(12, 119);
            this.checkBoxPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPlayers.Name = "checkBoxPlayers";
            this.checkBoxPlayers.Size = new System.Drawing.Size(413, 20);
            this.checkBoxPlayers.TabIndex = 5;
            this.checkBoxPlayers.Text = "Show detailed information about players and squad performance";
            this.checkBoxPlayers.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxBossesEnable
            // 
            this.checkedListBoxBossesEnable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxBossesEnable.FormattingEnabled = true;
            this.checkedListBoxBossesEnable.Location = new System.Drawing.Point(8, 23);
            this.checkedListBoxBossesEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxBossesEnable.Name = "checkedListBoxBossesEnable";
            this.checkedListBoxBossesEnable.Size = new System.Drawing.Size(505, 255);
            this.checkedListBoxBossesEnable.TabIndex = 6;
            // 
            // groupBoxWebhookInfo
            // 
            this.groupBoxWebhookInfo.Controls.Add(this.textBoxName);
            this.groupBoxWebhookInfo.Controls.Add(this.labelName);
            this.groupBoxWebhookInfo.Controls.Add(this.labelUrl);
            this.groupBoxWebhookInfo.Controls.Add(this.checkBoxPlayers);
            this.groupBoxWebhookInfo.Controls.Add(this.textBoxUrl);
            this.groupBoxWebhookInfo.Location = new System.Drawing.Point(16, 15);
            this.groupBoxWebhookInfo.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxWebhookInfo.Name = "groupBoxWebhookInfo";
            this.groupBoxWebhookInfo.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxWebhookInfo.Size = new System.Drawing.Size(523, 149);
            this.groupBoxWebhookInfo.TabIndex = 7;
            this.groupBoxWebhookInfo.TabStop = false;
            this.groupBoxWebhookInfo.Text = "Webhook info";
            // 
            // groupBoxBossesEnable
            // 
            this.groupBoxBossesEnable.Controls.Add(this.buttonUnSelectAllGolems);
            this.groupBoxBossesEnable.Controls.Add(this.buttonUnSelectWvW);
            this.groupBoxBossesEnable.Controls.Add(this.buttonUnSelectAllFractals);
            this.groupBoxBossesEnable.Controls.Add(this.buttonUnSelectAllStrikes);
            this.groupBoxBossesEnable.Controls.Add(this.buttonUnSelectAllRaids);
            this.groupBoxBossesEnable.Controls.Add(this.buttonUnSelectAll);
            this.groupBoxBossesEnable.Controls.Add(this.checkedListBoxBossesEnable);
            this.groupBoxBossesEnable.Location = new System.Drawing.Point(547, 15);
            this.groupBoxBossesEnable.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxBossesEnable.Name = "groupBoxBossesEnable";
            this.groupBoxBossesEnable.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxBossesEnable.Size = new System.Drawing.Size(523, 334);
            this.groupBoxBossesEnable.TabIndex = 8;
            this.groupBoxBossesEnable.TabStop = false;
            this.groupBoxBossesEnable.Text = "Only upload for selected bosses";
            // 
            // buttonUnSelectAllGolems
            // 
            this.buttonUnSelectAllGolems.Location = new System.Drawing.Point(363, 298);
            this.buttonUnSelectAllGolems.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnSelectAllGolems.Name = "buttonUnSelectAllGolems";
            this.buttonUnSelectAllGolems.Size = new System.Drawing.Size(72, 28);
            this.buttonUnSelectAllGolems.TabIndex = 12;
            this.buttonUnSelectAllGolems.Text = "Golems";
            this.buttonUnSelectAllGolems.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllGolems.Click += new System.EventHandler(this.ButtonUnSelectAllGolems_Click);
            // 
            // buttonUnSelectWvW
            // 
            this.buttonUnSelectWvW.Location = new System.Drawing.Point(443, 298);
            this.buttonUnSelectWvW.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnSelectWvW.Name = "buttonUnSelectWvW";
            this.buttonUnSelectWvW.Size = new System.Drawing.Size(72, 28);
            this.buttonUnSelectWvW.TabIndex = 11;
            this.buttonUnSelectWvW.Text = "WvW";
            this.buttonUnSelectWvW.UseVisualStyleBackColor = true;
            this.buttonUnSelectWvW.Click += new System.EventHandler(this.ButtonUnSelectWvW_Click);
            // 
            // buttonUnSelectAllFractals
            // 
            this.buttonUnSelectAllFractals.Location = new System.Drawing.Point(204, 298);
            this.buttonUnSelectAllFractals.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnSelectAllFractals.Name = "buttonUnSelectAllFractals";
            this.buttonUnSelectAllFractals.Size = new System.Drawing.Size(72, 28);
            this.buttonUnSelectAllFractals.TabIndex = 10;
            this.buttonUnSelectAllFractals.Text = "Fractals";
            this.buttonUnSelectAllFractals.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllFractals.Click += new System.EventHandler(this.ButtonUnSelectAllFractals_Click);
            // 
            // buttonUnSelectAllStrikes
            // 
            this.buttonUnSelectAllStrikes.Location = new System.Drawing.Point(283, 298);
            this.buttonUnSelectAllStrikes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnSelectAllStrikes.Name = "buttonUnSelectAllStrikes";
            this.buttonUnSelectAllStrikes.Size = new System.Drawing.Size(72, 28);
            this.buttonUnSelectAllStrikes.TabIndex = 9;
            this.buttonUnSelectAllStrikes.Text = "Strikes";
            this.buttonUnSelectAllStrikes.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllStrikes.Click += new System.EventHandler(this.ButtonUnSelectAllStrikes_Click);
            // 
            // buttonUnSelectAllRaids
            // 
            this.buttonUnSelectAllRaids.Location = new System.Drawing.Point(124, 298);
            this.buttonUnSelectAllRaids.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnSelectAllRaids.Name = "buttonUnSelectAllRaids";
            this.buttonUnSelectAllRaids.Size = new System.Drawing.Size(72, 28);
            this.buttonUnSelectAllRaids.TabIndex = 8;
            this.buttonUnSelectAllRaids.Text = "Raids";
            this.buttonUnSelectAllRaids.UseVisualStyleBackColor = true;
            this.buttonUnSelectAllRaids.Click += new System.EventHandler(this.ButtonUnSelectAllRaids_Click);
            // 
            // buttonUnSelectAll
            // 
            this.buttonUnSelectAll.Location = new System.Drawing.Point(8, 298);
            this.buttonUnSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUnSelectAll.Name = "buttonUnSelectAll";
            this.buttonUnSelectAll.Size = new System.Drawing.Size(108, 28);
            this.buttonUnSelectAll.TabIndex = 7;
            this.buttonUnSelectAll.Text = "(Un)Select all";
            this.buttonUnSelectAll.UseVisualStyleBackColor = true;
            this.buttonUnSelectAll.Click += new System.EventHandler(this.ButtonUnSelectAll_Click);
            // 
            // groupBoxConditionalPost
            // 
            this.groupBoxConditionalPost.Controls.Add(this.radioButtonOnlySuccessAndFail);
            this.groupBoxConditionalPost.Controls.Add(this.radioButtonOnlyFail);
            this.groupBoxConditionalPost.Controls.Add(this.radioButtonOnlySuccess);
            this.groupBoxConditionalPost.Location = new System.Drawing.Point(16, 185);
            this.groupBoxConditionalPost.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxConditionalPost.Name = "groupBoxConditionalPost";
            this.groupBoxConditionalPost.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxConditionalPost.Size = new System.Drawing.Size(523, 81);
            this.groupBoxConditionalPost.TabIndex = 9;
            this.groupBoxConditionalPost.TabStop = false;
            this.groupBoxConditionalPost.Text = "Use this Webhook if...";
            // 
            // radioButtonOnlySuccessAndFail
            // 
            this.radioButtonOnlySuccessAndFail.AutoSize = true;
            this.radioButtonOnlySuccessAndFail.Location = new System.Drawing.Point(12, 53);
            this.radioButtonOnlySuccessAndFail.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonOnlySuccessAndFail.Name = "radioButtonOnlySuccessAndFail";
            this.radioButtonOnlySuccessAndFail.Size = new System.Drawing.Size(264, 20);
            this.radioButtonOnlySuccessAndFail.TabIndex = 2;
            this.radioButtonOnlySuccessAndFail.TabStop = true;
            this.radioButtonOnlySuccessAndFail.Text = "the encounter is either success or failure";
            this.radioButtonOnlySuccessAndFail.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlyFail
            // 
            this.radioButtonOnlyFail.AutoSize = true;
            this.radioButtonOnlyFail.Location = new System.Drawing.Point(327, 23);
            this.radioButtonOnlyFail.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonOnlyFail.Name = "radioButtonOnlyFail";
            this.radioButtonOnlyFail.Size = new System.Drawing.Size(171, 20);
            this.radioButtonOnlyFail.TabIndex = 1;
            this.radioButtonOnlyFail.TabStop = true;
            this.radioButtonOnlyFail.Text = "the encounter is a failure";
            this.radioButtonOnlyFail.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlySuccess
            // 
            this.radioButtonOnlySuccess.AutoSize = true;
            this.radioButtonOnlySuccess.Location = new System.Drawing.Point(12, 25);
            this.radioButtonOnlySuccess.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonOnlySuccess.Name = "radioButtonOnlySuccess";
            this.radioButtonOnlySuccess.Size = new System.Drawing.Size(185, 20);
            this.radioButtonOnlySuccess.TabIndex = 0;
            this.radioButtonOnlySuccess.TabStop = true;
            this.radioButtonOnlySuccess.Text = "the encounter is a success";
            this.radioButtonOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // groupBoxTeam
            // 
            this.groupBoxTeam.Controls.Add(this.comboBoxTeam);
            this.groupBoxTeam.Location = new System.Drawing.Point(16, 289);
            this.groupBoxTeam.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTeam.Name = "groupBoxTeam";
            this.groupBoxTeam.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTeam.Size = new System.Drawing.Size(523, 59);
            this.groupBoxTeam.TabIndex = 7;
            this.groupBoxTeam.TabStop = false;
            this.groupBoxTeam.Text = "Associate with a player team";
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(12, 23);
            this.comboBoxTeam.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTeam.MaxDropDownItems = 100;
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(501, 24);
            this.comboBoxTeam.TabIndex = 0;
            // 
            // FormEditDiscordWebhook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 358);
            this.Controls.Add(this.groupBoxTeam);
            this.Controls.Add(this.groupBoxConditionalPost);
            this.Controls.Add(this.groupBoxBossesEnable);
            this.Controls.Add(this.groupBoxWebhookInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditDiscordWebhook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditDiscordWebhook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditDiscordWebhook_FormClosing);
            this.groupBoxWebhookInfo.ResumeLayout(false);
            this.groupBoxWebhookInfo.PerformLayout();
            this.groupBoxBossesEnable.ResumeLayout(false);
            this.groupBoxConditionalPost.ResumeLayout(false);
            this.groupBoxConditionalPost.PerformLayout();
            this.groupBoxTeam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.CheckBox checkBoxPlayers;
        private System.Windows.Forms.CheckedListBox checkedListBoxBossesEnable;
        private System.Windows.Forms.GroupBox groupBoxWebhookInfo;
        private System.Windows.Forms.GroupBox groupBoxBossesEnable;
        private System.Windows.Forms.GroupBox groupBoxConditionalPost;
        private System.Windows.Forms.RadioButton radioButtonOnlySuccessAndFail;
        private System.Windows.Forms.RadioButton radioButtonOnlyFail;
        private System.Windows.Forms.RadioButton radioButtonOnlySuccess;
        private System.Windows.Forms.GroupBox groupBoxTeam;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Button buttonUnSelectAll;
        private System.Windows.Forms.Button buttonUnSelectWvW;
        private System.Windows.Forms.Button buttonUnSelectAllFractals;
        private System.Windows.Forms.Button buttonUnSelectAllStrikes;
        private System.Windows.Forms.Button buttonUnSelectAllRaids;
        private System.Windows.Forms.Button buttonUnSelectAllGolems;
    }
}