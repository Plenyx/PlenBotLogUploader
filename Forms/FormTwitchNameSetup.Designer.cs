namespace PlenBotLogUploader
{
    partial class FormTwitchNameSetup
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
            this.textBoxChannelUrl = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonDoNotUseTwitch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxChannelUrl
            // 
            this.textBoxChannelUrl.Location = new System.Drawing.Point(15, 25);
            this.textBoxChannelUrl.Name = "textBoxChannelUrl";
            this.textBoxChannelUrl.Size = new System.Drawing.Size(311, 20);
            this.textBoxChannelUrl.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfo.Location = new System.Drawing.Point(12, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(226, 13);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Enter link to your Twitch channel or username:";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(218, 67);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(108, 23);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Connect to Twitch";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // buttonDoNotUseTwitch
            // 
            this.buttonDoNotUseTwitch.Location = new System.Drawing.Point(15, 67);
            this.buttonDoNotUseTwitch.Name = "buttonDoNotUseTwitch";
            this.buttonDoNotUseTwitch.Size = new System.Drawing.Size(197, 23);
            this.buttonDoNotUseTwitch.TabIndex = 4;
            this.buttonDoNotUseTwitch.Text = "I don\'t want to use Twitch to post logs";
            this.buttonDoNotUseTwitch.UseVisualStyleBackColor = true;
            this.buttonDoNotUseTwitch.Click += new System.EventHandler(this.ButtonDoNotUseTwitch_Click);
            // 
            // FormTwitchNameSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 102);
            this.Controls.Add(this.buttonDoNotUseTwitch);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxChannelUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTwitchNameSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch channel setup";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTwitchNameSetup_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonNext;
        internal System.Windows.Forms.TextBox textBoxChannelUrl;
        private System.Windows.Forms.Button buttonDoNotUseTwitch;
    }
}