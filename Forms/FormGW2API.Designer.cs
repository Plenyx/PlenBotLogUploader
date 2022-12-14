namespace PlenBotLogUploader
{
    partial class FormGW2API
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
			this.components = new System.ComponentModel.Container();
			this.labelAPIKeyInfo = new System.Windows.Forms.Label();
			this.listBoxAPIKeys = new System.Windows.Forms.ListBox();
			this.contextMenuStripEditAPIKeys = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemEditKey = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemRemoveKey = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemAddKey = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonAddAPIKey = new System.Windows.Forms.Button();
			this.buttonGetHardstuckBuildLink = new System.Windows.Forms.Button();
			this.ButtonBuildCodeCompressionSettings = new System.Windows.Forms.Button();
			this.contextMenuStripEditAPIKeys.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelAPIKeyInfo
			// 
			this.labelAPIKeyInfo.Location = new System.Drawing.Point(7, 303);
			this.labelAPIKeyInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelAPIKeyInfo.Name = "labelAPIKeyInfo";
			this.labelAPIKeyInfo.Size = new System.Drawing.Size(491, 68);
			this.labelAPIKeyInfo.TabIndex = 1;
			this.labelAPIKeyInfo.Text = "API keys are used with \"!ign\" and \"!build\" Twitch commands.\r\nYou do not need to s" +
    "et it unless you want to use these Twitch commands.";
			this.labelAPIKeyInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listBoxAPIKeys
			// 
			this.listBoxAPIKeys.BackColor = System.Drawing.Color.White;
			this.listBoxAPIKeys.ContextMenuStrip = this.contextMenuStripEditAPIKeys;
			this.listBoxAPIKeys.FormattingEnabled = true;
			this.listBoxAPIKeys.ItemHeight = 15;
			this.listBoxAPIKeys.Location = new System.Drawing.Point(10, 11);
			this.listBoxAPIKeys.Name = "listBoxAPIKeys";
			this.listBoxAPIKeys.Size = new System.Drawing.Size(793, 289);
			this.listBoxAPIKeys.TabIndex = 2;
			this.listBoxAPIKeys.DoubleClick += new System.EventHandler(this.ListBoxAPIKeys_DoubleClick);
			// 
			// contextMenuStripEditAPIKeys
			// 
			this.contextMenuStripEditAPIKeys.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripEditAPIKeys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditKey,
            this.toolStripMenuItemRemoveKey,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemAddKey});
			this.contextMenuStripEditAPIKeys.Name = "contextMenuStripEditAPIKeys";
			this.contextMenuStripEditAPIKeys.Size = new System.Drawing.Size(226, 76);
			this.contextMenuStripEditAPIKeys.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripEditAPIKeys_Opening);
			// 
			// toolStripMenuItemEditKey
			// 
			this.toolStripMenuItemEditKey.Name = "toolStripMenuItemEditKey";
			this.toolStripMenuItemEditKey.Size = new System.Drawing.Size(225, 22);
			this.toolStripMenuItemEditKey.Text = "Edit the selected API key";
			this.toolStripMenuItemEditKey.Click += new System.EventHandler(this.ToolStripMenuItemEditKey_Click);
			// 
			// toolStripMenuItemRemoveKey
			// 
			this.toolStripMenuItemRemoveKey.Name = "toolStripMenuItemRemoveKey";
			this.toolStripMenuItemRemoveKey.Size = new System.Drawing.Size(225, 22);
			this.toolStripMenuItemRemoveKey.Text = "Remove the selected API key";
			this.toolStripMenuItemRemoveKey.Click += new System.EventHandler(this.ToolStripMenuItemRemoveKey_Click);
			// 
			// toolStripSeparatorOne
			// 
			this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
			this.toolStripSeparatorOne.Size = new System.Drawing.Size(222, 6);
			// 
			// toolStripMenuItemAddKey
			// 
			this.toolStripMenuItemAddKey.Name = "toolStripMenuItemAddKey";
			this.toolStripMenuItemAddKey.Size = new System.Drawing.Size(225, 22);
			this.toolStripMenuItemAddKey.Text = "Add a new API key";
			this.toolStripMenuItemAddKey.Click += new System.EventHandler(this.ToolStripMenuItemAddKey_Click);
			// 
			// buttonAddAPIKey
			// 
			this.buttonAddAPIKey.Location = new System.Drawing.Point(671, 307);
			this.buttonAddAPIKey.Margin = new System.Windows.Forms.Padding(4);
			this.buttonAddAPIKey.Name = "buttonAddAPIKey";
			this.buttonAddAPIKey.Size = new System.Drawing.Size(132, 26);
			this.buttonAddAPIKey.TabIndex = 3;
			this.buttonAddAPIKey.Text = "Add a new API key";
			this.buttonAddAPIKey.UseVisualStyleBackColor = true;
			this.buttonAddAPIKey.Click += new System.EventHandler(this.ButtonAddAPIKey_Click);
			// 
			// buttonGetHardstuckBuildLink
			// 
			this.buttonGetHardstuckBuildLink.Location = new System.Drawing.Point(478, 340);
			this.buttonGetHardstuckBuildLink.Margin = new System.Windows.Forms.Padding(4);
			this.buttonGetHardstuckBuildLink.Name = "buttonGetHardstuckBuildLink";
			this.buttonGetHardstuckBuildLink.Size = new System.Drawing.Size(325, 26);
			this.buttonGetHardstuckBuildLink.TabIndex = 4;
			this.buttonGetHardstuckBuildLink.Text = "Get Hardstuck build link for the current character";
			this.buttonGetHardstuckBuildLink.UseVisualStyleBackColor = true;
			this.buttonGetHardstuckBuildLink.Click += new System.EventHandler(this.ButtonGetHardStuckCode_Click);
			// 
			// ButtonBuildCodeCompressionSettings
			// 
			this.ButtonBuildCodeCompressionSettings.Location = new System.Drawing.Point(478, 307);
			this.ButtonBuildCodeCompressionSettings.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonBuildCodeCompressionSettings.Name = "ButtonBuildCodeCompressionSettings";
			this.ButtonBuildCodeCompressionSettings.Size = new System.Drawing.Size(185, 26);
			this.ButtonBuildCodeCompressionSettings.TabIndex = 5;
			this.ButtonBuildCodeCompressionSettings.Text = "\'!build\' compression settings";
			this.ButtonBuildCodeCompressionSettings.UseVisualStyleBackColor = true;
			this.ButtonBuildCodeCompressionSettings.Click += new System.EventHandler(this.ButtonBuildCodeCompressionSettings_Click);
			// 
			// FormGW2API
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(816, 380);
			this.Controls.Add(this.ButtonBuildCodeCompressionSettings);
			this.Controls.Add(this.buttonGetHardstuckBuildLink);
			this.Controls.Add(this.buttonAddAPIKey);
			this.Controls.Add(this.listBoxAPIKeys);
			this.Controls.Add(this.labelAPIKeyInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGW2API";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GW2 API settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGW2API_FormClosing);
			this.contextMenuStripEditAPIKeys.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelAPIKeyInfo;
        private System.Windows.Forms.ListBox listBoxAPIKeys;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditAPIKeys;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddKey;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditKey;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveKey;
        private System.Windows.Forms.Button buttonAddAPIKey;
        private System.Windows.Forms.Button buttonGetHardstuckBuildLink;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
		private System.Windows.Forms.Button ButtonBuildCodeCompressionSettings;
	}
}