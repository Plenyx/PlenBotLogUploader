namespace PlenBotLogUploader
{
    partial class FormEditBossData
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
            this.labelSuccessMsg = new System.Windows.Forms.Label();
            this.labelFailMsg = new System.Windows.Forms.Label();
            this.textBoxSuccessMsg = new System.Windows.Forms.TextBox();
            this.textBoxFailMsg = new System.Windows.Forms.TextBox();
            this.textBoxIcon = new System.Windows.Forms.TextBox();
            this.labelIcon = new System.Windows.Forms.Label();
            this.textBoxBossID = new System.Windows.Forms.TextBox();
            this.textBoxBossName = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelBossName = new System.Windows.Forms.Label();
            this.groupBoxCrucial = new System.Windows.Forms.GroupBox();
            this.groupBoxOtherSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxCrucial.SuspendLayout();
            this.groupBoxOtherSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSuccessMsg
            // 
            this.labelSuccessMsg.AutoSize = true;
            this.labelSuccessMsg.Location = new System.Drawing.Point(3, 18);
            this.labelSuccessMsg.Name = "labelSuccessMsg";
            this.labelSuccessMsg.Size = new System.Drawing.Size(144, 13);
            this.labelSuccessMsg.TabIndex = 0;
            this.labelSuccessMsg.Text = "Twitch message on success:";
            // 
            // labelFailMsg
            // 
            this.labelFailMsg.AutoSize = true;
            this.labelFailMsg.Location = new System.Drawing.Point(3, 57);
            this.labelFailMsg.Name = "labelFailMsg";
            this.labelFailMsg.Size = new System.Drawing.Size(118, 13);
            this.labelFailMsg.TabIndex = 1;
            this.labelFailMsg.Text = "Twitch message on fail:";
            // 
            // textBoxSuccessMsg
            // 
            this.textBoxSuccessMsg.Location = new System.Drawing.Point(6, 34);
            this.textBoxSuccessMsg.Name = "textBoxSuccessMsg";
            this.textBoxSuccessMsg.Size = new System.Drawing.Size(364, 20);
            this.textBoxSuccessMsg.TabIndex = 2;
            // 
            // textBoxFailMsg
            // 
            this.textBoxFailMsg.Location = new System.Drawing.Point(6, 73);
            this.textBoxFailMsg.Name = "textBoxFailMsg";
            this.textBoxFailMsg.Size = new System.Drawing.Size(364, 20);
            this.textBoxFailMsg.TabIndex = 3;
            // 
            // textBoxIcon
            // 
            this.textBoxIcon.Location = new System.Drawing.Point(6, 112);
            this.textBoxIcon.Name = "textBoxIcon";
            this.textBoxIcon.Size = new System.Drawing.Size(364, 20);
            this.textBoxIcon.TabIndex = 4;
            // 
            // labelIcon
            // 
            this.labelIcon.AutoSize = true;
            this.labelIcon.Location = new System.Drawing.Point(3, 96);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(162, 13);
            this.labelIcon.TabIndex = 5;
            this.labelIcon.Text = "Icon URL for Discord webhooks:";
            // 
            // textBoxBossID
            // 
            this.textBoxBossID.Location = new System.Drawing.Point(6, 35);
            this.textBoxBossID.Name = "textBoxBossID";
            this.textBoxBossID.Size = new System.Drawing.Size(366, 20);
            this.textBoxBossID.TabIndex = 6;
            // 
            // textBoxBossName
            // 
            this.textBoxBossName.Location = new System.Drawing.Point(6, 74);
            this.textBoxBossName.Name = "textBoxBossName";
            this.textBoxBossName.Size = new System.Drawing.Size(366, 20);
            this.textBoxBossName.TabIndex = 7;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(3, 19);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(236, 13);
            this.labelId.TabIndex = 8;
            this.labelId.Text = "Boss ID (settings will not save if this is left blank):";
            // 
            // labelBossName
            // 
            this.labelBossName.AutoSize = true;
            this.labelBossName.Location = new System.Drawing.Point(3, 58);
            this.labelBossName.Name = "labelBossName";
            this.labelBossName.Size = new System.Drawing.Size(251, 13);
            this.labelBossName.TabIndex = 9;
            this.labelBossName.Text = "Boss name (settings will not save if this is left blank):";
            // 
            // groupBoxCrucial
            // 
            this.groupBoxCrucial.Controls.Add(this.textBoxBossName);
            this.groupBoxCrucial.Controls.Add(this.labelBossName);
            this.groupBoxCrucial.Controls.Add(this.textBoxBossID);
            this.groupBoxCrucial.Controls.Add(this.labelId);
            this.groupBoxCrucial.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCrucial.Name = "groupBoxCrucial";
            this.groupBoxCrucial.Size = new System.Drawing.Size(380, 102);
            this.groupBoxCrucial.TabIndex = 10;
            this.groupBoxCrucial.TabStop = false;
            this.groupBoxCrucial.Text = "Boss data (beware of changing these)";
            // 
            // groupBoxOtherSettings
            // 
            this.groupBoxOtherSettings.Controls.Add(this.textBoxSuccessMsg);
            this.groupBoxOtherSettings.Controls.Add(this.labelSuccessMsg);
            this.groupBoxOtherSettings.Controls.Add(this.labelIcon);
            this.groupBoxOtherSettings.Controls.Add(this.labelFailMsg);
            this.groupBoxOtherSettings.Controls.Add(this.textBoxIcon);
            this.groupBoxOtherSettings.Controls.Add(this.textBoxFailMsg);
            this.groupBoxOtherSettings.Location = new System.Drawing.Point(12, 120);
            this.groupBoxOtherSettings.Name = "groupBoxOtherSettings";
            this.groupBoxOtherSettings.Size = new System.Drawing.Size(380, 143);
            this.groupBoxOtherSettings.TabIndex = 11;
            this.groupBoxOtherSettings.TabStop = false;
            this.groupBoxOtherSettings.Text = "Uploader settings for the boss";
            // 
            // FormEditBossData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 272);
            this.Controls.Add(this.groupBoxOtherSettings);
            this.Controls.Add(this.groupBoxCrucial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditBossData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditBossData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditBossData_FormClosing);
            this.groupBoxCrucial.ResumeLayout(false);
            this.groupBoxCrucial.PerformLayout();
            this.groupBoxOtherSettings.ResumeLayout(false);
            this.groupBoxOtherSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSuccessMsg;
        private System.Windows.Forms.Label labelFailMsg;
        private System.Windows.Forms.TextBox textBoxSuccessMsg;
        private System.Windows.Forms.TextBox textBoxFailMsg;
        private System.Windows.Forms.TextBox textBoxIcon;
        private System.Windows.Forms.Label labelIcon;
        private System.Windows.Forms.TextBox textBoxBossID;
        private System.Windows.Forms.TextBox textBoxBossName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelBossName;
        private System.Windows.Forms.GroupBox groupBoxCrucial;
        private System.Windows.Forms.GroupBox groupBoxOtherSettings;
    }
}