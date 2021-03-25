namespace project
{
    partial class ProfileEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileEditView));
            this.LabelStudentName = new System.Windows.Forms.Label();
            this.LabelCompany = new System.Windows.Forms.Label();
            this.LabelGroups = new System.Windows.Forms.Label();
            this.SearchResults = new System.Windows.Forms.ListBox();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ButtonEditInfo = new System.Windows.Forms.Button();
            this.ButtonAddNote = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonDeleteNote = new System.Windows.Forms.Button();
            this.LabelStudentNo = new System.Windows.Forms.Label();
            this.ComboBoxContext = new System.Windows.Forms.ComboBox();
            this.ButtonEditNote = new System.Windows.Forms.Button();
            this.LabelYearGroup = new System.Windows.Forms.Label();
            this.LabelStruggling = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ComboBoxBack = new System.Windows.Forms.Panel();
            this.ContextMenuInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StudentPhoto = new System.Windows.Forms.PictureBox();
            this.ImageBoxPlaceholder = new System.Windows.Forms.PictureBox();
            this.ImageFlag = new System.Windows.Forms.PictureBox();
            this.ContextMenuNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboBoxBack.SuspendLayout();
            this.ContextMenuInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxPlaceholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageFlag)).BeginInit();
            this.ContextMenuNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelStudentName
            // 
            this.LabelStudentName.AutoSize = true;
            this.LabelStudentName.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelStudentName.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentName.Location = new System.Drawing.Point(131, 12);
            this.LabelStudentName.Name = "LabelStudentName";
            this.LabelStudentName.Size = new System.Drawing.Size(177, 32);
            this.LabelStudentName.TabIndex = 1;
            this.LabelStudentName.Text = "Student Name";
            this.LabelStudentName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelStudentName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // LabelCompany
            // 
            this.LabelCompany.AutoSize = true;
            this.LabelCompany.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelCompany.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCompany.Location = new System.Drawing.Point(132, 94);
            this.LabelCompany.Name = "LabelCompany";
            this.LabelCompany.Size = new System.Drawing.Size(97, 25);
            this.LabelCompany.TabIndex = 2;
            this.LabelCompany.Text = "Company";
            this.LabelCompany.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // LabelGroups
            // 
            this.LabelGroups.AutoSize = true;
            this.LabelGroups.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelGroups.Cursor = System.Windows.Forms.Cursors.Help;
            this.LabelGroups.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGroups.Location = new System.Drawing.Point(132, 119);
            this.LabelGroups.Name = "LabelGroups";
            this.LabelGroups.Size = new System.Drawing.Size(46, 25);
            this.LabelGroups.TabIndex = 3;
            this.LabelGroups.Text = "A2E";
            this.LabelGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            this.LabelGroups.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelGroups_MouseMove);
            // 
            // SearchResults
            // 
            this.SearchResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.SearchResults.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResults.FormattingEnabled = true;
            this.SearchResults.ItemHeight = 15;
            this.SearchResults.Location = new System.Drawing.Point(12, 194);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(567, 304);
            this.SearchResults.TabIndex = 4;
            this.SearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchResults_MouseDoubleClick);
            this.SearchResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SearchResults_MouseDown);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.CalendarFont = new System.Drawing.Font("Nirmala UI", 9F);
            this.DateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.DateTimePicker.CustomFormat = "";
            this.DateTimePicker.Font = new System.Drawing.Font("Nirmala UI", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Location = new System.Drawing.Point(315, 164);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(195, 24);
            this.DateTimePicker.TabIndex = 7;
            this.DateTimePicker.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // ButtonEditInfo
            // 
            this.ButtonEditInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonEditInfo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonEditInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEditInfo.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.ButtonEditInfo.ForeColor = System.Drawing.Color.White;
            this.ButtonEditInfo.Location = new System.Drawing.Point(12, 504);
            this.ButtonEditInfo.Name = "ButtonEditInfo";
            this.ButtonEditInfo.Size = new System.Drawing.Size(95, 25);
            this.ButtonEditInfo.TabIndex = 8;
            this.ButtonEditInfo.Text = "Edit Info";
            this.ButtonEditInfo.UseVisualStyleBackColor = false;
            this.ButtonEditInfo.Click += new System.EventHandler(this.ButtonEditInfo_Click);
            // 
            // ButtonAddNote
            // 
            this.ButtonAddNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddNote.Location = new System.Drawing.Point(282, 504);
            this.ButtonAddNote.Name = "ButtonAddNote";
            this.ButtonAddNote.Size = new System.Drawing.Size(95, 25);
            this.ButtonAddNote.TabIndex = 9;
            this.ButtonAddNote.Text = "Add Note";
            this.ButtonAddNote.UseVisualStyleBackColor = true;
            this.ButtonAddNote.Click += new System.EventHandler(this.ButtonAddNote_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReset.ForeColor = System.Drawing.Color.White;
            this.ButtonReset.Location = new System.Drawing.Point(516, 164);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(63, 24);
            this.ButtonReset.TabIndex = 10;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonDeleteNote
            // 
            this.ButtonDeleteNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteNote.Location = new System.Drawing.Point(484, 504);
            this.ButtonDeleteNote.Name = "ButtonDeleteNote";
            this.ButtonDeleteNote.Size = new System.Drawing.Size(95, 25);
            this.ButtonDeleteNote.TabIndex = 11;
            this.ButtonDeleteNote.Text = "Delete Note";
            this.ButtonDeleteNote.UseVisualStyleBackColor = true;
            this.ButtonDeleteNote.Click += new System.EventHandler(this.ButtonDeleteNote_Click);
            // 
            // LabelStudentNo
            // 
            this.LabelStudentNo.AutoSize = true;
            this.LabelStudentNo.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelStudentNo.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentNo.Location = new System.Drawing.Point(132, 44);
            this.LabelStudentNo.Name = "LabelStudentNo";
            this.LabelStudentNo.Size = new System.Drawing.Size(119, 25);
            this.LabelStudentNo.TabIndex = 12;
            this.LabelStudentNo.Text = "Student No.";
            this.LabelStudentNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // ComboBoxContext
            // 
            this.ComboBoxContext.BackColor = System.Drawing.Color.White;
            this.ComboBoxContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxContext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxContext.Font = new System.Drawing.Font("Nirmala UI", 9F);
            this.ComboBoxContext.FormattingEnabled = true;
            this.ComboBoxContext.ItemHeight = 15;
            this.ComboBoxContext.Items.AddRange(new object[] {
            "before",
            "from",
            "after"});
            this.ComboBoxContext.Location = new System.Drawing.Point(-1, -1);
            this.ComboBoxContext.Name = "ComboBoxContext";
            this.ComboBoxContext.Size = new System.Drawing.Size(63, 23);
            this.ComboBoxContext.TabIndex = 13;
            this.ComboBoxContext.SelectedIndexChanged += new System.EventHandler(this.ComboBoxContext_SelectedIndexChanged);
            // 
            // ButtonEditNote
            // 
            this.ButtonEditNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEditNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEditNote.Location = new System.Drawing.Point(383, 504);
            this.ButtonEditNote.Name = "ButtonEditNote";
            this.ButtonEditNote.Size = new System.Drawing.Size(95, 25);
            this.ButtonEditNote.TabIndex = 9;
            this.ButtonEditNote.Text = "Edit Note";
            this.ButtonEditNote.UseVisualStyleBackColor = true;
            this.ButtonEditNote.Click += new System.EventHandler(this.ButtonEditNote_Click);
            // 
            // LabelYearGroup
            // 
            this.LabelYearGroup.AutoSize = true;
            this.LabelYearGroup.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelYearGroup.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelYearGroup.Location = new System.Drawing.Point(132, 69);
            this.LabelYearGroup.Name = "LabelYearGroup";
            this.LabelYearGroup.Size = new System.Drawing.Size(113, 25);
            this.LabelYearGroup.TabIndex = 14;
            this.LabelYearGroup.Text = "Year Group";
            this.LabelYearGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // LabelStruggling
            // 
            this.LabelStruggling.AutoSize = true;
            this.LabelStruggling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStruggling.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelStruggling.Location = new System.Drawing.Point(35, 170);
            this.LabelStruggling.Name = "LabelStruggling";
            this.LabelStruggling.Size = new System.Drawing.Size(104, 13);
            this.LabelStruggling.TabIndex = 16;
            this.LabelStruggling.Text = "flagged as struggling";
            // 
            // ComboBoxBack
            // 
            this.ComboBoxBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboBoxBack.Controls.Add(this.ComboBoxContext);
            this.ComboBoxBack.Location = new System.Drawing.Point(246, 164);
            this.ComboBoxBack.Name = "ComboBoxBack";
            this.ComboBoxBack.Size = new System.Drawing.Size(63, 24);
            this.ComboBoxBack.TabIndex = 17;
            // 
            // ContextMenuInfo
            // 
            this.ContextMenuInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editInfoToolStripMenuItem});
            this.ContextMenuInfo.Name = "ContextMenuInfo";
            this.ContextMenuInfo.Size = new System.Drawing.Size(119, 26);
            // 
            // editInfoToolStripMenuItem
            // 
            this.editInfoToolStripMenuItem.Name = "editInfoToolStripMenuItem";
            this.editInfoToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.editInfoToolStripMenuItem.Text = "Edit Info";
            this.editInfoToolStripMenuItem.Click += new System.EventHandler(this.ButtonEditInfo_Click);
            // 
            // StudentPhoto
            // 
            this.StudentPhoto.ContextMenuStrip = this.ContextMenuInfo;
            this.StudentPhoto.ErrorImage = global::project.Properties.Resources.placeholder;
            this.StudentPhoto.Image = global::project.Properties.Resources.placeholder;
            this.StudentPhoto.InitialImage = global::project.Properties.Resources.placeholder;
            this.StudentPhoto.Location = new System.Drawing.Point(12, 12);
            this.StudentPhoto.MaximumSize = new System.Drawing.Size(114, 142);
            this.StudentPhoto.MinimumSize = new System.Drawing.Size(114, 142);
            this.StudentPhoto.Name = "StudentPhoto";
            this.StudentPhoto.Size = new System.Drawing.Size(114, 142);
            this.StudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StudentPhoto.TabIndex = 0;
            this.StudentPhoto.TabStop = false;
            this.StudentPhoto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // ImageBoxPlaceholder
            // 
            this.ImageBoxPlaceholder.ErrorImage = global::project.Properties.Resources.placeholder;
            this.ImageBoxPlaceholder.Image = global::project.Properties.Resources.placeholder;
            this.ImageBoxPlaceholder.InitialImage = global::project.Properties.Resources.placeholder;
            this.ImageBoxPlaceholder.Location = new System.Drawing.Point(12, 12);
            this.ImageBoxPlaceholder.Name = "ImageBoxPlaceholder";
            this.ImageBoxPlaceholder.Size = new System.Drawing.Size(114, 142);
            this.ImageBoxPlaceholder.TabIndex = 19;
            this.ImageBoxPlaceholder.TabStop = false;
            this.toolTip1.SetToolTip(this.ImageBoxPlaceholder, "Student photo unloaded for editing");
            this.ImageBoxPlaceholder.Visible = false;
            // 
            // ImageFlag
            // 
            this.ImageFlag.BackColor = System.Drawing.Color.Transparent;
            this.ImageFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ImageFlag.Image = global::project.Properties.Resources.flag1;
            this.ImageFlag.Location = new System.Drawing.Point(12, 164);
            this.ImageFlag.Name = "ImageFlag";
            this.ImageFlag.Size = new System.Drawing.Size(24, 24);
            this.ImageFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageFlag.TabIndex = 15;
            this.ImageFlag.TabStop = false;
            // 
            // ContextMenuNote
            // 
            this.ContextMenuNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ContextMenuNote.Name = "ContextMenuNote";
            this.ContextMenuNote.Size = new System.Drawing.Size(108, 70);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.ButtonEditNote_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.ButtonDeleteNote_Click);
            // 
            // ProfileEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 541);
            this.Controls.Add(this.StudentPhoto);
            this.Controls.Add(this.ImageBoxPlaceholder);
            this.Controls.Add(this.ImageFlag);
            this.Controls.Add(this.LabelYearGroup);
            this.Controls.Add(this.ButtonEditNote);
            this.Controls.Add(this.LabelStudentNo);
            this.Controls.Add(this.ButtonDeleteNote);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonAddNote);
            this.Controls.Add(this.ButtonEditInfo);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.SearchResults);
            this.Controls.Add(this.LabelGroups);
            this.Controls.Add(this.LabelCompany);
            this.Controls.Add(this.LabelStudentName);
            this.Controls.Add(this.LabelStruggling);
            this.Controls.Add(this.ComboBoxBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(607, 580);
            this.MinimumSize = new System.Drawing.Size(607, 580);
            this.Name = "ProfileEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[StudentName] - Info";
            this.Load += new System.EventHandler(this.ProfileEditView_Load);
            this.ComboBoxBack.ResumeLayout(false);
            this.ContextMenuInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxPlaceholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageFlag)).EndInit();
            this.ContextMenuNote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StudentPhoto;
        private System.Windows.Forms.Label LabelStudentName;
        private System.Windows.Forms.Label LabelCompany;
        private System.Windows.Forms.Label LabelGroups;
        /// Set listbox to public so highlighted entry can be accessed by different forms
        public System.Windows.Forms.ListBox SearchResults;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button ButtonEditInfo;
        private System.Windows.Forms.Button ButtonAddNote;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonDeleteNote;
        private System.Windows.Forms.Label LabelStudentNo;
        private System.Windows.Forms.ComboBox ComboBoxContext;
        private System.Windows.Forms.Button ButtonEditNote;
        private System.Windows.Forms.Label LabelYearGroup;
        private System.Windows.Forms.PictureBox ImageFlag;
        private System.Windows.Forms.Label LabelStruggling;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel ComboBoxBack;
        private System.Windows.Forms.PictureBox ImageBoxPlaceholder;
        private System.Windows.Forms.ContextMenuStrip ContextMenuInfo;
        private System.Windows.Forms.ToolStripMenuItem editInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuNote;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}