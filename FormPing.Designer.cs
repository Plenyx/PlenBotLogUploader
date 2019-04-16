namespace PlenBotLogUploader
{
    partial class FormPing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPing));
            this.checkBoxEnablePing = new System.Windows.Forms.CheckBox();
            this.groupBoxRemoteSettings = new System.Windows.Forms.GroupBox();
            this.buttonTestPing = new System.Windows.Forms.Button();
            this.buttonPlenyxWay = new System.Windows.Forms.Button();
            this.groupBoxSign = new System.Windows.Forms.GroupBox();
            this.textBoxSign = new System.Windows.Forms.TextBox();
            this.groupBoxUrl = new System.Windows.Forms.GroupBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.groupBoxMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonMethodGet = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodPost = new System.Windows.Forms.RadioButton();
            this.groupBoxRemoteSettings.SuspendLayout();
            this.groupBoxSign.SuspendLayout();
            this.groupBoxUrl.SuspendLayout();
            this.groupBoxMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxEnablePing
            // 
            this.checkBoxEnablePing.AutoSize = true;
            this.checkBoxEnablePing.Location = new System.Drawing.Point(12, 12);
            this.checkBoxEnablePing.Name = "checkBoxEnablePing";
            this.checkBoxEnablePing.Size = new System.Drawing.Size(153, 17);
            this.checkBoxEnablePing.TabIndex = 0;
            this.checkBoxEnablePing.Text = "enable remote server pings";
            this.checkBoxEnablePing.UseVisualStyleBackColor = true;
            this.checkBoxEnablePing.CheckedChanged += new System.EventHandler(this.checkBoxEnablePing_CheckedChanged);
            // 
            // groupBoxRemoteSettings
            // 
            this.groupBoxRemoteSettings.Controls.Add(this.buttonTestPing);
            this.groupBoxRemoteSettings.Controls.Add(this.buttonPlenyxWay);
            this.groupBoxRemoteSettings.Controls.Add(this.groupBoxSign);
            this.groupBoxRemoteSettings.Controls.Add(this.groupBoxUrl);
            this.groupBoxRemoteSettings.Controls.Add(this.groupBoxMethod);
            this.groupBoxRemoteSettings.Enabled = false;
            this.groupBoxRemoteSettings.Location = new System.Drawing.Point(12, 35);
            this.groupBoxRemoteSettings.Name = "groupBoxRemoteSettings";
            this.groupBoxRemoteSettings.Size = new System.Drawing.Size(404, 187);
            this.groupBoxRemoteSettings.TabIndex = 1;
            this.groupBoxRemoteSettings.TabStop = false;
            this.groupBoxRemoteSettings.Text = "Remote server settings";
            // 
            // buttonTestPing
            // 
            this.buttonTestPing.Location = new System.Drawing.Point(6, 156);
            this.buttonTestPing.Name = "buttonTestPing";
            this.buttonTestPing.Size = new System.Drawing.Size(122, 24);
            this.buttonTestPing.TabIndex = 7;
            this.buttonTestPing.Text = "Test Ping";
            this.buttonTestPing.UseVisualStyleBackColor = true;
            this.buttonTestPing.Click += new System.EventHandler(this.buttonTestPing_Click);
            // 
            // buttonPlenyxWay
            // 
            this.buttonPlenyxWay.Location = new System.Drawing.Point(6, 126);
            this.buttonPlenyxWay.Name = "buttonPlenyxWay";
            this.buttonPlenyxWay.Size = new System.Drawing.Size(122, 24);
            this.buttonPlenyxWay.TabIndex = 6;
            this.buttonPlenyxWay.Text = "Use Plenyx\'s server";
            this.buttonPlenyxWay.UseVisualStyleBackColor = true;
            this.buttonPlenyxWay.Click += new System.EventHandler(this.buttonPlenyxWay_Click);
            // 
            // groupBoxSign
            // 
            this.groupBoxSign.Controls.Add(this.textBoxSign);
            this.groupBoxSign.Location = new System.Drawing.Point(7, 70);
            this.groupBoxSign.Name = "groupBoxSign";
            this.groupBoxSign.Size = new System.Drawing.Size(121, 50);
            this.groupBoxSign.TabIndex = 5;
            this.groupBoxSign.TabStop = false;
            this.groupBoxSign.Text = "Sign";
            // 
            // textBoxSign
            // 
            this.textBoxSign.Location = new System.Drawing.Point(7, 20);
            this.textBoxSign.MaxLength = 50;
            this.textBoxSign.Name = "textBoxSign";
            this.textBoxSign.Size = new System.Drawing.Size(105, 20);
            this.textBoxSign.TabIndex = 0;
            this.textBoxSign.UseSystemPasswordChar = true;
            // 
            // groupBoxUrl
            // 
            this.groupBoxUrl.Controls.Add(this.textBoxURL);
            this.groupBoxUrl.Location = new System.Drawing.Point(134, 19);
            this.groupBoxUrl.Name = "groupBoxUrl";
            this.groupBoxUrl.Size = new System.Drawing.Size(262, 161);
            this.groupBoxUrl.TabIndex = 4;
            this.groupBoxUrl.TabStop = false;
            this.groupBoxUrl.Text = "URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(6, 19);
            this.textBoxURL.Multiline = true;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(250, 135);
            this.textBoxURL.TabIndex = 3;
            // 
            // groupBoxMethod
            // 
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodGet);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodPost);
            this.groupBoxMethod.Location = new System.Drawing.Point(6, 19);
            this.groupBoxMethod.Name = "groupBoxMethod";
            this.groupBoxMethod.Size = new System.Drawing.Size(122, 44);
            this.groupBoxMethod.TabIndex = 2;
            this.groupBoxMethod.TabStop = false;
            this.groupBoxMethod.Text = "Method";
            // 
            // radioButtonMethodGet
            // 
            this.radioButtonMethodGet.AutoSize = true;
            this.radioButtonMethodGet.Checked = true;
            this.radioButtonMethodGet.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMethodGet.Name = "radioButtonMethodGet";
            this.radioButtonMethodGet.Size = new System.Drawing.Size(47, 17);
            this.radioButtonMethodGet.TabIndex = 0;
            this.radioButtonMethodGet.TabStop = true;
            this.radioButtonMethodGet.Text = "GET";
            this.radioButtonMethodGet.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodPost
            // 
            this.radioButtonMethodPost.AutoSize = true;
            this.radioButtonMethodPost.Location = new System.Drawing.Point(59, 19);
            this.radioButtonMethodPost.Name = "radioButtonMethodPost";
            this.radioButtonMethodPost.Size = new System.Drawing.Size(54, 17);
            this.radioButtonMethodPost.TabIndex = 1;
            this.radioButtonMethodPost.Text = "POST";
            this.radioButtonMethodPost.UseVisualStyleBackColor = true;
            // 
            // FormPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 231);
            this.Controls.Add(this.groupBoxRemoteSettings);
            this.Controls.Add(this.checkBoxEnablePing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote ping settings";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormPing_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPing_FormClosing);
            this.groupBoxRemoteSettings.ResumeLayout(false);
            this.groupBoxSign.ResumeLayout(false);
            this.groupBoxSign.PerformLayout();
            this.groupBoxUrl.ResumeLayout(false);
            this.groupBoxUrl.PerformLayout();
            this.groupBoxMethod.ResumeLayout(false);
            this.groupBoxMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBoxEnablePing;
        private System.Windows.Forms.GroupBox groupBoxRemoteSettings;
        private System.Windows.Forms.GroupBox groupBoxMethod;
        public System.Windows.Forms.RadioButton radioButtonMethodGet;
        public System.Windows.Forms.RadioButton radioButtonMethodPost;
        private System.Windows.Forms.GroupBox groupBoxUrl;
        public System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.GroupBox groupBoxSign;
        public System.Windows.Forms.TextBox textBoxSign;
        private System.Windows.Forms.Button buttonPlenyxWay;
        private System.Windows.Forms.Button buttonTestPing;
    }
}