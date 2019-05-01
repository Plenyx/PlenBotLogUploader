namespace PlenBotLogUploader
{
    partial class FormTwitchLogMessages
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
            this.listViewBosses = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewBosses
            // 
            this.listViewBosses.Location = new System.Drawing.Point(12, 12);
            this.listViewBosses.MultiSelect = false;
            this.listViewBosses.Name = "listViewBosses";
            this.listViewBosses.ShowGroups = false;
            this.listViewBosses.Size = new System.Drawing.Size(758, 316);
            this.listViewBosses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewBosses.TabIndex = 0;
            this.listViewBosses.UseCompatibleStateImageBehavior = false;
            this.listViewBosses.View = System.Windows.Forms.View.Tile;
            this.listViewBosses.DoubleClick += new System.EventHandler(this.listViewBosses_DoubleClick);
            // 
            // FormTwitchLogMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 340);
            this.Controls.Add(this.listViewBosses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTwitchLogMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Twitch log messages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTwitchLogMessages_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewBosses;
    }
}