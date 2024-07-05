namespace PlenBotLogUploader
{
    partial class FormTwitchCommands
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
            listViewTwitchCommands = new System.Windows.Forms.ListView();
            contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            buttonAddTwitchCommand = new System.Windows.Forms.Button();
            contextMenuStripInteract.SuspendLayout();
            SuspendLayout();
            // 
            // listViewTwitchCommands
            // 
            listViewTwitchCommands.BackColor = System.Drawing.Color.White;
            listViewTwitchCommands.CheckBoxes = true;
            listViewTwitchCommands.ContextMenuStrip = contextMenuStripInteract;
            listViewTwitchCommands.Location = new System.Drawing.Point(12, 12);
            listViewTwitchCommands.MultiSelect = false;
            listViewTwitchCommands.Name = "listViewTwitchCommands";
            listViewTwitchCommands.ShowGroups = false;
            listViewTwitchCommands.Size = new System.Drawing.Size(768, 489);
            listViewTwitchCommands.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listViewTwitchCommands.TabIndex = 0;
            listViewTwitchCommands.UseCompatibleStateImageBehavior = false;
            listViewTwitchCommands.View = System.Windows.Forms.View.List;
            listViewTwitchCommands.ItemChecked += ListViewTwitchCommands_ItemChecked;
            // 
            // contextMenuStripInteract
            // 
            contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemEdit, toolStripMenuItemDelete, toolStripSeparatorOne, toolStripMenuItemAdd });
            contextMenuStripInteract.Name = "contextMenuStripInteract";
            contextMenuStripInteract.Size = new System.Drawing.Size(324, 82);
            contextMenuStripInteract.Opening += ContextMenuStripInteract_Opening;
            // 
            // toolStripMenuItemEdit
            // 
            toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            toolStripMenuItemEdit.Size = new System.Drawing.Size(323, 24);
            toolStripMenuItemEdit.Text = "Edit the selected Twitch command";
            toolStripMenuItemEdit.Click += ToolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new System.Drawing.Size(323, 24);
            toolStripMenuItemDelete.Text = "Delete the selected Twitch command";
            toolStripMenuItemDelete.Click += ToolStripMenuItemDelete_Click;
            // 
            // toolStripSeparatorOne
            // 
            toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            toolStripSeparatorOne.Size = new System.Drawing.Size(320, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new System.Drawing.Size(323, 24);
            toolStripMenuItemAdd.Text = "Add a Twitch command";
            toolStripMenuItemAdd.Click += ToolStripMenuItemAdd_Click;
            // 
            // buttonAddTwitchCommand
            // 
            buttonAddTwitchCommand.Location = new System.Drawing.Point(568, 508);
            buttonAddTwitchCommand.Name = "buttonAddTwitchCommand";
            buttonAddTwitchCommand.Size = new System.Drawing.Size(212, 29);
            buttonAddTwitchCommand.TabIndex = 1;
            buttonAddTwitchCommand.Text = "Add a new Twitch command";
            buttonAddTwitchCommand.UseVisualStyleBackColor = true;
            buttonAddTwitchCommand.Click += ButtonAddTwitchCommand_Click;
            // 
            // FormTwitchCommands
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(792, 549);
            Controls.Add(buttonAddTwitchCommand);
            Controls.Add(listViewTwitchCommands);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTwitchCommands";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Twitch commands";
            FormClosing += FormTwitchCommands_FormClosing;
            contextMenuStripInteract.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.Button buttonAddTwitchCommand;
        internal System.Windows.Forms.ListView listViewTwitchCommands;
    }
}