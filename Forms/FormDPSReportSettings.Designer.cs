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
            this.groupBoxDPSReportServer = new System.Windows.Forms.GroupBox();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxDPSReportUsertoken = new System.Windows.Forms.GroupBox();
            this.buttonDPSReportGetToken = new System.Windows.Forms.Button();
            this.buttonDPSReportShowUsertoken = new System.Windows.Forms.Button();
            this.textBoxDPSReportUsertoken = new System.Windows.Forms.TextBox();
            this.checkBoxDPSReportEnableUsertoken = new System.Windows.Forms.CheckBox();
            this.groupBoxDPSReportServer.SuspendLayout();
            this.groupBoxDPSReportUsertoken.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDPSReportServer
            // 
            this.groupBoxDPSReportServer.Controls.Add(this.radioButtonB);
            this.groupBoxDPSReportServer.Controls.Add(this.radioButtonA);
            this.groupBoxDPSReportServer.Controls.Add(this.radioButtonNormal);
            this.groupBoxDPSReportServer.Location = new System.Drawing.Point(13, 13);
            this.groupBoxDPSReportServer.Name = "groupBoxDPSReportServer";
            this.groupBoxDPSReportServer.Size = new System.Drawing.Size(276, 53);
            this.groupBoxDPSReportServer.TabIndex = 0;
            this.groupBoxDPSReportServer.TabStop = false;
            this.groupBoxDPSReportServer.Text = "DPS.report servers";
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(98, 19);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(81, 30);
            this.radioButtonB.TabIndex = 2;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.Text = "b.dps.report\r\n(Recom.)";
            this.radioButtonB.UseVisualStyleBackColor = true;
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Location = new System.Drawing.Point(187, 19);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(83, 30);
            this.radioButtonA.TabIndex = 1;
            this.radioButtonA.Text = "a.dps.report\r\n(Not recom.)";
            this.radioButtonA.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(11, 19);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(72, 30);
            this.radioButtonNormal.TabIndex = 0;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "dps.report\r\n(Recom.)";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // groupBoxDPSReportUsertoken
            // 
            this.groupBoxDPSReportUsertoken.Controls.Add(this.buttonDPSReportGetToken);
            this.groupBoxDPSReportUsertoken.Controls.Add(this.buttonDPSReportShowUsertoken);
            this.groupBoxDPSReportUsertoken.Controls.Add(this.textBoxDPSReportUsertoken);
            this.groupBoxDPSReportUsertoken.Controls.Add(this.checkBoxDPSReportEnableUsertoken);
            this.groupBoxDPSReportUsertoken.Location = new System.Drawing.Point(13, 72);
            this.groupBoxDPSReportUsertoken.Name = "groupBoxDPSReportUsertoken";
            this.groupBoxDPSReportUsertoken.Size = new System.Drawing.Size(277, 73);
            this.groupBoxDPSReportUsertoken.TabIndex = 1;
            this.groupBoxDPSReportUsertoken.TabStop = false;
            this.groupBoxDPSReportUsertoken.Text = "DPS.report user token";
            // 
            // buttonDPSReportGetToken
            // 
            this.buttonDPSReportGetToken.Location = new System.Drawing.Point(157, 15);
            this.buttonDPSReportGetToken.Name = "buttonDPSReportGetToken";
            this.buttonDPSReportGetToken.Size = new System.Drawing.Size(108, 23);
            this.buttonDPSReportGetToken.TabIndex = 3;
            this.buttonDPSReportGetToken.Text = "Get token from API";
            this.buttonDPSReportGetToken.UseVisualStyleBackColor = true;
            this.buttonDPSReportGetToken.Click += new System.EventHandler(this.ButtonDPSReportGetToken_Click);
            // 
            // buttonDPSReportShowUsertoken
            // 
            this.buttonDPSReportShowUsertoken.Enabled = false;
            this.buttonDPSReportShowUsertoken.Location = new System.Drawing.Point(192, 42);
            this.buttonDPSReportShowUsertoken.Name = "buttonDPSReportShowUsertoken";
            this.buttonDPSReportShowUsertoken.Size = new System.Drawing.Size(73, 23);
            this.buttonDPSReportShowUsertoken.TabIndex = 2;
            this.buttonDPSReportShowUsertoken.Text = "Show token";
            this.buttonDPSReportShowUsertoken.UseVisualStyleBackColor = true;
            this.buttonDPSReportShowUsertoken.Click += new System.EventHandler(this.ButtonDPSReportShowUsertoken_Click);
            // 
            // textBoxDPSReportUsertoken
            // 
            this.textBoxDPSReportUsertoken.Enabled = false;
            this.textBoxDPSReportUsertoken.Location = new System.Drawing.Point(11, 42);
            this.textBoxDPSReportUsertoken.Name = "textBoxDPSReportUsertoken";
            this.textBoxDPSReportUsertoken.Size = new System.Drawing.Size(175, 20);
            this.textBoxDPSReportUsertoken.TabIndex = 1;
            this.textBoxDPSReportUsertoken.UseSystemPasswordChar = true;
            // 
            // checkBoxDPSReportEnableUsertoken
            // 
            this.checkBoxDPSReportEnableUsertoken.AutoSize = true;
            this.checkBoxDPSReportEnableUsertoken.Location = new System.Drawing.Point(11, 19);
            this.checkBoxDPSReportEnableUsertoken.Name = "checkBoxDPSReportEnableUsertoken";
            this.checkBoxDPSReportEnableUsertoken.Size = new System.Drawing.Size(148, 17);
            this.checkBoxDPSReportEnableUsertoken.TabIndex = 0;
            this.checkBoxDPSReportEnableUsertoken.Text = "enable custom user token";
            this.checkBoxDPSReportEnableUsertoken.UseVisualStyleBackColor = true;
            this.checkBoxDPSReportEnableUsertoken.CheckedChanged += new System.EventHandler(this.CheckBoxDPSReportEnableUsertoken_CheckedChanged);
            // 
            // FormDPSReportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 155);
            this.Controls.Add(this.groupBoxDPSReportUsertoken);
            this.Controls.Add(this.groupBoxDPSReportServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDPSReportSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DPS.report settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDPSReportSettings_FormClosing);
            this.groupBoxDPSReportServer.ResumeLayout(false);
            this.groupBoxDPSReportServer.PerformLayout();
            this.groupBoxDPSReportUsertoken.ResumeLayout(false);
            this.groupBoxDPSReportUsertoken.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDPSReportServer;
        public System.Windows.Forms.RadioButton radioButtonA;
        public System.Windows.Forms.RadioButton radioButtonNormal;
        public System.Windows.Forms.RadioButton radioButtonB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxDPSReportUsertoken;
        public System.Windows.Forms.TextBox textBoxDPSReportUsertoken;
        public System.Windows.Forms.CheckBox checkBoxDPSReportEnableUsertoken;
        public System.Windows.Forms.Button buttonDPSReportShowUsertoken;
        private System.Windows.Forms.Button buttonDPSReportGetToken;
    }
}