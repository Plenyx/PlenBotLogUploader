namespace PlenBotLogUploader
{
    partial class FormTwitchCommands
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
            this.checkBoxUploaderEnable = new System.Windows.Forms.CheckBox();
            this.checkBoxLastLogEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxUploader = new System.Windows.Forms.GroupBox();
            this.groupBoxLastLog = new System.Windows.Forms.GroupBox();
            this.textBoxUploaderCommand = new System.Windows.Forms.TextBox();
            this.textBoxLastLogCommand = new System.Windows.Forms.TextBox();
            this.groupBoxUploader.SuspendLayout();
            this.groupBoxLastLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxUploaderEnable
            // 
            this.checkBoxUploaderEnable.AutoSize = true;
            this.checkBoxUploaderEnable.Location = new System.Drawing.Point(6, 19);
            this.checkBoxUploaderEnable.Name = "checkBoxUploaderEnable";
            this.checkBoxUploaderEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxUploaderEnable.TabIndex = 0;
            this.checkBoxUploaderEnable.Text = "enable command";
            this.checkBoxUploaderEnable.UseVisualStyleBackColor = true;
            // 
            // checkBoxLastLogEnable
            // 
            this.checkBoxLastLogEnable.AutoSize = true;
            this.checkBoxLastLogEnable.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLastLogEnable.Name = "checkBoxLastLogEnable";
            this.checkBoxLastLogEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxLastLogEnable.TabIndex = 1;
            this.checkBoxLastLogEnable.Text = "enable command";
            this.checkBoxLastLogEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxUploader
            // 
            this.groupBoxUploader.Controls.Add(this.textBoxUploaderCommand);
            this.groupBoxUploader.Controls.Add(this.checkBoxUploaderEnable);
            this.groupBoxUploader.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUploader.Name = "groupBoxUploader";
            this.groupBoxUploader.Size = new System.Drawing.Size(179, 70);
            this.groupBoxUploader.TabIndex = 2;
            this.groupBoxUploader.TabStop = false;
            this.groupBoxUploader.Text = "!uploader";
            // 
            // groupBoxLastLog
            // 
            this.groupBoxLastLog.Controls.Add(this.textBoxLastLogCommand);
            this.groupBoxLastLog.Controls.Add(this.checkBoxLastLogEnable);
            this.groupBoxLastLog.Location = new System.Drawing.Point(12, 88);
            this.groupBoxLastLog.Name = "groupBoxLastLog";
            this.groupBoxLastLog.Size = new System.Drawing.Size(179, 70);
            this.groupBoxLastLog.TabIndex = 3;
            this.groupBoxLastLog.TabStop = false;
            this.groupBoxLastLog.Text = "!lastlog";
            // 
            // textBoxUploaderCommand
            // 
            this.textBoxUploaderCommand.Location = new System.Drawing.Point(7, 43);
            this.textBoxUploaderCommand.Name = "textBoxUploaderCommand";
            this.textBoxUploaderCommand.Size = new System.Drawing.Size(164, 20);
            this.textBoxUploaderCommand.TabIndex = 1;
            // 
            // textBoxLastLogCommand
            // 
            this.textBoxLastLogCommand.Location = new System.Drawing.Point(6, 42);
            this.textBoxLastLogCommand.Name = "textBoxLastLogCommand";
            this.textBoxLastLogCommand.Size = new System.Drawing.Size(165, 20);
            this.textBoxLastLogCommand.TabIndex = 2;
            // 
            // FormTwitchCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 168);
            this.Controls.Add(this.groupBoxLastLog);
            this.Controls.Add(this.groupBoxUploader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTwitchCommands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch commands";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTwitchCommands_FormClosing);
            this.groupBoxUploader.ResumeLayout(false);
            this.groupBoxUploader.PerformLayout();
            this.groupBoxLastLog.ResumeLayout(false);
            this.groupBoxLastLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBoxUploaderEnable;
        public System.Windows.Forms.CheckBox checkBoxLastLogEnable;
        private System.Windows.Forms.GroupBox groupBoxUploader;
        private System.Windows.Forms.GroupBox groupBoxLastLog;
        public System.Windows.Forms.TextBox textBoxUploaderCommand;
        public System.Windows.Forms.TextBox textBoxLastLogCommand;
    }
}