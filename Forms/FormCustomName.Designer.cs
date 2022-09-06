namespace PlenBotLogUploader
{
    partial class FormCustomName
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
            this.checkBoxCustomNameEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxCustomNameSettings = new System.Windows.Forms.GroupBox();
            this.linkLabelGetOAuth = new System.Windows.Forms.LinkLabel();
            this.labelCustomOAuth = new System.Windows.Forms.Label();
            this.labelCustomName = new System.Windows.Forms.Label();
            this.textBoxCustomOAuth = new System.Windows.Forms.TextBox();
            this.textBoxCustomName = new System.Windows.Forms.TextBox();
            this.labelInformation = new System.Windows.Forms.Label();
            this.groupBoxCustomNameSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxCustomNameEnable
            // 
            this.checkBoxCustomNameEnable.AutoSize = true;
            this.checkBoxCustomNameEnable.Location = new System.Drawing.Point(16, 15);
            this.checkBoxCustomNameEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCustomNameEnable.Name = "checkBoxCustomNameEnable";
            this.checkBoxCustomNameEnable.Size = new System.Drawing.Size(320, 20);
            this.checkBoxCustomNameEnable.TabIndex = 0;
            this.checkBoxCustomNameEnable.Text = "Enable using custom name for Twitch bot settings";
            this.checkBoxCustomNameEnable.UseVisualStyleBackColor = true;
            this.checkBoxCustomNameEnable.CheckedChanged += new System.EventHandler(this.CheckBoxCustomNameEnable_CheckedChanged);
            // 
            // groupBoxCustomNameSettings
            // 
            this.groupBoxCustomNameSettings.Controls.Add(this.linkLabelGetOAuth);
            this.groupBoxCustomNameSettings.Controls.Add(this.labelCustomOAuth);
            this.groupBoxCustomNameSettings.Controls.Add(this.labelCustomName);
            this.groupBoxCustomNameSettings.Controls.Add(this.textBoxCustomOAuth);
            this.groupBoxCustomNameSettings.Controls.Add(this.textBoxCustomName);
            this.groupBoxCustomNameSettings.Enabled = false;
            this.groupBoxCustomNameSettings.Location = new System.Drawing.Point(16, 43);
            this.groupBoxCustomNameSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCustomNameSettings.Name = "groupBoxCustomNameSettings";
            this.groupBoxCustomNameSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCustomNameSettings.Size = new System.Drawing.Size(360, 128);
            this.groupBoxCustomNameSettings.TabIndex = 1;
            this.groupBoxCustomNameSettings.TabStop = false;
            this.groupBoxCustomNameSettings.Text = "Custom name settings";
            // 
            // linkLabelGetOAuth
            // 
            this.linkLabelGetOAuth.AutoSize = true;
            this.linkLabelGetOAuth.Location = new System.Drawing.Point(227, 68);
            this.linkLabelGetOAuth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelGetOAuth.Name = "linkLabelGetOAuth";
            this.linkLabelGetOAuth.Size = new System.Drawing.Size(109, 16);
            this.linkLabelGetOAuth.TabIndex = 4;
            this.linkLabelGetOAuth.TabStop = true;
            this.linkLabelGetOAuth.Text = "Generate OAuth2";
            this.linkLabelGetOAuth.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelGetOAuth.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelGetOAuth_LinkClicked);
            // 
            // labelCustomOAuth
            // 
            this.labelCustomOAuth.AutoSize = true;
            this.labelCustomOAuth.Location = new System.Drawing.Point(8, 68);
            this.labelCustomOAuth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCustomOAuth.Name = "labelCustomOAuth";
            this.labelCustomOAuth.Size = new System.Drawing.Size(115, 16);
            this.labelCustomOAuth.TabIndex = 3;
            this.labelCustomOAuth.Text = "OAuth2 password:";
            // 
            // labelCustomName
            // 
            this.labelCustomName.AutoSize = true;
            this.labelCustomName.Location = new System.Drawing.Point(8, 20);
            this.labelCustomName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCustomName.Name = "labelCustomName";
            this.labelCustomName.Size = new System.Drawing.Size(92, 16);
            this.labelCustomName.TabIndex = 2;
            this.labelCustomName.Text = "Custom name:";
            // 
            // textBoxCustomOAuth
            // 
            this.textBoxCustomOAuth.Location = new System.Drawing.Point(8, 87);
            this.textBoxCustomOAuth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCustomOAuth.Name = "textBoxCustomOAuth";
            this.textBoxCustomOAuth.PasswordChar = '*';
            this.textBoxCustomOAuth.Size = new System.Drawing.Size(337, 22);
            this.textBoxCustomOAuth.TabIndex = 1;
            // 
            // textBoxCustomName
            // 
            this.textBoxCustomName.Location = new System.Drawing.Point(8, 39);
            this.textBoxCustomName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCustomName.Name = "textBoxCustomName";
            this.textBoxCustomName.Size = new System.Drawing.Size(337, 22);
            this.textBoxCustomName.TabIndex = 0;
            // 
            // labelInformation
            // 
            this.labelInformation.Location = new System.Drawing.Point(16, 180);
            this.labelInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(360, 32);
            this.labelInformation.TabIndex = 2;
            this.labelInformation.Text = "This feature requires a use of another Twitch account";
            this.labelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCustomName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 220);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.groupBoxCustomNameSettings);
            this.Controls.Add(this.checkBoxCustomNameEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCustomName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom name for the Twitch bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCustomName_FormClosing);
            this.groupBoxCustomNameSettings.ResumeLayout(false);
            this.groupBoxCustomNameSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxCustomNameSettings;
        private System.Windows.Forms.Label labelCustomOAuth;
        private System.Windows.Forms.Label labelCustomName;
        private System.Windows.Forms.LinkLabel linkLabelGetOAuth;
        private System.Windows.Forms.Label labelInformation;
        internal System.Windows.Forms.CheckBox checkBoxCustomNameEnable;
        internal System.Windows.Forms.TextBox textBoxCustomOAuth;
        internal System.Windows.Forms.TextBox textBoxCustomName;
    }
}