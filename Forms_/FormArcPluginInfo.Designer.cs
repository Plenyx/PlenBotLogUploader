namespace PlenBotLogUploader
{
    partial class FormArcPluginInfo
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
            this.labelPluginInfo = new System.Windows.Forms.Label();
            this.linkLabelPluginLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelPluginInfo
            // 
            this.labelPluginInfo.Location = new System.Drawing.Point(16, 14);
            this.labelPluginInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPluginInfo.Name = "labelPluginInfo";
            this.labelPluginInfo.Size = new System.Drawing.Size(503, 345);
            this.labelPluginInfo.TabIndex = 0;
            // 
            // linkLabelPluginLink
            // 
            this.linkLabelPluginLink.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabelPluginLink.Location = new System.Drawing.Point(16, 372);
            this.linkLabelPluginLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelPluginLink.Name = "linkLabelPluginLink";
            this.linkLabelPluginLink.Size = new System.Drawing.Size(503, 35);
            this.linkLabelPluginLink.TabIndex = 1;
            this.linkLabelPluginLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelPluginLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelPluginLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelPluginLink_LinkClicked);
            // 
            // FormArcPluginInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 422);
            this.Controls.Add(this.linkLabelPluginLink);
            this.Controls.Add(this.labelPluginInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArcPluginInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormArcPluginInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPluginInfo;
        private System.Windows.Forms.LinkLabel linkLabelPluginLink;
    }
}