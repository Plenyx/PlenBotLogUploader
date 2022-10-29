namespace PlenBotLogUploader
{
    partial class FormDPSReportSettings
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
            this.groupBoxDPSReportServer = new System.Windows.Forms.GroupBox();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.checkedListBoxUserTokens = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStripUserTokens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditUserToken = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteUserToken = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAddUserToken = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxUserTokens = new System.Windows.Forms.GroupBox();
            this.buttonAddUserToken = new System.Windows.Forms.Button();
            this.groupBoxDPSReportServer.SuspendLayout();
            this.contextMenuStripUserTokens.SuspendLayout();
            this.groupBoxUserTokens.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDPSReportServer
            // 
            this.groupBoxDPSReportServer.Controls.Add(this.radioButtonB);
            this.groupBoxDPSReportServer.Controls.Add(this.radioButtonA);
            this.groupBoxDPSReportServer.Controls.Add(this.radioButtonNormal);
            this.groupBoxDPSReportServer.Location = new System.Drawing.Point(17, 20);
            this.groupBoxDPSReportServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDPSReportServer.Name = "groupBoxDPSReportServer";
            this.groupBoxDPSReportServer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDPSReportServer.Size = new System.Drawing.Size(368, 81);
            this.groupBoxDPSReportServer.TabIndex = 0;
            this.groupBoxDPSReportServer.TabStop = false;
            this.groupBoxDPSReportServer.Text = "DPS.report servers";
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(131, 29);
            this.radioButtonB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(110, 44);
            this.radioButtonB.TabIndex = 2;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.Text = "b.dps.report\r\n(Recom.)";
            this.radioButtonB.UseVisualStyleBackColor = true;
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Location = new System.Drawing.Point(249, 29);
            this.radioButtonA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(114, 44);
            this.radioButtonA.TabIndex = 1;
            this.radioButtonA.Text = "a.dps.report\r\n(Not recom.)";
            this.radioButtonA.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(15, 29);
            this.radioButtonNormal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(98, 44);
            this.radioButtonNormal.TabIndex = 0;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "dps.report\r\n(Recom.)";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxUserTokens
            // 
            this.checkedListBoxUserTokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxUserTokens.ContextMenuStrip = this.contextMenuStripUserTokens;
            this.checkedListBoxUserTokens.FormattingEnabled = true;
            this.checkedListBoxUserTokens.Location = new System.Drawing.Point(6, 26);
            this.checkedListBoxUserTokens.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBoxUserTokens.Name = "checkedListBoxUserTokens";
            this.checkedListBoxUserTokens.Size = new System.Drawing.Size(357, 242);
            this.checkedListBoxUserTokens.TabIndex = 2;
            this.checkedListBoxUserTokens.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxUserTokens_ItemCheck);
            this.checkedListBoxUserTokens.DoubleClick += new System.EventHandler(this.CheckedListBoxUserTokens_DoubleClick);
            // 
            // contextMenuStripUserTokens
            // 
            this.contextMenuStripUserTokens.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripUserTokens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditUserToken,
            this.toolStripMenuItemDeleteUserToken,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemAddUserToken});
            this.contextMenuStripUserTokens.Name = "contextMenuStripUserTokens";
            this.contextMenuStripUserTokens.Size = new System.Drawing.Size(279, 82);
            this.contextMenuStripUserTokens.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripUserTokens_Opening);
            // 
            // toolStripMenuItemEditUserToken
            // 
            this.toolStripMenuItemEditUserToken.Name = "toolStripMenuItemEditUserToken";
            this.toolStripMenuItemEditUserToken.Size = new System.Drawing.Size(278, 24);
            this.toolStripMenuItemEditUserToken.Text = "Edit the selected user token";
            this.toolStripMenuItemEditUserToken.Click += new System.EventHandler(this.ToolStripMenuItemEditUserToken_Click);
            // 
            // toolStripMenuItemDeleteUserToken
            // 
            this.toolStripMenuItemDeleteUserToken.Name = "toolStripMenuItemDeleteUserToken";
            this.toolStripMenuItemDeleteUserToken.Size = new System.Drawing.Size(278, 24);
            this.toolStripMenuItemDeleteUserToken.Text = "Delete the selected user token";
            this.toolStripMenuItemDeleteUserToken.Click += new System.EventHandler(this.ToolStripMenuItemDeleteUserToken_Click);
            // 
            // toolStripSeparatorOne
            // 
            this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            this.toolStripSeparatorOne.Size = new System.Drawing.Size(275, 6);
            // 
            // toolStripMenuItemAddUserToken
            // 
            this.toolStripMenuItemAddUserToken.Name = "toolStripMenuItemAddUserToken";
            this.toolStripMenuItemAddUserToken.Size = new System.Drawing.Size(278, 24);
            this.toolStripMenuItemAddUserToken.Text = "Add a new user token";
            this.toolStripMenuItemAddUserToken.Click += new System.EventHandler(this.ToolStripMenuItemAddUserToken_Click);
            // 
            // groupBoxUserTokens
            // 
            this.groupBoxUserTokens.Controls.Add(this.buttonAddUserToken);
            this.groupBoxUserTokens.Controls.Add(this.checkedListBoxUserTokens);
            this.groupBoxUserTokens.Location = new System.Drawing.Point(16, 102);
            this.groupBoxUserTokens.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxUserTokens.Name = "groupBoxUserTokens";
            this.groupBoxUserTokens.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxUserTokens.Size = new System.Drawing.Size(369, 339);
            this.groupBoxUserTokens.TabIndex = 3;
            this.groupBoxUserTokens.TabStop = false;
            this.groupBoxUserTokens.Text = "DPS.report user tokens";
            // 
            // buttonAddUserToken
            // 
            this.buttonAddUserToken.Location = new System.Drawing.Point(199, 295);
            this.buttonAddUserToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddUserToken.Name = "buttonAddUserToken";
            this.buttonAddUserToken.Size = new System.Drawing.Size(163, 35);
            this.buttonAddUserToken.TabIndex = 4;
            this.buttonAddUserToken.Text = "Add a new user token";
            this.buttonAddUserToken.UseVisualStyleBackColor = true;
            this.buttonAddUserToken.Click += new System.EventHandler(this.ButtonAddUserToken_Click);
            // 
            // FormDPSReportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 460);
            this.Controls.Add(this.groupBoxUserTokens);
            this.Controls.Add(this.groupBoxDPSReportServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDPSReportSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DPS.report settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDPSReportSettings_FormClosing);
            this.groupBoxDPSReportServer.ResumeLayout(false);
            this.groupBoxDPSReportServer.PerformLayout();
            this.contextMenuStripUserTokens.ResumeLayout(false);
            this.groupBoxUserTokens.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDPSReportServer;
        internal System.Windows.Forms.RadioButton radioButtonA;
        internal System.Windows.Forms.RadioButton radioButtonNormal;
        internal System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.CheckedListBox checkedListBoxUserTokens;
        private System.Windows.Forms.GroupBox groupBoxUserTokens;
        private System.Windows.Forms.Button buttonAddUserToken;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUserTokens;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddUserToken;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditUserToken;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteUserToken;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
    }
}