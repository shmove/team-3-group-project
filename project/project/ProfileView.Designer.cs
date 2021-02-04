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
            this.StudentPhoto = new System.Windows.Forms.PictureBox();
            this.LabelStudentName = new System.Windows.Forms.Label();
            this.LabelCompany = new System.Windows.Forms.Label();
            this.LabelGroups = new System.Windows.Forms.Label();
            this.SearchResults = new System.Windows.Forms.ListBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ButtonEditInfo = new System.Windows.Forms.Button();
            this.ButtonAddNote = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonDeleteNote = new System.Windows.Forms.Button();
            this.LabelStudentNo = new System.Windows.Forms.Label();
            this.ComboBoxContext = new System.Windows.Forms.ComboBox();
            this.ButtonEditNote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentPhoto
            // 
            this.StudentPhoto.Location = new System.Drawing.Point(12, 12);
            this.StudentPhoto.MaximumSize = new System.Drawing.Size(114, 142);
            this.StudentPhoto.MinimumSize = new System.Drawing.Size(114, 142);
            this.StudentPhoto.Name = "StudentPhoto";
            this.StudentPhoto.Size = new System.Drawing.Size(114, 142);
            this.StudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StudentPhoto.TabIndex = 0;
            this.StudentPhoto.TabStop = false;
            // 
            // LabelStudentName
            // 
            this.LabelStudentName.AutoSize = true;
            this.LabelStudentName.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentName.Location = new System.Drawing.Point(132, 9);
            this.LabelStudentName.Name = "LabelStudentName";
            this.LabelStudentName.Size = new System.Drawing.Size(177, 32);
            this.LabelStudentName.TabIndex = 1;
            this.LabelStudentName.Text = "Student Name";
            this.LabelStudentName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelCompany
            // 
            this.LabelCompany.AutoSize = true;
            this.LabelCompany.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCompany.Location = new System.Drawing.Point(132, 73);
            this.LabelCompany.Name = "LabelCompany";
            this.LabelCompany.Size = new System.Drawing.Size(123, 32);
            this.LabelCompany.TabIndex = 2;
            this.LabelCompany.Text = "Company";
            // 
            // LabelGroups
            // 
            this.LabelGroups.AutoSize = true;
            this.LabelGroups.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGroups.Location = new System.Drawing.Point(132, 105);
            this.LabelGroups.Name = "LabelGroups";
            this.LabelGroups.Size = new System.Drawing.Size(334, 32);
            this.LabelGroups.TabIndex = 3;
            this.LabelGroups.Text = "Registered for: Group name";
            // 
            // SearchResults
            // 
            this.SearchResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.SearchResults.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResults.FormattingEnabled = true;
            this.SearchResults.ItemHeight = 15;
            this.SearchResults.Location = new System.Drawing.Point(12, 207);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(567, 304);
            this.SearchResults.TabIndex = 4;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSearch.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSearch.Location = new System.Drawing.Point(422, 165);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(63, 22);
            this.ButtonSearch.TabIndex = 6;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.CalendarFont = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.DateTimePicker.Location = new System.Drawing.Point(202, 164);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(195, 20);
            this.DateTimePicker.TabIndex = 7;
            // 
            // ButtonEditInfo
            // 
            this.ButtonEditInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonEditInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEditInfo.ForeColor = System.Drawing.Color.White;
            this.ButtonEditInfo.Location = new System.Drawing.Point(12, 537);
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
            this.ButtonAddNote.Location = new System.Drawing.Point(361, 539);
            this.ButtonAddNote.Name = "ButtonAddNote";
            this.ButtonAddNote.Size = new System.Drawing.Size(95, 22);
            this.ButtonAddNote.TabIndex = 9;
            this.ButtonAddNote.Text = "Add Note";
            this.ButtonAddNote.UseVisualStyleBackColor = true;
            this.ButtonAddNote.Click += new System.EventHandler(this.ButtonAddNote_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReset.ForeColor = System.Drawing.Color.White;
            this.ButtonReset.Location = new System.Drawing.Point(508, 165);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(71, 24);
            this.ButtonReset.TabIndex = 10;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonDeleteNote
            // 
            this.ButtonDeleteNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteNote.Location = new System.Drawing.Point(484, 539);
            this.ButtonDeleteNote.Name = "ButtonDeleteNote";
            this.ButtonDeleteNote.Size = new System.Drawing.Size(95, 22);
            this.ButtonDeleteNote.TabIndex = 11;
            this.ButtonDeleteNote.Text = "Delete Note";
            this.ButtonDeleteNote.UseVisualStyleBackColor = true;
            // 
            // LabelStudentNo
            // 
            this.LabelStudentNo.AutoSize = true;
            this.LabelStudentNo.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentNo.Location = new System.Drawing.Point(132, 41);
            this.LabelStudentNo.Name = "LabelStudentNo";
            this.LabelStudentNo.Size = new System.Drawing.Size(151, 32);
            this.LabelStudentNo.TabIndex = 12;
            this.LabelStudentNo.Text = "Student No.";
            // 
            // ComboBoxContext
            // 
            this.ComboBoxContext.BackColor = System.Drawing.Color.White;
            this.ComboBoxContext.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxContext.FormattingEnabled = true;
            this.ComboBoxContext.Items.AddRange(new object[] {
            "before",
            "from",
            "after"});
            this.ComboBoxContext.Location = new System.Drawing.Point(137, 163);
            this.ComboBoxContext.Name = "ComboBoxContext";
            this.ComboBoxContext.Size = new System.Drawing.Size(59, 23);
            this.ComboBoxContext.TabIndex = 13;
            // 
            // ButtonEditNote
            // 
            this.ButtonEditNote.Location = new System.Drawing.Point(408, 508);
            this.ButtonEditNote.Name = "ButtonEditNote";
            this.ButtonEditNote.Size = new System.Drawing.Size(75, 23);
            this.ButtonEditNote.TabIndex = 14;
            this.ButtonEditNote.Text = "Edit Note";
            this.ButtonEditNote.UseVisualStyleBackColor = true;
            // 
            // ProfileEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 585);
            this.Controls.Add(this.ButtonEditNote);
            this.Controls.Add(this.ComboBoxContext);
            this.Controls.Add(this.LabelStudentNo);
            this.Controls.Add(this.ButtonDeleteNote);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonAddNote);
            this.Controls.Add(this.ButtonEditInfo);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.SearchResults);
            this.Controls.Add(this.LabelGroups);
            this.Controls.Add(this.LabelCompany);
            this.Controls.Add(this.LabelStudentName);
            this.Controls.Add(this.StudentPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProfileEditView";
            this.Text = "[StudentName] - Info";
            this.Load += new System.EventHandler(this.ProfileEditView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StudentPhoto;
        private System.Windows.Forms.Label LabelStudentName;
        private System.Windows.Forms.Label LabelCompany;
        private System.Windows.Forms.Label LabelGroups;
        private System.Windows.Forms.ListBox SearchResults;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button ButtonEditInfo;
        private System.Windows.Forms.Button ButtonAddNote;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonDeleteNote;
        private System.Windows.Forms.Label LabelStudentNo;
        private System.Windows.Forms.ComboBox ComboBoxContext;
        private System.Windows.Forms.Button ButtonEditNote;
    }
}