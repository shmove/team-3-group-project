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
            this.ContextMenuInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ImageBoxPlaceholder = new System.Windows.Forms.PictureBox();
            this.ComboBoxBack = new System.Windows.Forms.Panel();
            this.StudentPhoto = new System.Windows.Forms.PictureBox();
            this.ImageFlag = new System.Windows.Forms.PictureBox();
            this.ContextMenuNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelWindowControls = new System.Windows.Forms.Panel();
            this.PanelWindowMinimise = new System.Windows.Forms.Panel();
            this.LabelMinimiseWindow = new System.Windows.Forms.Label();
            this.PanelWindowClose = new System.Windows.Forms.Panel();
            this.LabelCloseWindow = new System.Windows.Forms.Label();
            this.IconWindowControls = new System.Windows.Forms.PictureBox();
            this.borderPanelRight = new System.Windows.Forms.Panel();
            this.borderPanelLeft = new System.Windows.Forms.Panel();
            this.borderPanelBottom = new System.Windows.Forms.Panel();
            this.BorderPanelTopUpper = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BorderPanelLeft2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.ContextMenuInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxPlaceholder)).BeginInit();
            this.ComboBoxBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageFlag)).BeginInit();
            this.ContextMenuNote.SuspendLayout();
            this.PanelWindowControls.SuspendLayout();
            this.PanelWindowMinimise.SuspendLayout();
            this.PanelWindowClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconWindowControls)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelStudentName
            // 
            this.LabelStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelStudentName.AutoSize = true;
            this.LabelStudentName.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelStudentName.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentName.ForeColor = System.Drawing.Color.Black;
            this.LabelStudentName.Location = new System.Drawing.Point(131, 42);
            this.LabelStudentName.Name = "LabelStudentName";
            this.LabelStudentName.Size = new System.Drawing.Size(177, 32);
            this.LabelStudentName.TabIndex = 1;
            this.LabelStudentName.Text = "Student Name";
            this.LabelStudentName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelStudentName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
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
            // LabelCompany
            // 
            this.LabelCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelCompany.AutoSize = true;
            this.LabelCompany.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelCompany.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCompany.ForeColor = System.Drawing.Color.Black;
            this.LabelCompany.Location = new System.Drawing.Point(132, 124);
            this.LabelCompany.Name = "LabelCompany";
            this.LabelCompany.Size = new System.Drawing.Size(97, 25);
            this.LabelCompany.TabIndex = 2;
            this.LabelCompany.Text = "Company";
            this.LabelCompany.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // LabelGroups
            // 
            this.LabelGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelGroups.AutoSize = true;
            this.LabelGroups.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelGroups.Cursor = System.Windows.Forms.Cursors.Help;
            this.LabelGroups.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGroups.ForeColor = System.Drawing.Color.Black;
            this.LabelGroups.Location = new System.Drawing.Point(132, 149);
            this.LabelGroups.Name = "LabelGroups";
            this.LabelGroups.Size = new System.Drawing.Size(46, 25);
            this.LabelGroups.TabIndex = 3;
            this.LabelGroups.Text = "A2E";
            this.LabelGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            this.LabelGroups.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelGroups_MouseMove);
            // 
            // SearchResults
            // 
            this.SearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.SearchResults.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResults.ForeColor = System.Drawing.Color.Black;
            this.SearchResults.FormattingEnabled = true;
            this.SearchResults.ItemHeight = 15;
            this.SearchResults.Location = new System.Drawing.Point(12, 224);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(567, 304);
            this.SearchResults.TabIndex = 4;
            this.SearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchResults_MouseDoubleClick);
            this.SearchResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SearchResults_MouseDown);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimePicker.CalendarFont = new System.Drawing.Font("Nirmala UI", 9F);
            this.DateTimePicker.CalendarForeColor = System.Drawing.Color.Black;
            this.DateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.DateTimePicker.CustomFormat = "";
            this.DateTimePicker.Font = new System.Drawing.Font("Nirmala UI", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Location = new System.Drawing.Point(315, 194);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(195, 24);
            this.DateTimePicker.TabIndex = 7;
            this.DateTimePicker.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // ButtonEditInfo
            // 
            this.ButtonEditInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEditInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonEditInfo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonEditInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEditInfo.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.ButtonEditInfo.ForeColor = System.Drawing.Color.White;
            this.ButtonEditInfo.Location = new System.Drawing.Point(12, 534);
            this.ButtonEditInfo.Name = "ButtonEditInfo";
            this.ButtonEditInfo.Size = new System.Drawing.Size(95, 25);
            this.ButtonEditInfo.TabIndex = 8;
            this.ButtonEditInfo.Text = "Edit Info";
            this.ButtonEditInfo.UseVisualStyleBackColor = false;
            this.ButtonEditInfo.Click += new System.EventHandler(this.ButtonEditInfo_Click);
            // 
            // ButtonAddNote
            // 
            this.ButtonAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddNote.ForeColor = System.Drawing.Color.Black;
            this.ButtonAddNote.Location = new System.Drawing.Point(282, 534);
            this.ButtonAddNote.Name = "ButtonAddNote";
            this.ButtonAddNote.Size = new System.Drawing.Size(95, 25);
            this.ButtonAddNote.TabIndex = 9;
            this.ButtonAddNote.Text = "Add Note";
            this.ButtonAddNote.UseVisualStyleBackColor = true;
            this.ButtonAddNote.Click += new System.EventHandler(this.ButtonAddNote_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReset.ForeColor = System.Drawing.Color.White;
            this.ButtonReset.Location = new System.Drawing.Point(516, 194);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(63, 24);
            this.ButtonReset.TabIndex = 10;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonDeleteNote
            // 
            this.ButtonDeleteNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDeleteNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteNote.ForeColor = System.Drawing.Color.Black;
            this.ButtonDeleteNote.Location = new System.Drawing.Point(484, 534);
            this.ButtonDeleteNote.Name = "ButtonDeleteNote";
            this.ButtonDeleteNote.Size = new System.Drawing.Size(95, 25);
            this.ButtonDeleteNote.TabIndex = 11;
            this.ButtonDeleteNote.Text = "Delete Note";
            this.ButtonDeleteNote.UseVisualStyleBackColor = true;
            this.ButtonDeleteNote.Click += new System.EventHandler(this.ButtonDeleteNote_Click);
            // 
            // LabelStudentNo
            // 
            this.LabelStudentNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelStudentNo.AutoSize = true;
            this.LabelStudentNo.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelStudentNo.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStudentNo.ForeColor = System.Drawing.Color.Black;
            this.LabelStudentNo.Location = new System.Drawing.Point(132, 74);
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
            this.ButtonEditNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEditNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEditNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEditNote.ForeColor = System.Drawing.Color.Black;
            this.ButtonEditNote.Location = new System.Drawing.Point(383, 534);
            this.ButtonEditNote.Name = "ButtonEditNote";
            this.ButtonEditNote.Size = new System.Drawing.Size(95, 25);
            this.ButtonEditNote.TabIndex = 9;
            this.ButtonEditNote.Text = "Edit Note";
            this.ButtonEditNote.UseVisualStyleBackColor = true;
            this.ButtonEditNote.Click += new System.EventHandler(this.ButtonEditNote_Click);
            // 
            // LabelYearGroup
            // 
            this.LabelYearGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelYearGroup.AutoSize = true;
            this.LabelYearGroup.ContextMenuStrip = this.ContextMenuInfo;
            this.LabelYearGroup.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelYearGroup.ForeColor = System.Drawing.Color.Black;
            this.LabelYearGroup.Location = new System.Drawing.Point(132, 99);
            this.LabelYearGroup.Name = "LabelYearGroup";
            this.LabelYearGroup.Size = new System.Drawing.Size(113, 25);
            this.LabelYearGroup.TabIndex = 14;
            this.LabelYearGroup.Text = "Year Group";
            this.LabelYearGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // LabelStruggling
            // 
            this.LabelStruggling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelStruggling.AutoSize = true;
            this.LabelStruggling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStruggling.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelStruggling.Location = new System.Drawing.Point(35, 200);
            this.LabelStruggling.Name = "LabelStruggling";
            this.LabelStruggling.Size = new System.Drawing.Size(104, 13);
            this.LabelStruggling.TabIndex = 16;
            this.LabelStruggling.Text = "flagged as struggling";
            // 
            // ImageBoxPlaceholder
            // 
            this.ImageBoxPlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageBoxPlaceholder.ErrorImage = global::project.Properties.Resources.placeholder;
            this.ImageBoxPlaceholder.Image = global::project.Properties.Resources.placeholder;
            this.ImageBoxPlaceholder.InitialImage = global::project.Properties.Resources.placeholder;
            this.ImageBoxPlaceholder.Location = new System.Drawing.Point(12, 42);
            this.ImageBoxPlaceholder.Name = "ImageBoxPlaceholder";
            this.ImageBoxPlaceholder.Size = new System.Drawing.Size(114, 142);
            this.ImageBoxPlaceholder.TabIndex = 19;
            this.ImageBoxPlaceholder.TabStop = false;
            this.toolTip1.SetToolTip(this.ImageBoxPlaceholder, "Student photo unloaded for editing");
            this.ImageBoxPlaceholder.Visible = false;
            // 
            // ComboBoxBack
            // 
            this.ComboBoxBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboBoxBack.Controls.Add(this.ComboBoxContext);
            this.ComboBoxBack.Location = new System.Drawing.Point(246, 194);
            this.ComboBoxBack.Name = "ComboBoxBack";
            this.ComboBoxBack.Size = new System.Drawing.Size(63, 24);
            this.ComboBoxBack.TabIndex = 17;
            // 
            // StudentPhoto
            // 
            this.StudentPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StudentPhoto.ContextMenuStrip = this.ContextMenuInfo;
            this.StudentPhoto.ErrorImage = global::project.Properties.Resources.placeholder;
            this.StudentPhoto.Image = global::project.Properties.Resources.placeholder;
            this.StudentPhoto.InitialImage = global::project.Properties.Resources.placeholder;
            this.StudentPhoto.Location = new System.Drawing.Point(12, 42);
            this.StudentPhoto.MaximumSize = new System.Drawing.Size(114, 142);
            this.StudentPhoto.MinimumSize = new System.Drawing.Size(114, 142);
            this.StudentPhoto.Name = "StudentPhoto";
            this.StudentPhoto.Size = new System.Drawing.Size(114, 142);
            this.StudentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StudentPhoto.TabIndex = 0;
            this.StudentPhoto.TabStop = false;
            this.StudentPhoto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StudentPhoto_MouseDoubleClick);
            // 
            // ImageFlag
            // 
            this.ImageFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageFlag.BackColor = System.Drawing.Color.Transparent;
            this.ImageFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ImageFlag.Image = global::project.Properties.Resources.flag1;
            this.ImageFlag.Location = new System.Drawing.Point(12, 194);
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
            // PanelWindowControls
            // 
            this.PanelWindowControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PanelWindowControls.Controls.Add(this.PanelWindowMinimise);
            this.PanelWindowControls.Controls.Add(this.PanelWindowClose);
            this.PanelWindowControls.Controls.Add(this.IconWindowControls);
            this.PanelWindowControls.Location = new System.Drawing.Point(0, 0);
            this.PanelWindowControls.Name = "PanelWindowControls";
            this.PanelWindowControls.Size = new System.Drawing.Size(591, 30);
            this.PanelWindowControls.TabIndex = 33;
            this.PanelWindowControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelWindowControls_MouseDown);
            // 
            // PanelWindowMinimise
            // 
            this.PanelWindowMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelWindowMinimise.Controls.Add(this.LabelMinimiseWindow);
            this.PanelWindowMinimise.Location = new System.Drawing.Point(501, 0);
            this.PanelWindowMinimise.Name = "PanelWindowMinimise";
            this.PanelWindowMinimise.Size = new System.Drawing.Size(45, 30);
            this.PanelWindowMinimise.TabIndex = 24;
            this.PanelWindowMinimise.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelWindowMinimise_MouseDown);
            this.PanelWindowMinimise.MouseLeave += new System.EventHandler(this.PanelWindowMinimise_MouseLeave);
            this.PanelWindowMinimise.MouseHover += new System.EventHandler(this.PanelWindowMinimise_MouseHover);
            // 
            // LabelMinimiseWindow
            // 
            this.LabelMinimiseWindow.AutoSize = true;
            this.LabelMinimiseWindow.Enabled = false;
            this.LabelMinimiseWindow.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelMinimiseWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LabelMinimiseWindow.Location = new System.Drawing.Point(13, 5);
            this.LabelMinimiseWindow.Name = "LabelMinimiseWindow";
            this.LabelMinimiseWindow.Size = new System.Drawing.Size(21, 17);
            this.LabelMinimiseWindow.TabIndex = 24;
            this.LabelMinimiseWindow.Text = "—";
            this.LabelMinimiseWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelWindowMinimise_MouseDown);
            this.LabelMinimiseWindow.MouseHover += new System.EventHandler(this.PanelWindowMinimise_MouseHover);
            // 
            // PanelWindowClose
            // 
            this.PanelWindowClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelWindowClose.Controls.Add(this.LabelCloseWindow);
            this.PanelWindowClose.Location = new System.Drawing.Point(546, 0);
            this.PanelWindowClose.Name = "PanelWindowClose";
            this.PanelWindowClose.Size = new System.Drawing.Size(45, 30);
            this.PanelWindowClose.TabIndex = 23;
            this.PanelWindowClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelWindowClose_MouseDown);
            this.PanelWindowClose.MouseLeave += new System.EventHandler(this.PanelWindowClose_MouseLeave);
            this.PanelWindowClose.MouseHover += new System.EventHandler(this.PanelWindowClose_MouseHover);
            // 
            // LabelCloseWindow
            // 
            this.LabelCloseWindow.AutoSize = true;
            this.LabelCloseWindow.Enabled = false;
            this.LabelCloseWindow.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LabelCloseWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LabelCloseWindow.Location = new System.Drawing.Point(13, 5);
            this.LabelCloseWindow.Name = "LabelCloseWindow";
            this.LabelCloseWindow.Size = new System.Drawing.Size(22, 17);
            this.LabelCloseWindow.TabIndex = 23;
            this.LabelCloseWindow.Text = "╳";
            this.LabelCloseWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelWindowClose_MouseDown);
            this.LabelCloseWindow.MouseHover += new System.EventHandler(this.PanelWindowClose_MouseHover);
            // 
            // IconWindowControls
            // 
            this.IconWindowControls.Image = global::project.Properties.Resources.programIcon;
            this.IconWindowControls.Location = new System.Drawing.Point(5, 5);
            this.IconWindowControls.Name = "IconWindowControls";
            this.IconWindowControls.Size = new System.Drawing.Size(20, 20);
            this.IconWindowControls.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconWindowControls.TabIndex = 23;
            this.IconWindowControls.TabStop = false;
            this.IconWindowControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelWindowControls_MouseDown);
            // 
            // borderPanelRight
            // 
            this.borderPanelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.borderPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.borderPanelRight.Location = new System.Drawing.Point(586, 0);
            this.borderPanelRight.Name = "borderPanelRight";
            this.borderPanelRight.Size = new System.Drawing.Size(5, 566);
            this.borderPanelRight.TabIndex = 32;
            // 
            // borderPanelLeft
            // 
            this.borderPanelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.borderPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.borderPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.borderPanelLeft.Name = "borderPanelLeft";
            this.borderPanelLeft.Size = new System.Drawing.Size(5, 566);
            this.borderPanelLeft.TabIndex = 31;
            // 
            // borderPanelBottom
            // 
            this.borderPanelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.borderPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.borderPanelBottom.Location = new System.Drawing.Point(0, 566);
            this.borderPanelBottom.Name = "borderPanelBottom";
            this.borderPanelBottom.Size = new System.Drawing.Size(591, 5);
            this.borderPanelBottom.TabIndex = 30;
            // 
            // BorderPanelTopUpper
            // 
            this.BorderPanelTopUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BorderPanelTopUpper.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderPanelTopUpper.Location = new System.Drawing.Point(0, 0);
            this.BorderPanelTopUpper.Name = "BorderPanelTopUpper";
            this.BorderPanelTopUpper.Size = new System.Drawing.Size(591, 1);
            this.BorderPanelTopUpper.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(0, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 1);
            this.panel1.TabIndex = 43;
            // 
            // BorderPanelLeft2
            // 
            this.BorderPanelLeft2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BorderPanelLeft2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderPanelLeft2.Location = new System.Drawing.Point(0, 0);
            this.BorderPanelLeft2.Name = "BorderPanelLeft2";
            this.BorderPanelLeft2.Size = new System.Drawing.Size(1, 571);
            this.BorderPanelLeft2.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Location = new System.Drawing.Point(590, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 571);
            this.panel2.TabIndex = 45;
            // 
            // ButtonExport
            // 
            this.ButtonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonExport.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ButtonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExport.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.ButtonExport.ForeColor = System.Drawing.Color.White;
            this.ButtonExport.Location = new System.Drawing.Point(113, 534);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(95, 25);
            this.ButtonExport.TabIndex = 46;
            this.ButtonExport.Text = "Export Data";
            this.ButtonExport.UseVisualStyleBackColor = false;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // ProfileEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 571);
            this.Controls.Add(this.ButtonExport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BorderPanelLeft2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BorderPanelTopUpper);
            this.Controls.Add(this.PanelWindowControls);
            this.Controls.Add(this.borderPanelRight);
            this.Controls.Add(this.borderPanelLeft);
            this.Controls.Add(this.borderPanelBottom);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProfileEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dddd";
            this.Load += new System.EventHandler(this.ProfileEditView_Load);
            this.ContextMenuInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxPlaceholder)).EndInit();
            this.ComboBoxBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageFlag)).EndInit();
            this.ContextMenuNote.ResumeLayout(false);
            this.PanelWindowControls.ResumeLayout(false);
            this.PanelWindowMinimise.ResumeLayout(false);
            this.PanelWindowMinimise.PerformLayout();
            this.PanelWindowClose.ResumeLayout(false);
            this.PanelWindowClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconWindowControls)).EndInit();
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
        private System.Windows.Forms.Panel PanelWindowControls;
        private System.Windows.Forms.Panel PanelWindowMinimise;
        private System.Windows.Forms.Label LabelMinimiseWindow;
        private System.Windows.Forms.Panel PanelWindowClose;
        private System.Windows.Forms.Label LabelCloseWindow;
        private System.Windows.Forms.PictureBox IconWindowControls;
        private System.Windows.Forms.Panel borderPanelRight;
        private System.Windows.Forms.Panel borderPanelLeft;
        private System.Windows.Forms.Panel borderPanelBottom;
        private System.Windows.Forms.Panel BorderPanelTopUpper;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel BorderPanelLeft2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ButtonExport;
    }
}