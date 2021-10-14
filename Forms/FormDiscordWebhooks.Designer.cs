namespace PlenBotLogUploader
{
    partial class FormDiscordWebhooks
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
            this.listViewDiscordWebhooks = new System.Windows.Forms.ListView();
            this.contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.labelInformation = new System.Windows.Forms.Label();
            this.buttonConfigureTeams = new System.Windows.Forms.Button();
            this.contextMenuStripInteract.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewDiscordWebhooks
            // 
            this.listViewDiscordWebhooks.CheckBoxes = true;
            this.listViewDiscordWebhooks.ContextMenuStrip = this.contextMenuStripInteract;
            this.listViewDiscordWebhooks.HideSelection = false;
            this.listViewDiscordWebhooks.Location = new System.Drawing.Point(12, 12);
            this.listViewDiscordWebhooks.MultiSelect = false;
            this.listViewDiscordWebhooks.Name = "listViewDiscordWebhooks";
            this.listViewDiscordWebhooks.Size = new System.Drawing.Size(561, 252);
            this.listViewDiscordWebhooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewDiscordWebhooks.TabIndex = 0;
            this.listViewDiscordWebhooks.UseCompatibleStateImageBehavior = false;
            this.listViewDiscordWebhooks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewDiscordWebhooks_ItemChecked);
            // 
            // contextMenuStripInteract
            // 
            this.contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemTest,
            this.toolStripMenuItemDelete,
            this.toolStripSeparator1,
            this.toolStripMenuItemAdd});
            this.contextMenuStripInteract.Name = "contextMenuStripInteract";
            this.contextMenuStripInteract.Size = new System.Drawing.Size(206, 98);
            this.contextMenuStripInteract.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripInteract_Opening);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemEdit.Text = "Edit selected webhook";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemTest
            // 
            this.toolStripMenuItemTest.Name = "toolStripMenuItemTest";
            this.toolStripMenuItemTest.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemTest.Text = "Test selected webhook";
            this.toolStripMenuItemTest.Click += new System.EventHandler(this.ToolStripMenuItemTest_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemDelete.Text = "Delete selected webhook";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemAdd.Text = "Add new webhook";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(464, 270);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(109, 23);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add new webhook";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.ButtonAddNew_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(12, 275);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(295, 13);
            this.labelInformation.TabIndex = 2;
            this.labelInformation.Text = "You can right click the box window to bring up context menu.";
            // 
            // buttonConfigureTeams
            // 
            this.buttonConfigureTeams.Location = new System.Drawing.Point(360, 270);
            this.buttonConfigureTeams.Name = "buttonConfigureTeams";
            this.buttonConfigureTeams.Size = new System.Drawing.Size(98, 23);
            this.buttonConfigureTeams.TabIndex = 3;
            this.buttonConfigureTeams.Text = "Configure Teams";
            this.buttonConfigureTeams.UseVisualStyleBackColor = true;
            this.buttonConfigureTeams.Click += new System.EventHandler(this.ButtonConfigureTeams_Click);
            // 
            // FormDiscordWebhooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 301);
            this.Controls.Add(this.buttonConfigureTeams);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.buttonAddNew);
            this.Controls.Add(this.listViewDiscordWebhooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDiscordWebhooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord webhooks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDiscordPings_FormClosing);
            this.contextMenuStripInteract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        public System.Windows.Forms.ListView listViewDiscordWebhooks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTest;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Button buttonConfigureTeams;
    }
}