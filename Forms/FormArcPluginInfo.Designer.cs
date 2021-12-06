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
            this.labelPluginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPluginInfo.Location = new System.Drawing.Point(12, 9);
            this.labelPluginInfo.Name = "labelPluginInfo";
            this.labelPluginInfo.Size = new System.Drawing.Size(377, 224);
            this.labelPluginInfo.TabIndex = 0;
            // 
            // linkLabelPluginLink
            // 
            this.linkLabelPluginLink.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabelPluginLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelPluginLink.Location = new System.Drawing.Point(12, 242);
            this.linkLabelPluginLink.Name = "linkLabelPluginLink";
            this.linkLabelPluginLink.Size = new System.Drawing.Size(377, 23);
            this.linkLabelPluginLink.TabIndex = 1;
            this.linkLabelPluginLink.TabStop = true;
            this.linkLabelPluginLink.Text = "linkLabel";
            this.linkLabelPluginLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelPluginLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelPluginLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelPluginLink_LinkClicked);
            // 
            // FormArcPluginInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 275);
            this.Controls.Add(this.linkLabelPluginLink);
            this.Controls.Add(this.labelPluginInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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