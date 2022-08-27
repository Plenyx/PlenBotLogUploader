namespace PlenBotLogUploader
{
    partial class FormEditGW2API
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
            this.groupBoxAPIKeyName = new System.Windows.Forms.GroupBox();
            this.buttonGetNameFromKey = new System.Windows.Forms.Button();
            this.textBoxAPIKeyName = new System.Windows.Forms.TextBox();
            this.textBoxAPIKeyKey = new System.Windows.Forms.TextBox();
            this.groupBoxAPIKeyKey = new System.Windows.Forms.GroupBox();
            this.labelIsTokenValid = new System.Windows.Forms.Label();
            this.timerCheckToken = new System.Windows.Forms.Timer(this.components);
            this.groupBoxAPIKeyName.SuspendLayout();
            this.groupBoxAPIKeyKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAPIKeyName
            // 
            this.groupBoxAPIKeyName.Controls.Add(this.buttonGetNameFromKey);
            this.groupBoxAPIKeyName.Controls.Add(this.textBoxAPIKeyName);
            this.groupBoxAPIKeyName.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAPIKeyName.Name = "groupBoxAPIKeyName";
            this.groupBoxAPIKeyName.Size = new System.Drawing.Size(857, 53);
            this.groupBoxAPIKeyName.TabIndex = 1;
            this.groupBoxAPIKeyName.TabStop = false;
            this.groupBoxAPIKeyName.Text = "API Key name";
            // 
            // buttonGetNameFromKey
            // 
            this.buttonGetNameFromKey.Location = new System.Drawing.Point(678, 13);
            this.buttonGetNameFromKey.Name = "buttonGetNameFromKey";
            this.buttonGetNameFromKey.Size = new System.Drawing.Size(173, 34);
            this.buttonGetNameFromKey.TabIndex = 3;
            this.buttonGetNameFromKey.Text = "Get the name from the key";
            this.buttonGetNameFromKey.UseVisualStyleBackColor = true;
            this.buttonGetNameFromKey.Click += new System.EventHandler(this.ButtonGetNameFromKey_Click);
            // 
            // textBoxAPIKeyName
            // 
            this.textBoxAPIKeyName.Location = new System.Drawing.Point(6, 21);
            this.textBoxAPIKeyName.Name = "textBoxAPIKeyName";
            this.textBoxAPIKeyName.Size = new System.Drawing.Size(666, 22);
            this.textBoxAPIKeyName.TabIndex = 3;
            // 
            // textBoxAPIKeyKey
            // 
            this.textBoxAPIKeyKey.Location = new System.Drawing.Point(6, 21);
            this.textBoxAPIKeyKey.Name = "textBoxAPIKeyKey";
            this.textBoxAPIKeyKey.Size = new System.Drawing.Size(845, 22);
            this.textBoxAPIKeyKey.TabIndex = 0;
            this.textBoxAPIKeyKey.TextChanged += new System.EventHandler(this.TextBoxAPIKeyKey_TextChanged);
            // 
            // groupBoxAPIKeyKey
            // 
            this.groupBoxAPIKeyKey.Controls.Add(this.textBoxAPIKeyKey);
            this.groupBoxAPIKeyKey.Location = new System.Drawing.Point(12, 71);
            this.groupBoxAPIKeyKey.Name = "groupBoxAPIKeyKey";
            this.groupBoxAPIKeyKey.Size = new System.Drawing.Size(857, 52);
            this.groupBoxAPIKeyKey.TabIndex = 2;
            this.groupBoxAPIKeyKey.TabStop = false;
            this.groupBoxAPIKeyKey.Text = "API Key";
            // 
            // labelIsTokenValid
            // 
            this.labelIsTokenValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIsTokenValid.Location = new System.Drawing.Point(12, 126);
            this.labelIsTokenValid.Name = "labelIsTokenValid";
            this.labelIsTokenValid.Size = new System.Drawing.Size(857, 23);
            this.labelIsTokenValid.TabIndex = 3;
            this.labelIsTokenValid.Text = "Waiting for the token input...";
            // 
            // timerCheckToken
            // 
            this.timerCheckToken.Interval = 500;
            this.timerCheckToken.Tick += new System.EventHandler(this.TimerCheckToken_Tick);
            // 
            // FormEditGW2API
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 156);
            this.Controls.Add(this.labelIsTokenValid);
            this.Controls.Add(this.groupBoxAPIKeyKey);
            this.Controls.Add(this.groupBoxAPIKeyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditGW2API";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditGW2API";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditGW2API_FormClosing);
            this.groupBoxAPIKeyName.ResumeLayout(false);
            this.groupBoxAPIKeyName.PerformLayout();
            this.groupBoxAPIKeyKey.ResumeLayout(false);
            this.groupBoxAPIKeyKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAPIKeyName;
        private System.Windows.Forms.TextBox textBoxAPIKeyName;
        private System.Windows.Forms.TextBox textBoxAPIKeyKey;
        private System.Windows.Forms.GroupBox groupBoxAPIKeyKey;
        private System.Windows.Forms.Button buttonGetNameFromKey;
        private System.Windows.Forms.Label labelIsTokenValid;
        private System.Windows.Forms.Timer timerCheckToken;
    }
}