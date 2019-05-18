namespace PlenBotLogUploader
{
    partial class FormPings
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
            this.contextMenuStripInteract.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewDiscordWebhooks
            // 
            this.listViewDiscordWebhooks.CheckBoxes = true;
            this.listViewDiscordWebhooks.ContextMenuStrip = this.contextMenuStripInteract;
            this.listViewDiscordWebhooks.Location = new System.Drawing.Point(12, 12);
            this.listViewDiscordWebhooks.MultiSelect = false;
            this.listViewDiscordWebhooks.Name = "listViewDiscordWebhooks";
            this.listViewDiscordWebhooks.Size = new System.Drawing.Size(561, 252);
            this.listViewDiscordWebhooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewDiscordWebhooks.TabIndex = 0;
            this.listViewDiscordWebhooks.UseCompatibleStateImageBehavior = false;
            this.listViewDiscordWebhooks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewDiscordWebhooks_ItemChecked);
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
            this.contextMenuStripInteract.Size = new System.Drawing.Size(229, 98);
            this.contextMenuStripInteract.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripInteract_Opening);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemEdit.Text = "Edit selected configuration";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemTest
            // 
            this.toolStripMenuItemTest.Name = "toolStripMenuItemTest";
            this.toolStripMenuItemTest.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemTest.Text = "Test selected configuration";
            this.toolStripMenuItemTest.Click += new System.EventHandler(this.toolStripMenuItemTest_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemDelete.Text = "Delete selected configuration";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemAdd.Text = "Add new ping configuration";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // FormPings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 276);
            this.Controls.Add(this.listViewDiscordWebhooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote server pings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPings_FormClosing);
            this.contextMenuStripInteract.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        public System.Windows.Forms.ListView listViewDiscordWebhooks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTest;
    }
}