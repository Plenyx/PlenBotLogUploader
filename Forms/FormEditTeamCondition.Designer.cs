namespace PlenBotLogUploader
{
    partial class FormEditTeamCondition
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
            groupBoxConditionVisual = new System.Windows.Forms.GroupBox();
            textBoxConditionVisual = new System.Windows.Forms.TextBox();
            groupBoxConditionDefinition = new System.Windows.Forms.GroupBox();
            groupBoxSubConditions = new System.Windows.Forms.GroupBox();
            buttonAddSubCondition = new System.Windows.Forms.Button();
            listBoxSubConditions = new System.Windows.Forms.ListBox();
            contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            groupBoxLimiter = new System.Windows.Forms.GroupBox();
            radioButtonLimiterNOT = new System.Windows.Forms.RadioButton();
            radioButtonLimiterOR = new System.Windows.Forms.RadioButton();
            radioButtonLimiterAND = new System.Windows.Forms.RadioButton();
            radioButtonLimiterCommanderName = new System.Windows.Forms.RadioButton();
            radioButtonLimiterExact = new System.Windows.Forms.RadioButton();
            textBoxLimiterValue = new System.Windows.Forms.TextBox();
            radioButtonLimiterAtLeast = new System.Windows.Forms.RadioButton();
            groupBoxAccountNames = new System.Windows.Forms.GroupBox();
            textBoxAccountNames = new System.Windows.Forms.TextBox();
            groupBoxConditionDescription = new System.Windows.Forms.GroupBox();
            textBoxConditionDescription = new System.Windows.Forms.TextBox();
            groupBoxConditionVisual.SuspendLayout();
            groupBoxConditionDefinition.SuspendLayout();
            groupBoxSubConditions.SuspendLayout();
            contextMenuStripInteract.SuspendLayout();
            groupBoxLimiter.SuspendLayout();
            groupBoxAccountNames.SuspendLayout();
            groupBoxConditionDescription.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConditionVisual
            // 
            groupBoxConditionVisual.Controls.Add(textBoxConditionVisual);
            groupBoxConditionVisual.Location = new System.Drawing.Point(404, 16);
            groupBoxConditionVisual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxConditionVisual.Name = "groupBoxConditionVisual";
            groupBoxConditionVisual.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxConditionVisual.Size = new System.Drawing.Size(507, 742);
            groupBoxConditionVisual.TabIndex = 8;
            groupBoxConditionVisual.TabStop = false;
            groupBoxConditionVisual.Text = "Visualisation of the conditions";
            // 
            // textBoxConditionVisual
            // 
            textBoxConditionVisual.BackColor = System.Drawing.Color.White;
            textBoxConditionVisual.Location = new System.Drawing.Point(6, 29);
            textBoxConditionVisual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxConditionVisual.MaxLength = 999999;
            textBoxConditionVisual.Multiline = true;
            textBoxConditionVisual.Name = "textBoxConditionVisual";
            textBoxConditionVisual.ReadOnly = true;
            textBoxConditionVisual.Size = new System.Drawing.Size(495, 706);
            textBoxConditionVisual.TabIndex = 5;
            // 
            // groupBoxConditionDefinition
            // 
            groupBoxConditionDefinition.Controls.Add(groupBoxSubConditions);
            groupBoxConditionDefinition.Controls.Add(groupBoxLimiter);
            groupBoxConditionDefinition.Controls.Add(groupBoxAccountNames);
            groupBoxConditionDefinition.Location = new System.Drawing.Point(13, 96);
            groupBoxConditionDefinition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxConditionDefinition.Name = "groupBoxConditionDefinition";
            groupBoxConditionDefinition.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxConditionDefinition.Size = new System.Drawing.Size(384, 662);
            groupBoxConditionDefinition.TabIndex = 7;
            groupBoxConditionDefinition.TabStop = false;
            groupBoxConditionDefinition.Text = "Condition definition";
            // 
            // groupBoxSubConditions
            // 
            groupBoxSubConditions.Controls.Add(buttonAddSubCondition);
            groupBoxSubConditions.Controls.Add(listBoxSubConditions);
            groupBoxSubConditions.Location = new System.Drawing.Point(7, 272);
            groupBoxSubConditions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxSubConditions.Name = "groupBoxSubConditions";
            groupBoxSubConditions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBoxSubConditions.Size = new System.Drawing.Size(368, 382);
            groupBoxSubConditions.TabIndex = 4;
            groupBoxSubConditions.TabStop = false;
            groupBoxSubConditions.Text = "Subconditions";
            // 
            // buttonAddSubCondition
            // 
            buttonAddSubCondition.Location = new System.Drawing.Point(172, 339);
            buttonAddSubCondition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonAddSubCondition.Name = "buttonAddSubCondition";
            buttonAddSubCondition.Size = new System.Drawing.Size(187, 31);
            buttonAddSubCondition.TabIndex = 1;
            buttonAddSubCondition.Text = "Add a new subcondition";
            buttonAddSubCondition.UseVisualStyleBackColor = true;
            buttonAddSubCondition.Click += ButtonAddSubCondition_Click;
            // 
            // listBoxSubConditions
            // 
            listBoxSubConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listBoxSubConditions.ContextMenuStrip = contextMenuStripInteract;
            listBoxSubConditions.FormattingEnabled = true;
            listBoxSubConditions.ItemHeight = 20;
            listBoxSubConditions.Location = new System.Drawing.Point(8, 29);
            listBoxSubConditions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listBoxSubConditions.Name = "listBoxSubConditions";
            listBoxSubConditions.Size = new System.Drawing.Size(351, 300);
            listBoxSubConditions.TabIndex = 0;
            listBoxSubConditions.DoubleClick += ListBoxSubConditions_DoubleClick;
            // 
            // contextMenuStripInteract
            // 
            contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemEdit, toolStripMenuItemDelete, toolStripSeparatorOne, toolStripMenuItemAdd });
            contextMenuStripInteract.Name = "contextMenuStripInteract";
            contextMenuStripInteract.Size = new System.Drawing.Size(297, 82);
            contextMenuStripInteract.Opening += ContextMenuStripInteract_Opening;
            // 
            // toolStripMenuItemEdit
            // 
            toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            toolStripMenuItemEdit.Size = new System.Drawing.Size(296, 24);
            toolStripMenuItemEdit.Text = "Edit the selected subcondition";
            toolStripMenuItemEdit.Click += ToolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new System.Drawing.Size(296, 24);
            toolStripMenuItemDelete.Text = "Delete the selected subcondition";
            toolStripMenuItemDelete.Click += ToolStripMenuItemDelete_Click;
            // 
            // toolStripSeparatorOne
            // 
            toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            toolStripSeparatorOne.Size = new System.Drawing.Size(293, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new System.Drawing.Size(296, 24);
            toolStripMenuItemAdd.Text = "Add a new subcondition";
            toolStripMenuItemAdd.Click += ToolStripMenuItemAdd_Click;
            // 
            // groupBoxLimiter
            // 
            groupBoxLimiter.Controls.Add(radioButtonLimiterNOT);
            groupBoxLimiter.Controls.Add(radioButtonLimiterOR);
            groupBoxLimiter.Controls.Add(radioButtonLimiterAND);
            groupBoxLimiter.Controls.Add(radioButtonLimiterCommanderName);
            groupBoxLimiter.Controls.Add(radioButtonLimiterExact);
            groupBoxLimiter.Controls.Add(textBoxLimiterValue);
            groupBoxLimiter.Controls.Add(radioButtonLimiterAtLeast);
            groupBoxLimiter.Location = new System.Drawing.Point(7, 28);
            groupBoxLimiter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxLimiter.Name = "groupBoxLimiter";
            groupBoxLimiter.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxLimiter.Size = new System.Drawing.Size(369, 236);
            groupBoxLimiter.TabIndex = 1;
            groupBoxLimiter.TabStop = false;
            groupBoxLimiter.Text = "Limiter settings";
            // 
            // radioButtonLimiterNOT
            // 
            radioButtonLimiterNOT.AutoSize = true;
            radioButtonLimiterNOT.Location = new System.Drawing.Point(7, 193);
            radioButtonLimiterNOT.Name = "radioButtonLimiterNOT";
            radioButtonLimiterNOT.Size = new System.Drawing.Size(59, 24);
            radioButtonLimiterNOT.TabIndex = 7;
            radioButtonLimiterNOT.TabStop = true;
            radioButtonLimiterNOT.Text = "NOT";
            radioButtonLimiterNOT.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterOR
            // 
            radioButtonLimiterOR.AutoSize = true;
            radioButtonLimiterOR.Location = new System.Drawing.Point(7, 162);
            radioButtonLimiterOR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radioButtonLimiterOR.Name = "radioButtonLimiterOR";
            radioButtonLimiterOR.Size = new System.Drawing.Size(50, 24);
            radioButtonLimiterOR.TabIndex = 6;
            radioButtonLimiterOR.TabStop = true;
            radioButtonLimiterOR.Text = "OR";
            radioButtonLimiterOR.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterAND
            // 
            radioButtonLimiterAND.AutoSize = true;
            radioButtonLimiterAND.Location = new System.Drawing.Point(7, 130);
            radioButtonLimiterAND.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radioButtonLimiterAND.Name = "radioButtonLimiterAND";
            radioButtonLimiterAND.Size = new System.Drawing.Size(62, 24);
            radioButtonLimiterAND.TabIndex = 5;
            radioButtonLimiterAND.TabStop = true;
            radioButtonLimiterAND.Text = "AND";
            radioButtonLimiterAND.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterCommanderName
            // 
            radioButtonLimiterCommanderName.AutoSize = true;
            radioButtonLimiterCommanderName.Location = new System.Drawing.Point(7, 98);
            radioButtonLimiterCommanderName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radioButtonLimiterCommanderName.Name = "radioButtonLimiterCommanderName";
            radioButtonLimiterCommanderName.Size = new System.Drawing.Size(228, 24);
            radioButtonLimiterCommanderName.TabIndex = 4;
            radioButtonLimiterCommanderName.TabStop = true;
            radioButtonLimiterCommanderName.Text = "Any of the listed commanders";
            radioButtonLimiterCommanderName.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterExact
            // 
            radioButtonLimiterExact.AutoSize = true;
            radioButtonLimiterExact.Location = new System.Drawing.Point(7, 65);
            radioButtonLimiterExact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonLimiterExact.Name = "radioButtonLimiterExact";
            radioButtonLimiterExact.Size = new System.Drawing.Size(140, 24);
            radioButtonLimiterExact.TabIndex = 2;
            radioButtonLimiterExact.TabStop = true;
            radioButtonLimiterExact.Text = "Exactly X players";
            radioButtonLimiterExact.UseVisualStyleBackColor = true;
            // 
            // textBoxLimiterValue
            // 
            textBoxLimiterValue.Location = new System.Drawing.Point(155, 42);
            textBoxLimiterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxLimiterValue.Name = "textBoxLimiterValue";
            textBoxLimiterValue.Size = new System.Drawing.Size(204, 27);
            textBoxLimiterValue.TabIndex = 1;
            textBoxLimiterValue.Text = "1";
            textBoxLimiterValue.TextChanged += TextBoxLimiterValue_TextChanged;
            // 
            // radioButtonLimiterAtLeast
            // 
            radioButtonLimiterAtLeast.AutoSize = true;
            radioButtonLimiterAtLeast.Checked = true;
            radioButtonLimiterAtLeast.Location = new System.Drawing.Point(7, 31);
            radioButtonLimiterAtLeast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioButtonLimiterAtLeast.Name = "radioButtonLimiterAtLeast";
            radioButtonLimiterAtLeast.Size = new System.Drawing.Size(144, 24);
            radioButtonLimiterAtLeast.TabIndex = 0;
            radioButtonLimiterAtLeast.TabStop = true;
            radioButtonLimiterAtLeast.Text = "At least X players";
            radioButtonLimiterAtLeast.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccountNames
            // 
            groupBoxAccountNames.Controls.Add(textBoxAccountNames);
            groupBoxAccountNames.Location = new System.Drawing.Point(7, 273);
            groupBoxAccountNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxAccountNames.Name = "groupBoxAccountNames";
            groupBoxAccountNames.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxAccountNames.Size = new System.Drawing.Size(368, 382);
            groupBoxAccountNames.TabIndex = 3;
            groupBoxAccountNames.TabStop = false;
            groupBoxAccountNames.Text = "Account names (separate by new line)";
            // 
            // textBoxAccountNames
            // 
            textBoxAccountNames.Location = new System.Drawing.Point(8, 29);
            textBoxAccountNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxAccountNames.Multiline = true;
            textBoxAccountNames.Name = "textBoxAccountNames";
            textBoxAccountNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxAccountNames.Size = new System.Drawing.Size(351, 343);
            textBoxAccountNames.TabIndex = 2;
            // 
            // groupBoxConditionDescription
            // 
            groupBoxConditionDescription.Controls.Add(textBoxConditionDescription);
            groupBoxConditionDescription.Location = new System.Drawing.Point(13, 16);
            groupBoxConditionDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxConditionDescription.Name = "groupBoxConditionDescription";
            groupBoxConditionDescription.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxConditionDescription.Size = new System.Drawing.Size(384, 71);
            groupBoxConditionDescription.TabIndex = 9;
            groupBoxConditionDescription.TabStop = false;
            groupBoxConditionDescription.Text = "Condition description";
            // 
            // textBoxConditionDescription
            // 
            textBoxConditionDescription.Location = new System.Drawing.Point(8, 29);
            textBoxConditionDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxConditionDescription.Name = "textBoxConditionDescription";
            textBoxConditionDescription.Size = new System.Drawing.Size(368, 27);
            textBoxConditionDescription.TabIndex = 1;
            textBoxConditionDescription.TextChanged += TextBoxConditionDescription_TextChanged;
            // 
            // FormEditTeamCondition
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(924, 772);
            Controls.Add(groupBoxConditionDescription);
            Controls.Add(groupBoxConditionVisual);
            Controls.Add(groupBoxConditionDefinition);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormEditTeamCondition";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormEditTeamCondition";
            FormClosing += FormEditTeamCondition_FormClosing;
            groupBoxConditionVisual.ResumeLayout(false);
            groupBoxConditionVisual.PerformLayout();
            groupBoxConditionDefinition.ResumeLayout(false);
            groupBoxSubConditions.ResumeLayout(false);
            contextMenuStripInteract.ResumeLayout(false);
            groupBoxLimiter.ResumeLayout(false);
            groupBoxLimiter.PerformLayout();
            groupBoxAccountNames.ResumeLayout(false);
            groupBoxAccountNames.PerformLayout();
            groupBoxConditionDescription.ResumeLayout(false);
            groupBoxConditionDescription.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConditionVisual;
        private System.Windows.Forms.TextBox textBoxConditionVisual;
        private System.Windows.Forms.GroupBox groupBoxConditionDefinition;
        private System.Windows.Forms.GroupBox groupBoxLimiter;
        private System.Windows.Forms.RadioButton radioButtonLimiterOR;
        private System.Windows.Forms.RadioButton radioButtonLimiterAND;
        private System.Windows.Forms.RadioButton radioButtonLimiterCommanderName;
        private System.Windows.Forms.RadioButton radioButtonLimiterExact;
        private System.Windows.Forms.TextBox textBoxLimiterValue;
        private System.Windows.Forms.RadioButton radioButtonLimiterAtLeast;
        private System.Windows.Forms.GroupBox groupBoxAccountNames;
        private System.Windows.Forms.TextBox textBoxAccountNames;
        private System.Windows.Forms.GroupBox groupBoxConditionDescription;
        private System.Windows.Forms.TextBox textBoxConditionDescription;
        private System.Windows.Forms.GroupBox groupBoxSubConditions;
        private System.Windows.Forms.Button buttonAddSubCondition;
        private System.Windows.Forms.ListBox listBoxSubConditions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.RadioButton radioButtonLimiterNOT;
    }
}