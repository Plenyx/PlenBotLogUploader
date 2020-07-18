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
            this.groupBoxAPIKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAPIKey
            // 
            this.groupBoxAPIKey.Controls.Add(this.buttonShowAPIKey);
            this.groupBoxAPIKey.Controls.Add(this.textBoxAPIKey);
            this.groupBoxAPIKey.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAPIKey.Name = "groupBoxAPIKey";
            this.groupBoxAPIKey.Size = new System.Drawing.Size(716, 47);
            this.groupBoxAPIKey.TabIndex = 0;
            this.groupBoxAPIKey.TabStop = false;
            this.groupBoxAPIKey.Text = "GW2 API key";
            // 
            // buttonShowAPIKey
            // 
            this.buttonShowAPIKey.Location = new System.Drawing.Point(648, 19);
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
            this.textBoxAPIKey.Size = new System.Drawing.Size(635, 20);
            this.textBoxAPIKey.TabIndex = 2;
            this.textBoxAPIKey.UseSystemPasswordChar = true;
            // 
            // FormGW2API
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 64);
            this.Controls.Add(this.groupBoxAPIKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGW2API";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GW2 API Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGW2API_FormClosing);
            this.groupBoxAPIKey.ResumeLayout(false);
            this.groupBoxAPIKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAPIKey;
        private System.Windows.Forms.Button buttonShowAPIKey;
        public System.Windows.Forms.TextBox textBoxAPIKey;
    }
}