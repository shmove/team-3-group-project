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
            this.LabelStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentName.Location = new System.Drawing.Point(132, 18);
            this.LabelStudentName.Name = "LabelStudentName";
            this.LabelStudentName.Size = new System.Drawing.Size(148, 25);
            this.LabelStudentName.TabIndex = 1;
            this.LabelStudentName.Text = "Student Name";
            // 
            // LabelCompany
            // 
            this.LabelCompany.AutoSize = true;
            this.LabelCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCompany.Location = new System.Drawing.Point(132, 79);
            this.LabelCompany.Name = "LabelCompany";
            this.LabelCompany.Size = new System.Drawing.Size(103, 25);
            this.LabelCompany.TabIndex = 2;
            this.LabelCompany.Text = "Company";
            // 
            // LabelGroups
            // 
            this.LabelGroups.AutoSize = true;
            this.LabelGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGroups.Location = new System.Drawing.Point(132, 119);
            this.LabelGroups.Name = "LabelGroups";
            this.LabelGroups.Size = new System.Drawing.Size(277, 25);
            this.LabelGroups.TabIndex = 3;
            this.LabelGroups.Text = "Registered for: Group name";
            // 
            // SearchResults
            // 
            this.SearchResults.FormattingEnabled = true;
            this.SearchResults.Location = new System.Drawing.Point(12, 186);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(552, 316);
            this.SearchResults.TabIndex = 4;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(408, 157);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 6;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Location = new System.Drawing.Point(202, 160);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker.TabIndex = 7;
            // 
            // ButtonEditInfo
            // 
            this.ButtonEditInfo.Location = new System.Drawing.Point(12, 508);
            this.ButtonEditInfo.Name = "ButtonEditInfo";
            this.ButtonEditInfo.Size = new System.Drawing.Size(75, 23);
            this.ButtonEditInfo.TabIndex = 8;
            this.ButtonEditInfo.Text = "Edit Info";
            this.ButtonEditInfo.UseVisualStyleBackColor = true;
            this.ButtonEditInfo.Click += new System.EventHandler(this.ButtonEditInfo_Click);
            // 
            // ButtonAddNote
            // 
            this.ButtonAddNote.Location = new System.Drawing.Point(327, 508);
            this.ButtonAddNote.Name = "ButtonAddNote";
            this.ButtonAddNote.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddNote.TabIndex = 9;
            this.ButtonAddNote.Text = "Add Note";
            this.ButtonAddNote.UseVisualStyleBackColor = true;
            this.ButtonAddNote.Click += new System.EventHandler(this.ButtonAddNote_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(489, 157);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 10;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonDeleteNote
            // 
            this.ButtonDeleteNote.Location = new System.Drawing.Point(489, 508);
            this.ButtonDeleteNote.Name = "ButtonDeleteNote";
            this.ButtonDeleteNote.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteNote.TabIndex = 11;
            this.ButtonDeleteNote.Text = "Delete Note";
            this.ButtonDeleteNote.UseVisualStyleBackColor = true;
            // 
            // LabelStudentNo
            // 
            this.LabelStudentNo.AutoSize = true;
            this.LabelStudentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentNo.Location = new System.Drawing.Point(132, 43);
            this.LabelStudentNo.Name = "LabelStudentNo";
            this.LabelStudentNo.Size = new System.Drawing.Size(125, 25);
            this.LabelStudentNo.TabIndex = 12;
            this.LabelStudentNo.Text = "Student No.";
            // 
            // ComboBoxContext
            // 
            this.ComboBoxContext.FormattingEnabled = true;
            this.ComboBoxContext.Items.AddRange(new object[] {
            "before",
            "from",
            "after"});
            this.ComboBoxContext.Location = new System.Drawing.Point(137, 160);
            this.ComboBoxContext.Name = "ComboBoxContext";
            this.ComboBoxContext.Size = new System.Drawing.Size(59, 21);
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
            this.ClientSize = new System.Drawing.Size(576, 540);
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