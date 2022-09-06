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
            this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.labelInformation = new System.Windows.Forms.Label();
            this.checkBoxShortenThousands = new System.Windows.Forms.CheckBox();
            this.contextMenuStripInteract.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewDiscordWebhooks
            // 
            this.listViewDiscordWebhooks.CheckBoxes = true;
            this.listViewDiscordWebhooks.ContextMenuStrip = this.contextMenuStripInteract;
            this.listViewDiscordWebhooks.HideSelection = false;
            this.listViewDiscordWebhooks.Location = new System.Drawing.Point(16, 15);
            this.listViewDiscordWebhooks.Margin = new System.Windows.Forms.Padding(4);
            this.listViewDiscordWebhooks.MultiSelect = false;
            this.listViewDiscordWebhooks.Name = "listViewDiscordWebhooks";
            this.listViewDiscordWebhooks.Size = new System.Drawing.Size(747, 309);
            this.listViewDiscordWebhooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewDiscordWebhooks.TabIndex = 0;
            this.listViewDiscordWebhooks.UseCompatibleStateImageBehavior = false;
            this.listViewDiscordWebhooks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewDiscordWebhooks_ItemChecked);
            // 
            // contextMenuStripInteract
            // 
            this.contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemTest,
            this.toolStripMenuItemDelete,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemAdd});
            this.contextMenuStripInteract.Name = "contextMenuStripInteract";
            this.contextMenuStripInteract.Size = new System.Drawing.Size(272, 106);
            this.contextMenuStripInteract.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripInteract_Opening);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemEdit.Text = "Edit the selected webhook";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemTest
            // 
            this.toolStripMenuItemTest.Name = "toolStripMenuItemTest";
            this.toolStripMenuItemTest.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemTest.Text = "Test the selected webhook";
            this.toolStripMenuItemTest.Click += new System.EventHandler(this.ToolStripMenuItemTest_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemDelete.Text = "Delete the selected webhook";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // toolStripSeparatorOne
            // 
            this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            this.toolStripSeparatorOne.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(271, 24);
            this.toolStripMenuItemAdd.Text = "Add a new webhook";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(619, 332);
            this.buttonAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(145, 28);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add a new webhook";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.ButtonAddNew_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(16, 338);
            this.labelInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(356, 16);
            this.labelInformation.TabIndex = 2;
            this.labelInformation.Text = "You can right click the box window to bring up context menu.";
            // 
            // checkBoxShortenThousands
            // 
            this.checkBoxShortenThousands.AutoSize = true;
            this.checkBoxShortenThousands.Location = new System.Drawing.Point(438, 337);
            this.checkBoxShortenThousands.Name = "checkBoxShortenThousands";
            this.checkBoxShortenThousands.Size = new System.Drawing.Size(174, 20);
            this.checkBoxShortenThousands.TabIndex = 3;
            this.checkBoxShortenThousands.Text = "Shorten thousands to \"k\"";
            this.checkBoxShortenThousands.UseVisualStyleBackColor = true;
            // 
            // FormDiscordWebhooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 370);
            this.Controls.Add(this.checkBoxShortenThousands);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.buttonAddNew);
            this.Controls.Add(this.listViewDiscordWebhooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        public System.Windows.Forms.ListView listViewDiscordWebhooks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTest;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Label labelInformation;
        internal System.Windows.Forms.CheckBox checkBoxShortenThousands;
    }
}