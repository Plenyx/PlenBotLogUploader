namespace PlenBotLogUploader
{
    partial class FormEditPing
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
            groupBoxAuthorization = new System.Windows.Forms.GroupBox();
            radioButtonNoAuthorization = new System.Windows.Forms.RadioButton();
            labelAuthToken = new System.Windows.Forms.Label();
            labelAuthName = new System.Windows.Forms.Label();
            textBoxAuthName = new System.Windows.Forms.TextBox();
            radioButtonUseNormalField = new System.Windows.Forms.RadioButton();
            radioButtonUseAuthField = new System.Windows.Forms.RadioButton();
            textBoxAuthToken = new System.Windows.Forms.TextBox();
            groupBoxUrl = new System.Windows.Forms.GroupBox();
            textBoxURL = new System.Windows.Forms.TextBox();
            groupBoxMethod = new System.Windows.Forms.GroupBox();
            radioButtonMethodPatch = new System.Windows.Forms.RadioButton();
            radioButtonMethodDelete = new System.Windows.Forms.RadioButton();
            radioButtonMethodPut = new System.Windows.Forms.RadioButton();
            radioButtonMethodGet = new System.Windows.Forms.RadioButton();
            radioButtonMethodPost = new System.Windows.Forms.RadioButton();
            groupBoxName = new System.Windows.Forms.GroupBox();
            textBoxName = new System.Windows.Forms.TextBox();
            buttonTestPing = new System.Windows.Forms.Button();
            groupBoxAuthorization.SuspendLayout();
            groupBoxUrl.SuspendLayout();
            groupBoxMethod.SuspendLayout();
            groupBoxName.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxAuthorization
            // 
            groupBoxAuthorization.Controls.Add(radioButtonNoAuthorization);
            groupBoxAuthorization.Controls.Add(labelAuthToken);
            groupBoxAuthorization.Controls.Add(labelAuthName);
            groupBoxAuthorization.Controls.Add(textBoxAuthName);
            groupBoxAuthorization.Controls.Add(radioButtonUseNormalField);
            groupBoxAuthorization.Controls.Add(radioButtonUseAuthField);
            groupBoxAuthorization.Controls.Add(textBoxAuthToken);
            groupBoxAuthorization.Location = new System.Drawing.Point(16, 172);
            groupBoxAuthorization.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxAuthorization.Name = "groupBoxAuthorization";
            groupBoxAuthorization.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxAuthorization.Size = new System.Drawing.Size(376, 168);
            groupBoxAuthorization.TabIndex = 5;
            groupBoxAuthorization.TabStop = false;
            groupBoxAuthorization.Text = "Authorization";
            // 
            // radioButtonNoAuthorization
            // 
            radioButtonNoAuthorization.AutoSize = true;
            radioButtonNoAuthorization.Checked = true;
            radioButtonNoAuthorization.Location = new System.Drawing.Point(201, 52);
            radioButtonNoAuthorization.Name = "radioButtonNoAuthorization";
            radioButtonNoAuthorization.Size = new System.Drawing.Size(144, 24);
            radioButtonNoAuthorization.TabIndex = 6;
            radioButtonNoAuthorization.TabStop = true;
            radioButtonNoAuthorization.Text = "No Authorization";
            radioButtonNoAuthorization.UseVisualStyleBackColor = true;
            radioButtonNoAuthorization.CheckedChanged += RadioButtonNoAuthorization_CheckedChanged;
            // 
            // labelAuthToken
            // 
            labelAuthToken.AutoSize = true;
            labelAuthToken.Location = new System.Drawing.Point(4, 94);
            labelAuthToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAuthToken.Name = "labelAuthToken";
            labelAuthToken.Size = new System.Drawing.Size(84, 20);
            labelAuthToken.TabIndex = 5;
            labelAuthToken.Text = "Auth token:";
            // 
            // labelAuthName
            // 
            labelAuthName.AutoSize = true;
            labelAuthName.Location = new System.Drawing.Point(4, 29);
            labelAuthName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAuthName.Name = "labelAuthName";
            labelAuthName.Size = new System.Drawing.Size(138, 20);
            labelAuthName.TabIndex = 4;
            labelAuthName.Text = "Auth scheme name:";
            // 
            // textBoxAuthName
            // 
            textBoxAuthName.Enabled = false;
            textBoxAuthName.Location = new System.Drawing.Point(8, 54);
            textBoxAuthName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxAuthName.Name = "textBoxAuthName";
            textBoxAuthName.Size = new System.Drawing.Size(184, 27);
            textBoxAuthName.TabIndex = 3;
            // 
            // radioButtonUseNormalField
            // 
            radioButtonUseNormalField.AutoSize = true;
            radioButtonUseNormalField.Location = new System.Drawing.Point(201, 118);
            radioButtonUseNormalField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonUseNormalField.Name = "radioButtonUseNormalField";
            radioButtonUseNormalField.Size = new System.Drawing.Size(118, 24);
            radioButtonUseNormalField.TabIndex = 2;
            radioButtonUseNormalField.Text = "Use as a field";
            radioButtonUseNormalField.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseAuthField
            // 
            radioButtonUseAuthField.AutoSize = true;
            radioButtonUseAuthField.Location = new System.Drawing.Point(201, 84);
            radioButtonUseAuthField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonUseAuthField.Name = "radioButtonUseAuthField";
            radioButtonUseAuthField.Size = new System.Drawing.Size(166, 24);
            radioButtonUseAuthField.TabIndex = 1;
            radioButtonUseAuthField.Text = "Use as Authorization";
            radioButtonUseAuthField.UseVisualStyleBackColor = true;
            // 
            // textBoxAuthToken
            // 
            textBoxAuthToken.Enabled = false;
            textBoxAuthToken.Location = new System.Drawing.Point(8, 118);
            textBoxAuthToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxAuthToken.MaxLength = 50;
            textBoxAuthToken.Name = "textBoxAuthToken";
            textBoxAuthToken.Size = new System.Drawing.Size(184, 27);
            textBoxAuthToken.TabIndex = 0;
            textBoxAuthToken.UseSystemPasswordChar = true;
            // 
            // groupBoxUrl
            // 
            groupBoxUrl.Controls.Add(textBoxURL);
            groupBoxUrl.Location = new System.Drawing.Point(16, 95);
            groupBoxUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxUrl.Name = "groupBoxUrl";
            groupBoxUrl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxUrl.Size = new System.Drawing.Size(639, 68);
            groupBoxUrl.TabIndex = 4;
            groupBoxUrl.TabStop = false;
            groupBoxUrl.Text = "URL";
            // 
            // textBoxURL
            // 
            textBoxURL.Location = new System.Drawing.Point(8, 28);
            textBoxURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new System.Drawing.Size(612, 27);
            textBoxURL.TabIndex = 3;
            // 
            // groupBoxMethod
            // 
            groupBoxMethod.Controls.Add(radioButtonMethodPatch);
            groupBoxMethod.Controls.Add(radioButtonMethodDelete);
            groupBoxMethod.Controls.Add(radioButtonMethodPut);
            groupBoxMethod.Controls.Add(radioButtonMethodGet);
            groupBoxMethod.Controls.Add(radioButtonMethodPost);
            groupBoxMethod.Location = new System.Drawing.Point(400, 174);
            groupBoxMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxMethod.Name = "groupBoxMethod";
            groupBoxMethod.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxMethod.Size = new System.Drawing.Size(236, 106);
            groupBoxMethod.TabIndex = 2;
            groupBoxMethod.TabStop = false;
            groupBoxMethod.Text = "HTTP method";
            // 
            // radioButtonMethodPatch
            // 
            radioButtonMethodPatch.AutoSize = true;
            radioButtonMethodPatch.Location = new System.Drawing.Point(81, 63);
            radioButtonMethodPatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonMethodPatch.Name = "radioButtonMethodPatch";
            radioButtonMethodPatch.Size = new System.Drawing.Size(73, 24);
            radioButtonMethodPatch.TabIndex = 4;
            radioButtonMethodPatch.Text = "PATCH";
            radioButtonMethodPatch.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodDelete
            // 
            radioButtonMethodDelete.AutoSize = true;
            radioButtonMethodDelete.Location = new System.Drawing.Point(81, 30);
            radioButtonMethodDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonMethodDelete.Name = "radioButtonMethodDelete";
            radioButtonMethodDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            radioButtonMethodDelete.Size = new System.Drawing.Size(80, 24);
            radioButtonMethodDelete.TabIndex = 3;
            radioButtonMethodDelete.Text = "DELETE";
            radioButtonMethodDelete.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodPut
            // 
            radioButtonMethodPut.AutoSize = true;
            radioButtonMethodPut.Location = new System.Drawing.Point(162, 63);
            radioButtonMethodPut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonMethodPut.Name = "radioButtonMethodPut";
            radioButtonMethodPut.Size = new System.Drawing.Size(56, 24);
            radioButtonMethodPut.TabIndex = 2;
            radioButtonMethodPut.Text = "PUT";
            radioButtonMethodPut.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodGet
            // 
            radioButtonMethodGet.AutoSize = true;
            radioButtonMethodGet.Location = new System.Drawing.Point(8, 29);
            radioButtonMethodGet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonMethodGet.Name = "radioButtonMethodGet";
            radioButtonMethodGet.Size = new System.Drawing.Size(56, 24);
            radioButtonMethodGet.TabIndex = 0;
            radioButtonMethodGet.Text = "GET";
            radioButtonMethodGet.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodPost
            // 
            radioButtonMethodPost.AutoSize = true;
            radioButtonMethodPost.Checked = true;
            radioButtonMethodPost.Location = new System.Drawing.Point(8, 63);
            radioButtonMethodPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonMethodPost.Name = "radioButtonMethodPost";
            radioButtonMethodPost.Size = new System.Drawing.Size(65, 24);
            radioButtonMethodPost.TabIndex = 1;
            radioButtonMethodPost.TabStop = true;
            radioButtonMethodPost.Text = "POST";
            radioButtonMethodPost.UseVisualStyleBackColor = true;
            // 
            // groupBoxName
            // 
            groupBoxName.Controls.Add(textBoxName);
            groupBoxName.Location = new System.Drawing.Point(16, 18);
            groupBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxName.Name = "groupBoxName";
            groupBoxName.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxName.Size = new System.Drawing.Size(639, 68);
            groupBoxName.TabIndex = 9;
            groupBoxName.TabStop = false;
            groupBoxName.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(8, 25);
            textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(612, 27);
            textBoxName.TabIndex = 0;
            // 
            // buttonTestPing
            // 
            buttonTestPing.Location = new System.Drawing.Point(571, 305);
            buttonTestPing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonTestPing.Name = "buttonTestPing";
            buttonTestPing.Size = new System.Drawing.Size(84, 35);
            buttonTestPing.TabIndex = 10;
            buttonTestPing.Text = "Test Ping";
            buttonTestPing.UseVisualStyleBackColor = true;
            buttonTestPing.Click += ButtonTestPing_Click;
            // 
            // FormEditPing
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(669, 354);
            Controls.Add(buttonTestPing);
            Controls.Add(groupBoxName);
            Controls.Add(groupBoxAuthorization);
            Controls.Add(groupBoxMethod);
            Controls.Add(groupBoxUrl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditPing";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit remote ping settings";
            FormClosing += FormPing_FormClosing;
            groupBoxAuthorization.ResumeLayout(false);
            groupBoxAuthorization.PerformLayout();
            groupBoxUrl.ResumeLayout(false);
            groupBoxUrl.PerformLayout();
            groupBoxMethod.ResumeLayout(false);
            groupBoxMethod.PerformLayout();
            groupBoxName.ResumeLayout(false);
            groupBoxName.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxMethod;
        private System.Windows.Forms.GroupBox groupBoxUrl;
        private System.Windows.Forms.GroupBox groupBoxAuthorization;
        private System.Windows.Forms.RadioButton radioButtonUseNormalField;
        private System.Windows.Forms.RadioButton radioButtonUseAuthField;
        private System.Windows.Forms.RadioButton radioButtonMethodDelete;
        private System.Windows.Forms.RadioButton radioButtonMethodPut;
        private System.Windows.Forms.RadioButton radioButtonMethodGet;
        private System.Windows.Forms.RadioButton radioButtonMethodPost;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxAuthToken;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelAuthToken;
        private System.Windows.Forms.Label labelAuthName;
        private System.Windows.Forms.TextBox textBoxAuthName;
        private System.Windows.Forms.Button buttonTestPing;
        private System.Windows.Forms.RadioButton radioButtonNoAuthorization;
        private System.Windows.Forms.RadioButton radioButtonMethodPatch;
    }
}