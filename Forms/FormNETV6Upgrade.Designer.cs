namespace PlenBotLogUploader
{
    partial class FormNETV6Upgrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNETV6Upgrade));
            this.buttonAcknowledge = new System.Windows.Forms.Button();
            this.richTextBoxUpgradeInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonAcknowledge
            // 
            this.buttonAcknowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAcknowledge.Location = new System.Drawing.Point(214, 361);
            this.buttonAcknowledge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAcknowledge.Name = "buttonAcknowledge";
            this.buttonAcknowledge.Size = new System.Drawing.Size(269, 32);
            this.buttonAcknowledge.TabIndex = 0;
            this.buttonAcknowledge.Text = "I have .NET 6.0 installed, update now";
            this.buttonAcknowledge.UseVisualStyleBackColor = true;
            this.buttonAcknowledge.Click += new System.EventHandler(this.ButtonAcknowledge_Click);
            // 
            // richTextBoxUpgradeInfo
            // 
            this.richTextBoxUpgradeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxUpgradeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxUpgradeInfo.Location = new System.Drawing.Point(9, 10);
            this.richTextBoxUpgradeInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxUpgradeInfo.Name = "richTextBoxUpgradeInfo";
            this.richTextBoxUpgradeInfo.Size = new System.Drawing.Size(659, 346);
            this.richTextBoxUpgradeInfo.TabIndex = 1;
            this.richTextBoxUpgradeInfo.Text = resources.GetString("richTextBoxUpgradeInfo.Text");
            this.richTextBoxUpgradeInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBoxUpgradeInfo_LinkClicked);
            // 
            // FormNETV6Upgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 399);
            this.Controls.Add(this.richTextBoxUpgradeInfo);
            this.Controls.Add(this.buttonAcknowledge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNETV6Upgrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlenBotLogUploader .NET 6.0 Upgrade";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAcknowledge;
        private System.Windows.Forms.RichTextBox richTextBoxUpgradeInfo;
    }
}