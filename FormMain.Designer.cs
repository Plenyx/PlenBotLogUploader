namespace PlenBotLogUploader
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxUploadInfo = new System.Windows.Forms.TextBox();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxWepSkill1 = new System.Windows.Forms.CheckBox();
            this.buttonReconnectBot = new System.Windows.Forms.Button();
            this.checkBoxUploadLogs = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonStopChecker = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelLocationInfo = new System.Windows.Forms.Label();
            this.buttonStartChecker = new System.Windows.Forms.Button();
            this.buttonLogsLocation = new System.Windows.Forms.Button();
            this.timerLogsCheck = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUploadInfo
            // 
            this.textBoxUploadInfo.Location = new System.Drawing.Point(12, 12);
            this.textBoxUploadInfo.MaxLength = 9999999;
            this.textBoxUploadInfo.Multiline = true;
            this.textBoxUploadInfo.Name = "textBoxUploadInfo";
            this.textBoxUploadInfo.Size = new System.Drawing.Size(408, 235);
            this.textBoxUploadInfo.TabIndex = 0;
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(6, 19);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(188, 20);
            this.textBoxChannel.TabIndex = 2;
            this.textBoxChannel.TextChanged += new System.EventHandler(this.textBoxChannel_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxWepSkill1);
            this.groupBox1.Controls.Add(this.buttonReconnectBot);
            this.groupBox1.Controls.Add(this.checkBoxUploadLogs);
            this.groupBox1.Controls.Add(this.textBoxChannel);
            this.groupBox1.Location = new System.Drawing.Point(426, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 126);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitch channel";
            // 
            // checkBoxWepSkill1
            // 
            this.checkBoxWepSkill1.AutoSize = true;
            this.checkBoxWepSkill1.Location = new System.Drawing.Point(6, 69);
            this.checkBoxWepSkill1.Name = "checkBoxWepSkill1";
            this.checkBoxWepSkill1.Size = new System.Drawing.Size(126, 17);
            this.checkBoxWepSkill1.TabIndex = 5;
            this.checkBoxWepSkill1.Text = "render weapon skill 1";
            this.checkBoxWepSkill1.UseVisualStyleBackColor = true;
            this.checkBoxWepSkill1.CheckedChanged += new System.EventHandler(this.checkBoxWepSkill1_CheckedChanged);
            // 
            // buttonReconnectBot
            // 
            this.buttonReconnectBot.Location = new System.Drawing.Point(6, 92);
            this.buttonReconnectBot.Name = "buttonReconnectBot";
            this.buttonReconnectBot.Size = new System.Drawing.Size(188, 23);
            this.buttonReconnectBot.TabIndex = 4;
            this.buttonReconnectBot.Text = "Reconnect bot";
            this.buttonReconnectBot.UseVisualStyleBackColor = true;
            this.buttonReconnectBot.Click += new System.EventHandler(this.buttonReconnectBot_Click);
            // 
            // checkBoxUploadLogs
            // 
            this.checkBoxUploadLogs.AutoSize = true;
            this.checkBoxUploadLogs.Location = new System.Drawing.Point(6, 45);
            this.checkBoxUploadLogs.Name = "checkBoxUploadLogs";
            this.checkBoxUploadLogs.Size = new System.Drawing.Size(80, 17);
            this.checkBoxUploadLogs.TabIndex = 3;
            this.checkBoxUploadLogs.Text = "upload logs";
            this.checkBoxUploadLogs.UseVisualStyleBackColor = true;
            this.checkBoxUploadLogs.CheckedChanged += new System.EventHandler(this.checkBoxUploadAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonStopChecker);
            this.groupBox2.Controls.Add(this.buttonRestart);
            this.groupBox2.Controls.Add(this.labelLocationInfo);
            this.groupBox2.Controls.Add(this.buttonStartChecker);
            this.groupBox2.Controls.Add(this.buttonLogsLocation);
            this.groupBox2.Location = new System.Drawing.Point(426, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 103);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs directory and checker";
            // 
            // buttonStopChecker
            // 
            this.buttonStopChecker.Enabled = false;
            this.buttonStopChecker.Location = new System.Drawing.Point(72, 74);
            this.buttonStopChecker.Name = "buttonStopChecker";
            this.buttonStopChecker.Size = new System.Drawing.Size(57, 23);
            this.buttonStopChecker.TabIndex = 4;
            this.buttonStopChecker.Text = "Stop";
            this.buttonStopChecker.UseVisualStyleBackColor = true;
            this.buttonStopChecker.Click += new System.EventHandler(this.buttonStopChecker_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(138, 74);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(57, 23);
            this.buttonRestart.TabIndex = 2;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // labelLocationInfo
            // 
            this.labelLocationInfo.Location = new System.Drawing.Point(6, 45);
            this.labelLocationInfo.Name = "labelLocationInfo";
            this.labelLocationInfo.Size = new System.Drawing.Size(188, 23);
            this.labelLocationInfo.TabIndex = 1;
            this.labelLocationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStartChecker
            // 
            this.buttonStartChecker.Location = new System.Drawing.Point(6, 74);
            this.buttonStartChecker.Name = "buttonStartChecker";
            this.buttonStartChecker.Size = new System.Drawing.Size(57, 23);
            this.buttonStartChecker.TabIndex = 3;
            this.buttonStartChecker.Text = "Start";
            this.buttonStartChecker.UseVisualStyleBackColor = true;
            this.buttonStartChecker.Click += new System.EventHandler(this.buttonStartChecker_Click);
            // 
            // buttonLogsLocation
            // 
            this.buttonLogsLocation.Location = new System.Drawing.Point(6, 19);
            this.buttonLogsLocation.Name = "buttonLogsLocation";
            this.buttonLogsLocation.Size = new System.Drawing.Size(188, 23);
            this.buttonLogsLocation.TabIndex = 0;
            this.buttonLogsLocation.Text = "Change logs directory";
            this.buttonLogsLocation.UseVisualStyleBackColor = true;
            this.buttonLogsLocation.Click += new System.EventHandler(this.buttonLogsLocation_Click);
            // 
            // timerLogsCheck
            // 
            this.timerLogsCheck.Interval = 60000;
            this.timerLogsCheck.Tick += new System.EventHandler(this.timerLogsCheck_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 253);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxUploadInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlenBot Log Uploader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxUploadInfo;
        private System.Windows.Forms.TextBox textBoxChannel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxUploadLogs;
        private System.Windows.Forms.Button buttonReconnectBot;
        private System.Windows.Forms.CheckBox checkBoxWepSkill1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLogsLocation;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelLocationInfo;
        private System.Windows.Forms.Timer timerLogsCheck;
        private System.Windows.Forms.Button buttonStopChecker;
        private System.Windows.Forms.Button buttonStartChecker;
    }
}

