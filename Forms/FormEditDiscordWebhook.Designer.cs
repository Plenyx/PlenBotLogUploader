﻿namespace PlenBotLogUploader
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
            this.checkBoxOnlySuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayers = new System.Windows.Forms.CheckBox();
            this.checkedListBoxBossesEnable = new System.Windows.Forms.CheckedListBox();
            this.groupBoxWebhookInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxBossesEnable = new System.Windows.Forms.GroupBox();
            this.groupBoxWebhookInfo.SuspendLayout();
            this.groupBoxBossesEnable.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 16);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(86, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Webhook name:";
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(6, 55);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(82, 13);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "Webhook URL:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(9, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(377, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(9, 71);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(377, 20);
            this.textBoxUrl.TabIndex = 3;
            // 
            // checkBoxOnlySuccess
            // 
            this.checkBoxOnlySuccess.AutoSize = true;
            this.checkBoxOnlySuccess.Location = new System.Drawing.Point(9, 97);
            this.checkBoxOnlySuccess.Name = "checkBoxOnlySuccess";
            this.checkBoxOnlySuccess.Size = new System.Drawing.Size(157, 17);
            this.checkBoxOnlySuccess.TabIndex = 4;
            this.checkBoxOnlySuccess.Text = "Upload only successful logs";
            this.checkBoxOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlayers
            // 
            this.checkBoxPlayers.AutoSize = true;
            this.checkBoxPlayers.Location = new System.Drawing.Point(9, 120);
            this.checkBoxPlayers.Name = "checkBoxPlayers";
            this.checkBoxPlayers.Size = new System.Drawing.Size(349, 17);
            this.checkBoxPlayers.TabIndex = 5;
            this.checkBoxPlayers.Text = "Show players and played professions with elite specs in the message";
            this.checkBoxPlayers.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxBossesEnable
            // 
            this.checkedListBoxBossesEnable.FormattingEnabled = true;
            this.checkedListBoxBossesEnable.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxBossesEnable.Name = "checkedListBoxBossesEnable";
            this.checkedListBoxBossesEnable.Size = new System.Drawing.Size(380, 169);
            this.checkedListBoxBossesEnable.TabIndex = 6;
            // 
            // groupBoxWebhookInfo
            // 
            this.groupBoxWebhookInfo.Controls.Add(this.textBoxName);
            this.groupBoxWebhookInfo.Controls.Add(this.labelName);
            this.groupBoxWebhookInfo.Controls.Add(this.labelUrl);
            this.groupBoxWebhookInfo.Controls.Add(this.checkBoxPlayers);
            this.groupBoxWebhookInfo.Controls.Add(this.textBoxUrl);
            this.groupBoxWebhookInfo.Controls.Add(this.checkBoxOnlySuccess);
            this.groupBoxWebhookInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxWebhookInfo.Name = "groupBoxWebhookInfo";
            this.groupBoxWebhookInfo.Size = new System.Drawing.Size(392, 141);
            this.groupBoxWebhookInfo.TabIndex = 7;
            this.groupBoxWebhookInfo.TabStop = false;
            this.groupBoxWebhookInfo.Text = "Webhook info";
            // 
            // groupBoxBossesEnable
            // 
            this.groupBoxBossesEnable.Controls.Add(this.checkedListBoxBossesEnable);
            this.groupBoxBossesEnable.Location = new System.Drawing.Point(12, 159);
            this.groupBoxBossesEnable.Name = "groupBoxBossesEnable";
            this.groupBoxBossesEnable.Size = new System.Drawing.Size(392, 195);
            this.groupBoxBossesEnable.TabIndex = 8;
            this.groupBoxBossesEnable.TabStop = false;
            this.groupBoxBossesEnable.Text = "Only upload for selected bosses";
            // 
            // FormEditDiscordWebhook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 366);
            this.Controls.Add(this.groupBoxBossesEnable);
            this.Controls.Add(this.groupBoxWebhookInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditDiscordWebhook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditDiscordWebhook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditDiscordWebhook_FormClosing);
            this.groupBoxWebhookInfo.ResumeLayout(false);
            this.groupBoxWebhookInfo.PerformLayout();
            this.groupBoxBossesEnable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.CheckBox checkBoxOnlySuccess;
        private System.Windows.Forms.CheckBox checkBoxPlayers;
        private System.Windows.Forms.CheckedListBox checkedListBoxBossesEnable;
        private System.Windows.Forms.GroupBox groupBoxWebhookInfo;
        private System.Windows.Forms.GroupBox groupBoxBossesEnable;
    }
}