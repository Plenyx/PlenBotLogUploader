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
            labelName = new System.Windows.Forms.Label();
            labelUrl = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            textBoxUrl = new System.Windows.Forms.TextBox();
            checkedListBoxBossesEnable = new System.Windows.Forms.CheckedListBox();
            groupBoxWebhookInfo = new System.Windows.Forms.GroupBox();
            groupBoxBossesEnable = new System.Windows.Forms.GroupBox();
            checkBoxAllowUnknownBossIds = new System.Windows.Forms.CheckBox();
            buttonUnSelectAllGolems = new System.Windows.Forms.Button();
            buttonUnSelectWvW = new System.Windows.Forms.Button();
            buttonUnSelectAllFractals = new System.Windows.Forms.Button();
            buttonUnSelectAllStrikes = new System.Windows.Forms.Button();
            buttonUnSelectAllRaids = new System.Windows.Forms.Button();
            buttonUnSelectAll = new System.Windows.Forms.Button();
            groupBoxConditionalPost = new System.Windows.Forms.GroupBox();
            radioButtonOnlySuccessAndFail = new System.Windows.Forms.RadioButton();
            radioButtonOnlyFail = new System.Windows.Forms.RadioButton();
            radioButtonOnlySuccess = new System.Windows.Forms.RadioButton();
            groupBoxTeam = new System.Windows.Forms.GroupBox();
            comboBoxTeam = new System.Windows.Forms.ComboBox();
            groupBoxLogSummaries = new System.Windows.Forms.GroupBox();
            radioButtonLogSummaryPlayers = new System.Windows.Forms.RadioButton();
            radioButtonLogSummarySquadAndPlayers = new System.Windows.Forms.RadioButton();
            radioButtonLogSummarySquad = new System.Windows.Forms.RadioButton();
            radioButtonLogSummaryNone = new System.Windows.Forms.RadioButton();
            groupBoxWebhookInfo.SuspendLayout();
            groupBoxBossesEnable.SuspendLayout();
            groupBoxConditionalPost.SuspendLayout();
            groupBoxTeam.SuspendLayout();
            groupBoxLogSummaries.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new System.Drawing.Point(8, 25);
            labelName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(116, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Webhook name:";
            // 
            // labelUrl
            // 
            labelUrl.AutoSize = true;
            labelUrl.Location = new System.Drawing.Point(8, 85);
            labelUrl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            labelUrl.Name = "labelUrl";
            labelUrl.Size = new System.Drawing.Size(105, 20);
            labelUrl.TabIndex = 1;
            labelUrl.Text = "Webhook URL:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(11, 49);
            textBoxName.Margin = new System.Windows.Forms.Padding(5);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(501, 27);
            textBoxName.TabIndex = 2;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new System.Drawing.Point(11, 109);
            textBoxUrl.Margin = new System.Windows.Forms.Padding(5);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new System.Drawing.Size(501, 27);
            textBoxUrl.TabIndex = 3;
            // 
            // checkedListBoxBossesEnable
            // 
            checkedListBoxBossesEnable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            checkedListBoxBossesEnable.FormattingEnabled = true;
            checkedListBoxBossesEnable.Location = new System.Drawing.Point(8, 29);
            checkedListBoxBossesEnable.Margin = new System.Windows.Forms.Padding(5);
            checkedListBoxBossesEnable.Name = "checkedListBoxBossesEnable";
            checkedListBoxBossesEnable.Size = new System.Drawing.Size(505, 330);
            checkedListBoxBossesEnable.TabIndex = 6;
            // 
            // groupBoxWebhookInfo
            // 
            groupBoxWebhookInfo.Controls.Add(textBoxName);
            groupBoxWebhookInfo.Controls.Add(labelName);
            groupBoxWebhookInfo.Controls.Add(labelUrl);
            groupBoxWebhookInfo.Controls.Add(textBoxUrl);
            groupBoxWebhookInfo.Location = new System.Drawing.Point(16, 19);
            groupBoxWebhookInfo.Margin = new System.Windows.Forms.Padding(5);
            groupBoxWebhookInfo.Name = "groupBoxWebhookInfo";
            groupBoxWebhookInfo.Padding = new System.Windows.Forms.Padding(5);
            groupBoxWebhookInfo.Size = new System.Drawing.Size(523, 150);
            groupBoxWebhookInfo.TabIndex = 7;
            groupBoxWebhookInfo.TabStop = false;
            groupBoxWebhookInfo.Text = "Webhook info";
            // 
            // groupBoxBossesEnable
            // 
            groupBoxBossesEnable.Controls.Add(checkBoxAllowUnknownBossIds);
            groupBoxBossesEnable.Controls.Add(buttonUnSelectAllGolems);
            groupBoxBossesEnable.Controls.Add(buttonUnSelectWvW);
            groupBoxBossesEnable.Controls.Add(buttonUnSelectAllFractals);
            groupBoxBossesEnable.Controls.Add(buttonUnSelectAllStrikes);
            groupBoxBossesEnable.Controls.Add(buttonUnSelectAllRaids);
            groupBoxBossesEnable.Controls.Add(buttonUnSelectAll);
            groupBoxBossesEnable.Controls.Add(checkedListBoxBossesEnable);
            groupBoxBossesEnable.Location = new System.Drawing.Point(547, 19);
            groupBoxBossesEnable.Margin = new System.Windows.Forms.Padding(5);
            groupBoxBossesEnable.Name = "groupBoxBossesEnable";
            groupBoxBossesEnable.Padding = new System.Windows.Forms.Padding(5);
            groupBoxBossesEnable.Size = new System.Drawing.Size(523, 436);
            groupBoxBossesEnable.TabIndex = 8;
            groupBoxBossesEnable.TabStop = false;
            groupBoxBossesEnable.Text = "Only upload for selected bosses";
            // 
            // checkBoxAllowUnknownBossIds
            // 
            checkBoxAllowUnknownBossIds.AutoSize = true;
            checkBoxAllowUnknownBossIds.Location = new System.Drawing.Point(8, 364);
            checkBoxAllowUnknownBossIds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBoxAllowUnknownBossIds.Name = "checkBoxAllowUnknownBossIds";
            checkBoxAllowUnknownBossIds.Size = new System.Drawing.Size(316, 24);
            checkBoxAllowUnknownBossIds.TabIndex = 13;
            checkBoxAllowUnknownBossIds.Text = "Allow unknown bosses to use this webhook";
            checkBoxAllowUnknownBossIds.UseVisualStyleBackColor = true;
            // 
            // buttonUnSelectAllGolems
            // 
            buttonUnSelectAllGolems.Location = new System.Drawing.Point(361, 391);
            buttonUnSelectAllGolems.Margin = new System.Windows.Forms.Padding(5);
            buttonUnSelectAllGolems.Name = "buttonUnSelectAllGolems";
            buttonUnSelectAllGolems.Size = new System.Drawing.Size(72, 35);
            buttonUnSelectAllGolems.TabIndex = 12;
            buttonUnSelectAllGolems.Text = "Golems";
            buttonUnSelectAllGolems.UseVisualStyleBackColor = true;
            buttonUnSelectAllGolems.Click += ButtonUnSelectAllGolems_Click;
            // 
            // buttonUnSelectWvW
            // 
            buttonUnSelectWvW.Location = new System.Drawing.Point(441, 391);
            buttonUnSelectWvW.Margin = new System.Windows.Forms.Padding(5);
            buttonUnSelectWvW.Name = "buttonUnSelectWvW";
            buttonUnSelectWvW.Size = new System.Drawing.Size(72, 35);
            buttonUnSelectWvW.TabIndex = 11;
            buttonUnSelectWvW.Text = "WvW";
            buttonUnSelectWvW.UseVisualStyleBackColor = true;
            buttonUnSelectWvW.Click += ButtonUnSelectWvW_Click;
            // 
            // buttonUnSelectAllFractals
            // 
            buttonUnSelectAllFractals.Location = new System.Drawing.Point(201, 391);
            buttonUnSelectAllFractals.Margin = new System.Windows.Forms.Padding(5);
            buttonUnSelectAllFractals.Name = "buttonUnSelectAllFractals";
            buttonUnSelectAllFractals.Size = new System.Drawing.Size(72, 35);
            buttonUnSelectAllFractals.TabIndex = 10;
            buttonUnSelectAllFractals.Text = "Fractals";
            buttonUnSelectAllFractals.UseVisualStyleBackColor = true;
            buttonUnSelectAllFractals.Click += ButtonUnSelectAllFractals_Click;
            // 
            // buttonUnSelectAllStrikes
            // 
            buttonUnSelectAllStrikes.Location = new System.Drawing.Point(281, 391);
            buttonUnSelectAllStrikes.Margin = new System.Windows.Forms.Padding(5);
            buttonUnSelectAllStrikes.Name = "buttonUnSelectAllStrikes";
            buttonUnSelectAllStrikes.Size = new System.Drawing.Size(72, 35);
            buttonUnSelectAllStrikes.TabIndex = 9;
            buttonUnSelectAllStrikes.Text = "Strikes";
            buttonUnSelectAllStrikes.UseVisualStyleBackColor = true;
            buttonUnSelectAllStrikes.Click += ButtonUnSelectAllStrikes_Click;
            // 
            // buttonUnSelectAllRaids
            // 
            buttonUnSelectAllRaids.Location = new System.Drawing.Point(121, 391);
            buttonUnSelectAllRaids.Margin = new System.Windows.Forms.Padding(5);
            buttonUnSelectAllRaids.Name = "buttonUnSelectAllRaids";
            buttonUnSelectAllRaids.Size = new System.Drawing.Size(72, 35);
            buttonUnSelectAllRaids.TabIndex = 8;
            buttonUnSelectAllRaids.Text = "Raids";
            buttonUnSelectAllRaids.UseVisualStyleBackColor = true;
            buttonUnSelectAllRaids.Click += ButtonUnSelectAllRaids_Click;
            // 
            // buttonUnSelectAll
            // 
            buttonUnSelectAll.Location = new System.Drawing.Point(6, 391);
            buttonUnSelectAll.Margin = new System.Windows.Forms.Padding(5);
            buttonUnSelectAll.Name = "buttonUnSelectAll";
            buttonUnSelectAll.Size = new System.Drawing.Size(107, 35);
            buttonUnSelectAll.TabIndex = 7;
            buttonUnSelectAll.Text = "(Un)Select all";
            buttonUnSelectAll.UseVisualStyleBackColor = true;
            buttonUnSelectAll.Click += ButtonUnSelectAll_Click;
            // 
            // groupBoxConditionalPost
            // 
            groupBoxConditionalPost.Controls.Add(radioButtonOnlySuccessAndFail);
            groupBoxConditionalPost.Controls.Add(radioButtonOnlyFail);
            groupBoxConditionalPost.Controls.Add(radioButtonOnlySuccess);
            groupBoxConditionalPost.Location = new System.Drawing.Point(16, 271);
            groupBoxConditionalPost.Margin = new System.Windows.Forms.Padding(5);
            groupBoxConditionalPost.Name = "groupBoxConditionalPost";
            groupBoxConditionalPost.Padding = new System.Windows.Forms.Padding(5);
            groupBoxConditionalPost.Size = new System.Drawing.Size(523, 101);
            groupBoxConditionalPost.TabIndex = 9;
            groupBoxConditionalPost.TabStop = false;
            groupBoxConditionalPost.Text = "Use this Webhook if...";
            // 
            // radioButtonOnlySuccessAndFail
            // 
            radioButtonOnlySuccessAndFail.AutoSize = true;
            radioButtonOnlySuccessAndFail.Location = new System.Drawing.Point(11, 67);
            radioButtonOnlySuccessAndFail.Margin = new System.Windows.Forms.Padding(5);
            radioButtonOnlySuccessAndFail.Name = "radioButtonOnlySuccessAndFail";
            radioButtonOnlySuccessAndFail.Size = new System.Drawing.Size(293, 24);
            radioButtonOnlySuccessAndFail.TabIndex = 2;
            radioButtonOnlySuccessAndFail.TabStop = true;
            radioButtonOnlySuccessAndFail.Text = "the encounter is either success or failure";
            radioButtonOnlySuccessAndFail.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlyFail
            // 
            radioButtonOnlyFail.AutoSize = true;
            radioButtonOnlyFail.Location = new System.Drawing.Point(320, 29);
            radioButtonOnlyFail.Margin = new System.Windows.Forms.Padding(5);
            radioButtonOnlyFail.Name = "radioButtonOnlyFail";
            radioButtonOnlyFail.Size = new System.Drawing.Size(193, 24);
            radioButtonOnlyFail.TabIndex = 1;
            radioButtonOnlyFail.TabStop = true;
            radioButtonOnlyFail.Text = "the encounter is a failure";
            radioButtonOnlyFail.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlySuccess
            // 
            radioButtonOnlySuccess.AutoSize = true;
            radioButtonOnlySuccess.Location = new System.Drawing.Point(11, 31);
            radioButtonOnlySuccess.Margin = new System.Windows.Forms.Padding(5);
            radioButtonOnlySuccess.Name = "radioButtonOnlySuccess";
            radioButtonOnlySuccess.Size = new System.Drawing.Size(199, 24);
            radioButtonOnlySuccess.TabIndex = 0;
            radioButtonOnlySuccess.TabStop = true;
            radioButtonOnlySuccess.Text = "the encounter is a success";
            radioButtonOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // groupBoxTeam
            // 
            groupBoxTeam.Controls.Add(comboBoxTeam);
            groupBoxTeam.Location = new System.Drawing.Point(16, 383);
            groupBoxTeam.Margin = new System.Windows.Forms.Padding(5);
            groupBoxTeam.Name = "groupBoxTeam";
            groupBoxTeam.Padding = new System.Windows.Forms.Padding(5);
            groupBoxTeam.Size = new System.Drawing.Size(523, 72);
            groupBoxTeam.TabIndex = 7;
            groupBoxTeam.TabStop = false;
            groupBoxTeam.Text = "Associate with a player team";
            // 
            // comboBoxTeam
            // 
            comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxTeam.FormattingEnabled = true;
            comboBoxTeam.Location = new System.Drawing.Point(11, 29);
            comboBoxTeam.Margin = new System.Windows.Forms.Padding(5);
            comboBoxTeam.MaxDropDownItems = 100;
            comboBoxTeam.Name = "comboBoxTeam";
            comboBoxTeam.Size = new System.Drawing.Size(501, 28);
            comboBoxTeam.TabIndex = 0;
            // 
            // groupBoxLogSummaries
            // 
            groupBoxLogSummaries.Controls.Add(radioButtonLogSummaryPlayers);
            groupBoxLogSummaries.Controls.Add(radioButtonLogSummarySquadAndPlayers);
            groupBoxLogSummaries.Controls.Add(radioButtonLogSummarySquad);
            groupBoxLogSummaries.Controls.Add(radioButtonLogSummaryNone);
            groupBoxLogSummaries.Location = new System.Drawing.Point(16, 177);
            groupBoxLogSummaries.Name = "groupBoxLogSummaries";
            groupBoxLogSummaries.Size = new System.Drawing.Size(523, 86);
            groupBoxLogSummaries.TabIndex = 10;
            groupBoxLogSummaries.TabStop = false;
            groupBoxLogSummaries.Text = "Log summaries";
            // 
            // radioButtonLogSummaryPlayers
            // 
            radioButtonLogSummaryPlayers.AutoSize = true;
            radioButtonLogSummaryPlayers.Location = new System.Drawing.Point(230, 26);
            radioButtonLogSummaryPlayers.Name = "radioButtonLogSummaryPlayers";
            radioButtonLogSummaryPlayers.Size = new System.Drawing.Size(221, 24);
            radioButtonLogSummaryPlayers.TabIndex = 9;
            radioButtonLogSummaryPlayers.TabStop = true;
            radioButtonLogSummaryPlayers.Text = "Detailed player performance";
            radioButtonLogSummaryPlayers.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogSummarySquadAndPlayers
            // 
            radioButtonLogSummarySquadAndPlayers.AutoSize = true;
            radioButtonLogSummarySquadAndPlayers.Location = new System.Drawing.Point(230, 56);
            radioButtonLogSummarySquadAndPlayers.Name = "radioButtonLogSummarySquadAndPlayers";
            radioButtonLogSummarySquadAndPlayers.Size = new System.Drawing.Size(286, 24);
            radioButtonLogSummarySquadAndPlayers.TabIndex = 8;
            radioButtonLogSummarySquadAndPlayers.TabStop = true;
            radioButtonLogSummarySquadAndPlayers.Text = "Detailed squad and player performace";
            radioButtonLogSummarySquadAndPlayers.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogSummarySquad
            // 
            radioButtonLogSummarySquad.AutoSize = true;
            radioButtonLogSummarySquad.Location = new System.Drawing.Point(11, 56);
            radioButtonLogSummarySquad.Name = "radioButtonLogSummarySquad";
            radioButtonLogSummarySquad.Size = new System.Drawing.Size(213, 24);
            radioButtonLogSummarySquad.TabIndex = 7;
            radioButtonLogSummarySquad.TabStop = true;
            radioButtonLogSummarySquad.Text = "Detailed squad information";
            radioButtonLogSummarySquad.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogSummaryNone
            // 
            radioButtonLogSummaryNone.AutoSize = true;
            radioButtonLogSummaryNone.Location = new System.Drawing.Point(11, 26);
            radioButtonLogSummaryNone.Name = "radioButtonLogSummaryNone";
            radioButtonLogSummaryNone.Size = new System.Drawing.Size(66, 24);
            radioButtonLogSummaryNone.TabIndex = 6;
            radioButtonLogSummaryNone.TabStop = true;
            radioButtonLogSummaryNone.Text = "None";
            radioButtonLogSummaryNone.UseVisualStyleBackColor = true;
            // 
            // FormEditDiscordWebhook
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1083, 467);
            Controls.Add(groupBoxLogSummaries);
            Controls.Add(groupBoxTeam);
            Controls.Add(groupBoxConditionalPost);
            Controls.Add(groupBoxBossesEnable);
            Controls.Add(groupBoxWebhookInfo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditDiscordWebhook";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormEditDiscordWebhook";
            FormClosing += FormEditDiscordWebhook_FormClosing;
            groupBoxWebhookInfo.ResumeLayout(false);
            groupBoxWebhookInfo.PerformLayout();
            groupBoxBossesEnable.ResumeLayout(false);
            groupBoxBossesEnable.PerformLayout();
            groupBoxConditionalPost.ResumeLayout(false);
            groupBoxConditionalPost.PerformLayout();
            groupBoxTeam.ResumeLayout(false);
            groupBoxLogSummaries.ResumeLayout(false);
            groupBoxLogSummaries.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxUrl;
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
        private System.Windows.Forms.CheckBox checkBoxAllowUnknownBossIds;
        private System.Windows.Forms.GroupBox groupBoxLogSummaries;
        private System.Windows.Forms.RadioButton radioButtonLogSummaryNone;
        private System.Windows.Forms.RadioButton radioButtonLogSummarySquadAndPlayers;
        private System.Windows.Forms.RadioButton radioButtonLogSummarySquad;
        private System.Windows.Forms.RadioButton radioButtonLogSummaryPlayers;
    }
}