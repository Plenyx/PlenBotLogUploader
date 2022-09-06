namespace PlenBotLogUploader
{
    partial class FormBossData
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
            this.listViewBosses = new System.Windows.Forms.ListView();
            this.contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditBoss = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteBoss = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.buttonResetSettings = new System.Windows.Forms.Button();
            this.labelInformation = new System.Windows.Forms.Label();
            this.buttonOpenTemplate = new System.Windows.Forms.Button();
            this.contextMenuStripInteract.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewBosses
            // 
            this.listViewBosses.ContextMenuStrip = this.contextMenuStripInteract;
            this.listViewBosses.HideSelection = false;
            this.listViewBosses.Location = new System.Drawing.Point(16, 15);
            this.listViewBosses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewBosses.MultiSelect = false;
            this.listViewBosses.Name = "listViewBosses";
            this.listViewBosses.ShowGroups = false;
            this.listViewBosses.Size = new System.Drawing.Size(1009, 388);
            this.listViewBosses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewBosses.TabIndex = 0;
            this.listViewBosses.UseCompatibleStateImageBehavior = false;
            this.listViewBosses.View = System.Windows.Forms.View.Tile;
            this.listViewBosses.DoubleClick += new System.EventHandler(this.ListViewBosses_DoubleClick);
            // 
            // contextMenuStripInteract
            // 
            this.contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditBoss,
            this.toolStripMenuItemDeleteBoss,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemAddNew});
            this.contextMenuStripInteract.Name = "contextMenuStripInteract";
            this.contextMenuStripInteract.Size = new System.Drawing.Size(241, 110);
            this.contextMenuStripInteract.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripInteract_Opening);
            // 
            // toolStripMenuItemEditBoss
            // 
            this.toolStripMenuItemEditBoss.Name = "toolStripMenuItemEditBoss";
            this.toolStripMenuItemEditBoss.Size = new System.Drawing.Size(240, 24);
            this.toolStripMenuItemEditBoss.Text = "Edit the selected boss";
            this.toolStripMenuItemEditBoss.Click += new System.EventHandler(this.ToolStripMenuItemEditBoss_Click);
            // 
            // toolStripMenuItemDeleteBoss
            // 
            this.toolStripMenuItemDeleteBoss.Name = "toolStripMenuItemDeleteBoss";
            this.toolStripMenuItemDeleteBoss.Size = new System.Drawing.Size(240, 24);
            this.toolStripMenuItemDeleteBoss.Text = "Delete the selected boss";
            this.toolStripMenuItemDeleteBoss.Click += new System.EventHandler(this.ToolStripMenuItemDeleteBoss_Click);
            // 
            // toolStripSeparatorOne
            // 
            this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            this.toolStripSeparatorOne.Size = new System.Drawing.Size(237, 6);
            // 
            // toolStripMenuItemAddNew
            // 
            this.toolStripMenuItemAddNew.Name = "toolStripMenuItemAddNew";
            this.toolStripMenuItemAddNew.Size = new System.Drawing.Size(240, 24);
            this.toolStripMenuItemAddNew.Text = "Add a new boss";
            this.toolStripMenuItemAddNew.Click += new System.EventHandler(this.ToolStripMenuItemAddNew_Click);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(897, 418);
            this.buttonAddNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(128, 28);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add a new boss";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.ButtonAddNew_Click);
            // 
            // buttonResetSettings
            // 
            this.buttonResetSettings.Location = new System.Drawing.Point(759, 418);
            this.buttonResetSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonResetSettings.Name = "buttonResetSettings";
            this.buttonResetSettings.Size = new System.Drawing.Size(131, 28);
            this.buttonResetSettings.TabIndex = 2;
            this.buttonResetSettings.Text = "Reset all bosses";
            this.buttonResetSettings.UseVisualStyleBackColor = true;
            this.buttonResetSettings.Click += new System.EventHandler(this.ButtonResetSettings_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(16, 425);
            this.labelInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(356, 16);
            this.labelInformation.TabIndex = 5;
            this.labelInformation.Text = "You can right click the box window to bring up context menu.";
            // 
            // buttonOpenTemplate
            // 
            this.buttonOpenTemplate.Location = new System.Drawing.Point(557, 418);
            this.buttonOpenTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpenTemplate.Name = "buttonOpenTemplate";
            this.buttonOpenTemplate.Size = new System.Drawing.Size(193, 28);
            this.buttonOpenTemplate.TabIndex = 6;
            this.buttonOpenTemplate.Text = "Open boss data templates";
            this.buttonOpenTemplate.UseVisualStyleBackColor = true;
            this.buttonOpenTemplate.Click += new System.EventHandler(this.ButtonOpenTemplate_Click);
            // 
            // FormBossData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1041, 462);
            this.Controls.Add(this.buttonOpenTemplate);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.buttonResetSettings);
            this.Controls.Add(this.buttonAddNew);
            this.Controls.Add(this.listViewBosses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBossData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit boss data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBossData_FormClosing);
            this.contextMenuStripInteract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Button buttonResetSettings;
        public System.Windows.Forms.ListView listViewBosses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteBoss;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddNew;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Button buttonOpenTemplate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditBoss;
    }
}