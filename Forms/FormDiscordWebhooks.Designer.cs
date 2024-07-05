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
            components = new System.ComponentModel.Container();
            listViewDiscordWebhooks = new System.Windows.Forms.ListView();
            contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            buttonAddNew = new System.Windows.Forms.Button();
            labelInformation = new System.Windows.Forms.Label();
            checkBoxShortenThousands = new System.Windows.Forms.CheckBox();
            contextMenuStripInteract.SuspendLayout();
            SuspendLayout();
            // 
            // listViewDiscordWebhooks
            // 
            listViewDiscordWebhooks.CheckBoxes = true;
            listViewDiscordWebhooks.ContextMenuStrip = contextMenuStripInteract;
            listViewDiscordWebhooks.Location = new System.Drawing.Point(16, 19);
            listViewDiscordWebhooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            listViewDiscordWebhooks.MultiSelect = false;
            listViewDiscordWebhooks.Name = "listViewDiscordWebhooks";
            listViewDiscordWebhooks.Size = new System.Drawing.Size(781, 385);
            listViewDiscordWebhooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listViewDiscordWebhooks.TabIndex = 0;
            listViewDiscordWebhooks.UseCompatibleStateImageBehavior = false;
            listViewDiscordWebhooks.View = System.Windows.Forms.View.List;
            listViewDiscordWebhooks.ItemChecked += ListViewDiscordWebhooks_ItemChecked;
            // 
            // contextMenuStripInteract
            // 
            contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemEdit, toolStripMenuItemTest, toolStripMenuItemDelete, toolStripSeparatorOne, toolStripMenuItemAdd });
            contextMenuStripInteract.Name = "contextMenuStripInteract";
            contextMenuStripInteract.Size = new System.Drawing.Size(272, 106);
            contextMenuStripInteract.Opening += ContextMenuStripInteract_Opening;
            // 
            // toolStripMenuItemEdit
            // 
            toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            toolStripMenuItemEdit.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemEdit.Text = "Edit the selected webhook";
            toolStripMenuItemEdit.Click += ToolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemTest
            // 
            toolStripMenuItemTest.Name = "toolStripMenuItemTest";
            toolStripMenuItemTest.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemTest.Text = "Test the selected webhook";
            toolStripMenuItemTest.Click += ToolStripMenuItemTest_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemDelete.Text = "Delete the selected webhook";
            toolStripMenuItemDelete.Click += ToolStripMenuItemDelete_Click;
            // 
            // toolStripSeparatorOne
            // 
            toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            toolStripSeparatorOne.Size = new System.Drawing.Size(268, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new System.Drawing.Size(271, 24);
            toolStripMenuItemAdd.Text = "Add a new webhook";
            toolStripMenuItemAdd.Click += ToolStripMenuItemAdd_Click;
            // 
            // buttonAddNew
            // 
            buttonAddNew.Location = new System.Drawing.Point(639, 415);
            buttonAddNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonAddNew.Name = "buttonAddNew";
            buttonAddNew.Size = new System.Drawing.Size(158, 35);
            buttonAddNew.TabIndex = 1;
            buttonAddNew.Text = "Add a new webhook";
            buttonAddNew.UseVisualStyleBackColor = true;
            buttonAddNew.Click += ButtonAddNew_Click;
            // 
            // labelInformation
            // 
            labelInformation.AutoSize = true;
            labelInformation.Location = new System.Drawing.Point(16, 422);
            labelInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelInformation.Name = "labelInformation";
            labelInformation.Size = new System.Drawing.Size(413, 20);
            labelInformation.TabIndex = 2;
            labelInformation.Text = "You can right click the box window to bring up context menu.";
            // 
            // checkBoxShortenThousands
            // 
            checkBoxShortenThousands.AutoSize = true;
            checkBoxShortenThousands.Location = new System.Drawing.Point(438, 421);
            checkBoxShortenThousands.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBoxShortenThousands.Name = "checkBoxShortenThousands";
            checkBoxShortenThousands.Size = new System.Drawing.Size(194, 24);
            checkBoxShortenThousands.TabIndex = 3;
            checkBoxShortenThousands.Text = "Shorten thousands to \"k\"";
            checkBoxShortenThousands.UseVisualStyleBackColor = true;
            // 
            // FormDiscordWebhooks
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(809, 462);
            Controls.Add(checkBoxShortenThousands);
            Controls.Add(labelInformation);
            Controls.Add(buttonAddNew);
            Controls.Add(listViewDiscordWebhooks);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDiscordWebhooks";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Discord webhooks";
            FormClosing += FormDiscordPings_FormClosing;
            contextMenuStripInteract.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        internal System.Windows.Forms.ListView listViewDiscordWebhooks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTest;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.Label labelInformation;
        internal System.Windows.Forms.CheckBox checkBoxShortenThousands;
    }
}