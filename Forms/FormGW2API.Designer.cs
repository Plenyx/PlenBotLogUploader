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
            this.groupBoxAPIKey = new System.Windows.Forms.GroupBox();
            this.buttonShowAPIKey = new System.Windows.Forms.Button();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.labelAPIKeyInfo = new System.Windows.Forms.Label();
            this.groupBoxAPIKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAPIKey
            // 
            this.groupBoxAPIKey.Controls.Add(this.buttonShowAPIKey);
            this.groupBoxAPIKey.Controls.Add(this.textBoxAPIKey);
            this.groupBoxAPIKey.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAPIKey.Name = "groupBoxAPIKey";
            this.groupBoxAPIKey.Size = new System.Drawing.Size(721, 47);
            this.groupBoxAPIKey.TabIndex = 0;
            this.groupBoxAPIKey.TabStop = false;
            this.groupBoxAPIKey.Text = "GW2 API key";
            // 
            // buttonShowAPIKey
            // 
            this.buttonShowAPIKey.Location = new System.Drawing.Point(653, 19);
            this.buttonShowAPIKey.Name = "buttonShowAPIKey";
            this.buttonShowAPIKey.Size = new System.Drawing.Size(62, 20);
            this.buttonShowAPIKey.TabIndex = 3;
            this.buttonShowAPIKey.Text = "Show key";
            this.buttonShowAPIKey.UseVisualStyleBackColor = true;
            this.buttonShowAPIKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonShowAPIKey_MouseDown);
            this.buttonShowAPIKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonShowAPIKey_MouseUp);
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Location = new System.Drawing.Point(7, 19);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(640, 20);
            this.textBoxAPIKey.TabIndex = 2;
            this.textBoxAPIKey.UseSystemPasswordChar = true;
            // 
            // labelAPIKeyInfo
            // 
            this.labelAPIKeyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAPIKeyInfo.Location = new System.Drawing.Point(9, 62);
            this.labelAPIKeyInfo.Name = "labelAPIKeyInfo";
            this.labelAPIKeyInfo.Size = new System.Drawing.Size(733, 18);
            this.labelAPIKeyInfo.TabIndex = 1;
            this.labelAPIKeyInfo.Text = "API key is used with \"!ign\" and \"!build\" Twitch commands, you don\'t need to set i" +
    "t unless you want to use the commands.";
            this.labelAPIKeyInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGW2API
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 88);
            this.Controls.Add(this.labelAPIKeyInfo);
            this.Controls.Add(this.groupBoxAPIKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGW2API";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GW2 API settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGW2API_FormClosing);
            this.groupBoxAPIKey.ResumeLayout(false);
            this.groupBoxAPIKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAPIKey;
        private System.Windows.Forms.Button buttonShowAPIKey;
        public System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Label labelAPIKeyInfo;
    }
}