namespace project
{
    partial class pupilRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pupilRecords));
            this.label1 = new System.Windows.Forms.Label();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.CheckBoxA2E = new System.Windows.Forms.CheckBox();
            this.SearchResults = new System.Windows.Forms.ListBox();
            this.ViewButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ButtonAddStudent = new System.Windows.Forms.Button();
            this.ButtonDeleteStudent = new System.Windows.Forms.Button();
            this.labelFilters = new System.Windows.Forms.Label();
            this.ButtonFilterDropDown = new System.Windows.Forms.Button();
            this.filtersBack = new System.Windows.Forms.Panel();
            this.dropDownBack = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxBack = new System.Windows.Forms.Panel();
            this.ComboBoxContext = new System.Windows.Forms.ComboBox();
            this.ComboBoxYearGroupBack = new System.Windows.Forms.Panel();
            this.ComboBoxYearGroup = new System.Windows.Forms.ComboBox();
            this.CheckBoxStruggling = new System.Windows.Forms.CheckBox();
            this.dropdownTimer = new System.Windows.Forms.Timer(this.components);
            this.filtersBack.SuspendLayout();
            this.dropDownBack.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ComboBoxBack.SuspendLayout();
            this.ComboBoxYearGroupBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Records Program";
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(12, 58);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(776, 20);
            this.SearchBar.TabIndex = 1;
            this.SearchBar.TextChanged += new System.EventHandler(this.QuickDisplayUpdateEvent);
            // 
            // CheckBoxA2E
            // 
            this.CheckBoxA2E.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxA2E.AutoSize = true;
            this.CheckBoxA2E.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxA2E.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckBoxA2E.Location = new System.Drawing.Point(6, -130);
            this.CheckBoxA2E.Name = "CheckBoxA2E";
            this.CheckBoxA2E.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxA2E.Size = new System.Drawing.Size(174, 17);
            this.CheckBoxA2E.TabIndex = 3;
            this.CheckBoxA2E.Text = "                        Able to Enable";
            this.CheckBoxA2E.UseVisualStyleBackColor = true;
            this.CheckBoxA2E.CheckedChanged += new System.EventHandler(this.QuickDisplayUpdateEvent);
            // 
            // SearchResults
            // 
            this.SearchResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.SearchResults.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResults.FormattingEnabled = true;
            this.SearchResults.ItemHeight = 15;
            this.SearchResults.Location = new System.Drawing.Point(12, 119);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(776, 289);
            this.SearchResults.TabIndex = 4;
            this.SearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchResults_MouseDoubleClick);
            // 
            // ViewButton
            // 
            this.ViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewButton.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewButton.Location = new System.Drawing.Point(713, 414);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(75, 23);
            this.ViewButton.TabIndex = 5;
            this.ViewButton.Text = "View";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResetButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.ForeColor = System.Drawing.Color.White;
            this.ResetButton.Location = new System.Drawing.Point(713, 84);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 25);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ButtonAddStudent
            // 
            this.ButtonAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddStudent.Location = new System.Drawing.Point(12, 414);
            this.ButtonAddStudent.Name = "ButtonAddStudent";
            this.ButtonAddStudent.Size = new System.Drawing.Size(100, 23);
            this.ButtonAddStudent.TabIndex = 7;
            this.ButtonAddStudent.Text = "Add Student";
            this.ButtonAddStudent.UseVisualStyleBackColor = true;
            this.ButtonAddStudent.Click += new System.EventHandler(this.ButtonAddStudent_Click);
            // 
            // ButtonDeleteStudent
            // 
            this.ButtonDeleteStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonDeleteStudent.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteStudent.ForeColor = System.Drawing.Color.White;
            this.ButtonDeleteStudent.Location = new System.Drawing.Point(118, 414);
            this.ButtonDeleteStudent.Name = "ButtonDeleteStudent";
            this.ButtonDeleteStudent.Size = new System.Drawing.Size(100, 23);
            this.ButtonDeleteStudent.TabIndex = 8;
            this.ButtonDeleteStudent.Text = "Delete Student";
            this.ButtonDeleteStudent.UseVisualStyleBackColor = false;
            this.ButtonDeleteStudent.Click += new System.EventHandler(this.ButtonDeleteStudent_Click);
            // 
            // labelFilters
            // 
            this.labelFilters.AutoSize = true;
            this.labelFilters.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilters.Location = new System.Drawing.Point(0, 3);
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(41, 15);
            this.labelFilters.TabIndex = 9;
            this.labelFilters.Text = "Filters";
            this.labelFilters.Click += new System.EventHandler(this.ButtonFilterDropDown_Click);
            // 
            // ButtonFilterDropDown
            // 
            this.ButtonFilterDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonFilterDropDown.FlatAppearance.BorderSize = 0;
            this.ButtonFilterDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFilterDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonFilterDropDown.ForeColor = System.Drawing.Color.White;
            this.ButtonFilterDropDown.Location = new System.Drawing.Point(44, -1);
            this.ButtonFilterDropDown.Name = "ButtonFilterDropDown";
            this.ButtonFilterDropDown.Size = new System.Drawing.Size(23, 23);
            this.ButtonFilterDropDown.TabIndex = 10;
            this.ButtonFilterDropDown.Text = "▼";
            this.ButtonFilterDropDown.UseVisualStyleBackColor = false;
            this.ButtonFilterDropDown.Click += new System.EventHandler(this.ButtonFilterDropDown_Click);
            // 
            // filtersBack
            // 
            this.filtersBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filtersBack.Controls.Add(this.ButtonFilterDropDown);
            this.filtersBack.Controls.Add(this.labelFilters);
            this.filtersBack.Location = new System.Drawing.Point(12, 86);
            this.filtersBack.Name = "filtersBack";
            this.filtersBack.Size = new System.Drawing.Size(69, 23);
            this.filtersBack.TabIndex = 11;
            this.filtersBack.Click += new System.EventHandler(this.ButtonFilterDropDown_Click);
            // 
            // dropDownBack
            // 
            this.dropDownBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dropDownBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dropDownBack.Controls.Add(this.panel1);
            this.dropDownBack.Location = new System.Drawing.Point(12, 108);
            this.dropDownBack.MaximumSize = new System.Drawing.Size(200, 150);
            this.dropDownBack.MinimumSize = new System.Drawing.Size(10, 10);
            this.dropDownBack.Name = "dropDownBack";
            this.dropDownBack.Size = new System.Drawing.Size(200, 10);
            this.dropDownBack.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ComboBoxBack);
            this.panel1.Controls.Add(this.ComboBoxYearGroupBack);
            this.panel1.Controls.Add(this.CheckBoxStruggling);
            this.panel1.Controls.Add(this.CheckBoxA2E);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MaximumSize = new System.Drawing.Size(192, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 2);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(8, -48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "last edited:";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePicker.CalendarFont = new System.Drawing.Font("Nirmala UI", 9F);
            this.DateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.DateTimePicker.CustomFormat = "";
            this.DateTimePicker.Font = new System.Drawing.Font("Nirmala UI", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker.Location = new System.Drawing.Point(77, -33);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(103, 24);
            this.DateTimePicker.TabIndex = 18;
            this.DateTimePicker.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, -80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Year Group";
            // 
            // ComboBoxBack
            // 
            this.ComboBoxBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboBoxBack.Controls.Add(this.ComboBoxContext);
            this.ComboBoxBack.Location = new System.Drawing.Point(10, -32);
            this.ComboBoxBack.Name = "ComboBoxBack";
            this.ComboBoxBack.Size = new System.Drawing.Size(63, 24);
            this.ComboBoxBack.TabIndex = 19;
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
            " ",
            "before",
            "on",
            "after"});
            this.ComboBoxContext.Location = new System.Drawing.Point(-5, -1);
            this.ComboBoxContext.Name = "ComboBoxContext";
            this.ComboBoxContext.Size = new System.Drawing.Size(63, 23);
            this.ComboBoxContext.TabIndex = 13;
            this.ComboBoxContext.SelectedIndexChanged += new System.EventHandler(this.ComboBoxContext_SelectedIndexChanged);
            // 
            // ComboBoxYearGroupBack
            // 
            this.ComboBoxYearGroupBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxYearGroupBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboBoxYearGroupBack.Controls.Add(this.ComboBoxYearGroup);
            this.ComboBoxYearGroupBack.Location = new System.Drawing.Point(77, -84);
            this.ComboBoxYearGroupBack.Name = "ComboBoxYearGroupBack";
            this.ComboBoxYearGroupBack.Size = new System.Drawing.Size(103, 24);
            this.ComboBoxYearGroupBack.TabIndex = 18;
            // 
            // ComboBoxYearGroup
            // 
            this.ComboBoxYearGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxYearGroup.BackColor = System.Drawing.Color.White;
            this.ComboBoxYearGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxYearGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxYearGroup.Font = new System.Drawing.Font("Nirmala UI", 9F);
            this.ComboBoxYearGroup.FormattingEnabled = true;
            this.ComboBoxYearGroup.ItemHeight = 15;
            this.ComboBoxYearGroup.Items.AddRange(new object[] {
            " ",
            "S1",
            "S2",
            "S3",
            "S4",
            "S5",
            "S6",
            "College1",
            "College2",
            "Uni1",
            "Uni2",
            "Uni3",
            "Uni4"});
            this.ComboBoxYearGroup.Location = new System.Drawing.Point(-1, -1);
            this.ComboBoxYearGroup.Name = "ComboBoxYearGroup";
            this.ComboBoxYearGroup.Size = new System.Drawing.Size(103, 23);
            this.ComboBoxYearGroup.TabIndex = 13;
            this.ComboBoxYearGroup.SelectedIndexChanged += new System.EventHandler(this.QuickDisplayUpdateEvent);
            // 
            // CheckBoxStruggling
            // 
            this.CheckBoxStruggling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxStruggling.AutoSize = true;
            this.CheckBoxStruggling.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxStruggling.Location = new System.Drawing.Point(6, -107);
            this.CheckBoxStruggling.Name = "CheckBoxStruggling";
            this.CheckBoxStruggling.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxStruggling.Size = new System.Drawing.Size(174, 17);
            this.CheckBoxStruggling.TabIndex = 4;
            this.CheckBoxStruggling.Text = "                               Struggling";
            this.CheckBoxStruggling.UseVisualStyleBackColor = true;
            this.CheckBoxStruggling.CheckedChanged += new System.EventHandler(this.QuickDisplayUpdateEvent);
            // 
            // dropdownTimer
            // 
            this.dropdownTimer.Interval = 10;
            this.dropdownTimer.Tick += new System.EventHandler(this.dropdownTimer_Tick);
            // 
            // pupilRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 447);
            this.Controls.Add(this.dropDownBack);
            this.Controls.Add(this.ButtonDeleteStudent);
            this.Controls.Add(this.ButtonAddStudent);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.SearchResults);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filtersBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pupilRecords";
            this.Text = "Student Records Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.filtersBack.ResumeLayout(false);
            this.filtersBack.PerformLayout();
            this.dropDownBack.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ComboBoxBack.ResumeLayout(false);
            this.ComboBoxYearGroupBack.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.CheckBox CheckBoxA2E;

        /// Set listbox to public so highlighted entry can be accessed by different forms
        public System.Windows.Forms.ListBox SearchResults; 

        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button ButtonAddStudent;
        private System.Windows.Forms.Button ButtonDeleteStudent;
        private System.Windows.Forms.Label labelFilters;
        private System.Windows.Forms.Button ButtonFilterDropDown;
        private System.Windows.Forms.Panel filtersBack;
        private System.Windows.Forms.Panel dropDownBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CheckBoxStruggling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ComboBoxYearGroupBack;
        private System.Windows.Forms.ComboBox ComboBoxYearGroup;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Panel ComboBoxBack;
        private System.Windows.Forms.ComboBox ComboBoxContext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer dropdownTimer;
    }
}

