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
            this.checkBoxOnlySuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(86, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Webhook name:";
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(12, 61);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(82, 13);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "Webhook URL:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(15, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(392, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(15, 77);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(392, 20);
            this.textBoxUrl.TabIndex = 3;
            // 
            // checkBoxOnlySuccess
            // 
            this.checkBoxOnlySuccess.AutoSize = true;
            this.checkBoxOnlySuccess.Location = new System.Drawing.Point(15, 110);
            this.checkBoxOnlySuccess.Name = "checkBoxOnlySuccess";
            this.checkBoxOnlySuccess.Size = new System.Drawing.Size(157, 17);
            this.checkBoxOnlySuccess.TabIndex = 4;
            this.checkBoxOnlySuccess.Text = "Upload only successful logs";
            this.checkBoxOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlayers
            // 
            this.checkBoxPlayers.AutoSize = true;
            this.checkBoxPlayers.Location = new System.Drawing.Point(15, 133);
            this.checkBoxPlayers.Name = "checkBoxPlayers";
            this.checkBoxPlayers.Size = new System.Drawing.Size(349, 17);
            this.checkBoxPlayers.TabIndex = 5;
            this.checkBoxPlayers.Text = "Show players and played professions with elite specs in the message";
            this.checkBoxPlayers.UseVisualStyleBackColor = true;
            // 
            // FormEditDiscordWebhook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 159);
            this.Controls.Add(this.checkBoxPlayers);
            this.Controls.Add(this.checkBoxOnlySuccess);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditDiscordWebhook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditDiscordWebhook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditDiscordWebhook_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.CheckBox checkBoxOnlySuccess;
        private System.Windows.Forms.CheckBox checkBoxPlayers;
    }
}