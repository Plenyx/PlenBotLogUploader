namespace PlenBotLogUploader
{
    partial class FormEditGw2Api
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
            components = new System.ComponentModel.Container();
            groupBoxAPIKeyName = new System.Windows.Forms.GroupBox();
            buttonGetNameFromKey = new System.Windows.Forms.Button();
            textBoxAPIKeyName = new System.Windows.Forms.TextBox();
            textBoxAPIKeyKey = new System.Windows.Forms.TextBox();
            groupBoxAPIKeyKey = new System.Windows.Forms.GroupBox();
            labelIsTokenValid = new System.Windows.Forms.Label();
            timerCheckToken = new System.Windows.Forms.Timer(components);
            groupBoxAPIKeyName.SuspendLayout();
            groupBoxAPIKeyKey.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxAPIKeyName
            // 
            groupBoxAPIKeyName.Controls.Add(buttonGetNameFromKey);
            groupBoxAPIKeyName.Controls.Add(textBoxAPIKeyName);
            groupBoxAPIKeyName.Location = new System.Drawing.Point(12, 15);
            groupBoxAPIKeyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxAPIKeyName.Name = "groupBoxAPIKeyName";
            groupBoxAPIKeyName.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxAPIKeyName.Size = new System.Drawing.Size(857, 66);
            groupBoxAPIKeyName.TabIndex = 1;
            groupBoxAPIKeyName.TabStop = false;
            groupBoxAPIKeyName.Text = "API key name";
            // 
            // buttonGetNameFromKey
            // 
            buttonGetNameFromKey.Location = new System.Drawing.Point(627, 16);
            buttonGetNameFromKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonGetNameFromKey.Name = "buttonGetNameFromKey";
            buttonGetNameFromKey.Size = new System.Drawing.Size(224, 42);
            buttonGetNameFromKey.TabIndex = 3;
            buttonGetNameFromKey.Text = "Get the name from the API key";
            buttonGetNameFromKey.UseVisualStyleBackColor = true;
            buttonGetNameFromKey.Click += ButtonGetNameFromKey_Click;
            // 
            // textBoxAPIKeyName
            // 
            textBoxAPIKeyName.Location = new System.Drawing.Point(6, 26);
            textBoxAPIKeyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxAPIKeyName.Name = "textBoxAPIKeyName";
            textBoxAPIKeyName.Size = new System.Drawing.Size(615, 27);
            textBoxAPIKeyName.TabIndex = 3;
            // 
            // textBoxAPIKeyKey
            // 
            textBoxAPIKeyKey.Location = new System.Drawing.Point(6, 26);
            textBoxAPIKeyKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxAPIKeyKey.Name = "textBoxAPIKeyKey";
            textBoxAPIKeyKey.Size = new System.Drawing.Size(845, 27);
            textBoxAPIKeyKey.TabIndex = 0;
            textBoxAPIKeyKey.TextChanged += TextBoxAPIKeyKey_TextChanged;
            // 
            // groupBoxAPIKeyKey
            // 
            groupBoxAPIKeyKey.Controls.Add(textBoxAPIKeyKey);
            groupBoxAPIKeyKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            groupBoxAPIKeyKey.Location = new System.Drawing.Point(12, 89);
            groupBoxAPIKeyKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxAPIKeyKey.Name = "groupBoxAPIKeyKey";
            groupBoxAPIKeyKey.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxAPIKeyKey.Size = new System.Drawing.Size(857, 65);
            groupBoxAPIKeyKey.TabIndex = 2;
            groupBoxAPIKeyKey.TabStop = false;
            groupBoxAPIKeyKey.Text = "API key";
            // 
            // labelIsTokenValid
            // 
            labelIsTokenValid.Location = new System.Drawing.Point(12, 158);
            labelIsTokenValid.Name = "labelIsTokenValid";
            labelIsTokenValid.Size = new System.Drawing.Size(857, 29);
            labelIsTokenValid.TabIndex = 3;
            labelIsTokenValid.Text = "Waiting for the token input...";
            // 
            // timerCheckToken
            // 
            timerCheckToken.Interval = 500;
            timerCheckToken.Tick += TimerCheckToken_Tick;
            // 
            // FormEditGw2Api
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(883, 195);
            Controls.Add(labelIsTokenValid);
            Controls.Add(groupBoxAPIKeyKey);
            Controls.Add(groupBoxAPIKeyName);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditGw2Api";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormEditGW2API";
            FormClosing += FormEditGW2API_FormClosing;
            groupBoxAPIKeyName.ResumeLayout(false);
            groupBoxAPIKeyName.PerformLayout();
            groupBoxAPIKeyKey.ResumeLayout(false);
            groupBoxAPIKeyKey.PerformLayout();
            ResumeLayout(false);
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