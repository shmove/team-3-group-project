using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static project.PupilDataManager.SharedResources.Types;

namespace project
{
    public partial class pupilRecords : Form
    {
        public DbUser User;
        public DbPupilDataManager Mgr;
        public pupilRecords(DbUser User = null)
        {
            this.Mgr = new DbPupilDataManager(User);
            InitializeComponent();
        }

        private class SortMethod
        {
            public bool Reverse { get; set; }
            public string Type { get; set; }
            public SortMethod(bool p_Reverse, string p_Type)
            {
                Reverse = p_Reverse;
                Type = p_Type;
            }
        };

        public Pupil activeStudent; // for accessing when creating a new student
        private bool filterDropDownToggle; // state of filter dropdown menu
        private bool sortDropDownToggle; // state of sort dropdown menu
        private SortMethod sortType = new SortMethod(false, "Alphabetical"); // holds sort state
        private bool ignoreReloads;

        // WINDOW CONTROL BAR

        // allows for window dragging
        // https://stackoverflow.com/a/1592899
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void PanelWindowControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PanelWindowClose_MouseHover(object sender, EventArgs e)
        {
            PanelWindowClose.BackColor = Color.FromArgb(255, 210, 211, 213);
        }

        private void PanelWindowClose_MouseLeave(object sender, EventArgs e)
        {
            PanelWindowClose.BackColor = Color.FromArgb(255, 230, 231, 233);
        }

        private void PanelWindowClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            FadeEffect.FadeOut(this, 100, new Action(() => this.Close()));
        }

        private void PanelWindowMinimise_MouseHover(object sender, EventArgs e)
        {
            PanelWindowMinimise.BackColor = Color.FromArgb(255, 210, 211, 213);
        }

        private void PanelWindowMinimise_MouseLeave(object sender, EventArgs e)
        {
            PanelWindowMinimise.BackColor = Color.FromArgb(255, 230, 231, 233);
        }

        private void PanelWindowMinimise_MouseDown(object sender, MouseEventArgs e)
        {
            FadeEffect.FadeOut(this, 100, new Action(() =>
            this.WindowState = FormWindowState.Minimized
            ));
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) FadeEffect.FadeIn(this, 100);
        }

        // FORM CODE

        /// <summary>
        /// possibly the ugliest function i've ever made
        /// 
        /// gets the status of all filters and updates display accordingly
        /// </summary>
        private void reloadPupils()
        {

            if (!ignoreReloads)
            {
                List<Pupil> Pupils;

                // cute lil cursor change bc why not
                Cursor.Current = Cursors.WaitCursor;

                // FILTERS
                // This can definitely be done better. 
                // This looks fine for now, but on adding more filters it's gonna get a lot worse.
                // edit: it's a lot worse
                // Spent a few hours looking into objects in c# and can't figure out a better way to initialise a property ONLY if a condition is met,
                // so spiralling If statement is the only solution I could come up with. soz xoxo
                if (CheckBoxA2E.Checked)
                {
                    if (CheckBoxStruggling.Checked)
                    {
                        if (ComboBoxYearGroup.SelectedIndex != 0)
                        {
                            Pupil.YearGroups[] yearGroups = { Pupil.YearGroups.S1, Pupil.YearGroups.S2, Pupil.YearGroups.S3, Pupil.YearGroups.S4, Pupil.YearGroups.S5, Pupil.YearGroups.S6, Pupil.YearGroups.College1, Pupil.YearGroups.College2, Pupil.YearGroups.Uni1, Pupil.YearGroups.Uni2, Pupil.YearGroups.Uni3, Pupil.YearGroups.Uni4 };
                            Pupils = Mgr.GetPupilsByProperties(new { A2E = true, Struggling = true, YearGroup = yearGroups[ComboBoxYearGroup.SelectedIndex - 1] });
                        }
                        else
                        {
                            Pupils = Mgr.GetPupilsByProperties(new { A2E = true, Struggling = true });
                        }
                    }
                    else
                    {
                        Pupils = Mgr.GetPupilsByProperties(new { A2E = true });
                    }
                }
                else // this is 100% yandev code now
                {
                    if (CheckBoxStruggling.Checked)
                    {
                        if (ComboBoxYearGroup.SelectedIndex != 0)
                        {
                            Pupil.YearGroups[] yearGroups = { Pupil.YearGroups.S1, Pupil.YearGroups.S2, Pupil.YearGroups.S3, Pupil.YearGroups.S4, Pupil.YearGroups.S5, Pupil.YearGroups.S6, Pupil.YearGroups.College1, Pupil.YearGroups.College2, Pupil.YearGroups.Uni1, Pupil.YearGroups.Uni2, Pupil.YearGroups.Uni3, Pupil.YearGroups.Uni4 };
                            Pupils = Mgr.GetPupilsByProperties(new { Struggling = true, YearGroup = yearGroups[ComboBoxYearGroup.SelectedIndex - 1] });
                        }
                        else
                        {
                            Pupils = Mgr.GetPupilsByProperties(new { Struggling = true });
                        }
                    }
                    else
                    {
                        if (ComboBoxYearGroup.SelectedIndex != 0)
                        {
                            Pupil.YearGroups[] yearGroups = { Pupil.YearGroups.S1, Pupil.YearGroups.S2, Pupil.YearGroups.S3, Pupil.YearGroups.S4, Pupil.YearGroups.S5, Pupil.YearGroups.S6, Pupil.YearGroups.College1, Pupil.YearGroups.College2, Pupil.YearGroups.Uni1, Pupil.YearGroups.Uni2, Pupil.YearGroups.Uni3, Pupil.YearGroups.Uni4 };
                            Pupils = Mgr.GetPupilsByProperties(new { YearGroup = yearGroups[ComboBoxYearGroup.SelectedIndex - 1] });
                        }
                        else
                        {
                            Pupils = Mgr.GetPupilsByProperties(new { });
                        }
                    }
                }

                // wipes listbox
                SearchResults.Items.Clear();

                List<Pupil> unsortedPupils = new List<Pupil>();

                // NAME / ID SEARCH
                // if first char is number, assume user is searching by id
                if (SearchBar.Text != "")
                {
                    if (Char.IsNumber(SearchBar.Text[0]))
                    {
                        foreach (Pupil pupil in Pupils)
                        {
                            if (pupil.PupilID.StartsWith(SearchBar.Text.Trim())) unsortedPupils.Add(pupil);
                        }
                    }
                    else // this feels like yanderedev code
                    {
                        foreach (Pupil pupil in Pupils)
                        {
                            if (pupil.Name.ToLower().Contains(SearchBar.Text.Trim().ToLower())) unsortedPupils.Add(pupil);
                        }
                    }
                }
                else
                {
                    foreach (Pupil pupil in Pupils)
                    {
                        unsortedPupils.Add(pupil);
                    }
                }

                // sorts pupils
                List<Pupil> unDatedPupils;
                switch (sortType.Type)
                {
                    case "Alphabetical":
                        // https://stackoverflow.com/a/3309230
                        unDatedPupils = unsortedPupils.OrderBy(o => o.Name).ToList();
                        break;
                    case "YearGroup":
                        // subject to change very soon, so don't want to waste time setting this up just yet
                        throw new Exception("UNIMPLEMENTED: add sorting by year group when new year group format is established");
                        break;
                    case "LastAccess":
                        unDatedPupils = unsortedPupils.OrderBy(o => DateTime.Parse(o.LastAccess)).ToList();
                        unDatedPupils.Reverse(); // reverses, so that most recently accessed are first by default
                        break;
                    default:
                        unDatedPupils = unsortedPupils.ToList();
                        throw new Exception("Tried to sort pupils by invalid type");
                }

                if (sortType.Reverse) unDatedPupils.Reverse();

                // now, for date checking
                if (DateTimePicker.Format != DateTimePickerFormat.Custom)
                {
                    string selectedDate = DateTimePicker.Value.ToString("dd-MM-yyyy");

                    switch (ComboBoxContext.SelectedIndex)
                    {
                        case 1:
                            // all accessed AFTER specified date
                            foreach (Pupil student in unDatedPupils)
                            {
                                int relative = compareDates(selectedDate, student.LastAccess);
                                if (relative == 1 || relative == 0)
                                {
                                    SearchResults.Items.Add(student.Name + " (" + student.PupilID + ")");
                                }
                            }
                            break;
                        case 2:
                            // all accessed ON specified date
                            foreach (Pupil student in unDatedPupils)
                            {
                                int relative = compareDates(selectedDate, student.LastAccess);
                                if (relative == 0)
                                {
                                    SearchResults.Items.Add(student.Name + " (" + student.PupilID + ")");
                                }
                            }
                            break;
                        case 3:
                            // all accessed BEFORE specified date
                            foreach (Pupil student in unDatedPupils)
                            {
                                int relative = compareDates(selectedDate, student.LastAccess);
                                if (relative == -1 || relative == 0)
                                {
                                    SearchResults.Items.Add(student.Name + " (" + student.PupilID + ")");
                                }
                            }
                            break;
                    }
                }
                else
                {
                    foreach (Pupil student in unDatedPupils)
                    {
                        SearchResults.Items.Add(student.Name + " (" + student.PupilID + ")");
                    }
                }

                // then, check if listbox is empty after function is finished
                if (SearchResults.Items.Count == 0) SearchResults.Items.Add("No students were found.");

                // switch cursor back to normal
                Cursor.Current = Cursors.Default;

            };
        }

        // function used to compare string dates
        private static int compareDates(String selectedDate, String lastAccessDate)
        {

            lastAccessDate = DateTime.ParseExact(lastAccessDate, "yyyy-MM-ddTHH:mm:ss.s", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");

            string[] selectedStrArray = selectedDate.Split('-');
            string[] accessStrArray = lastAccessDate.Split('-');

            int[] selectedIntArray = new int[3];
            int[] accessIntArray = new int[3];

            for (int i = 0; i < 3; i++)
            {
                selectedIntArray[i] = int.Parse(selectedStrArray[i]);
                accessIntArray[i] = int.Parse(accessStrArray[i]);
            }

            // Compare years
            if (selectedIntArray[2] > accessIntArray[2]) return 1;
            if (selectedIntArray[2] < accessIntArray[2]) return -1;
            // Compare months
            if (selectedIntArray[1] > accessIntArray[1]) return 1;
            if (selectedIntArray[1] < accessIntArray[1]) return -1;
            // Compare days
            if (selectedIntArray[0] > accessIntArray[0]) return 1;
            if (selectedIntArray[0] == accessIntArray[0]) return 0;
            if (selectedIntArray[0] < accessIntArray[0]) return -1;

            // if all else fails, which it won't...
            return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FadeEffect.FadeIn(this, 100);

            ignoreReloads = true;
            // initialise filter drop down
            ComboBoxYearGroup.SelectedIndex = 0;
            filterDropDownToggle = false;
            dropDownBack.Size = new Size(200, 10);
            dropDownBack.Location = new Point(12, 138); // resets back to default position, incase it has been moved in editing
            dropDownBack.Visible = false;
            // initialise sort drop down
            updateSortDisplay();
            sortDropDownToggle = false;
            sortDropDownBack.Size = new Size(111, 10);
            sortDropDownBack.Location = new Point(87, 138);
            sortDropDownBack.Visible = false;
            // Wipes DateTimePicker display
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = " ";
            ComboBoxContext.SelectedIndex = 0;
            ignoreReloads = false;

            reloadPupils();

        }

        // run whenever the form opens the data for the active student
        // note: next form uses selected listbox item to isolate activeStudent
        private void openActiveStudentForm()
        {
            ProfileEditView infoForm = new ProfileEditView();
            infoForm.searchForm = this;
            infoForm.ShowDialog();
            reloadPupils();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {

            // checks for either a pupil not being selected, or if someone's being cheeky and selected the text that shows up when no students match the search
            if (SearchResults.GetItemText(SearchResults.SelectedItem) != "No students were found." && SearchResults.SelectedIndex != -1)
            {
                openActiveStudentForm();
            }
            else
            {
                MessageBox.Show("Please select the student you wish to view.", "No student selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // functions that control the opening and closing of drop down panels
        private void toggleFilterDropDown()
        {
            filterDropDownToggle = !filterDropDownToggle;

            if (filterDropDownToggle)
            {
                ButtonFilterDropDown.Text = "▲";
                dropDownBack.Height = 10;
                dropDownBack.Visible = true;
            }
            else
            {
                ButtonFilterDropDown.Text = "▼";
                dropDownBack.Height = dropDownBack.MaximumSize.Height;
            }

            dropdownTimerFilter.Start();
        }

        private void toggleSortDropDown()
        {
            sortDropDownToggle = !sortDropDownToggle;

            if (sortDropDownToggle)
            {
                buttonSortDropDown.Text = "▲";
                sortDropDownBack.Height = 10;
                sortDropDownBack.Visible = true;
            }
            else
            {
                buttonSortDropDown.Text = "▼";
                sortDropDownBack.Height = sortDropDownBack.MaximumSize.Height;
            }

            dropdownTimerSort.Start();
        }

        private void dropdownTimerFilter_Tick(object sender, EventArgs e)
        {
            if (filterDropDownToggle)
            {
                dropDownBack.Height += 30;
                if (dropDownBack.Height == dropDownBack.MaximumSize.Height)
                {
                    dropdownTimerFilter.Stop();
                }
            }
            else
            {
                dropDownBack.Height -= 30;
                if (dropDownBack.Height == 10)
                {
                    dropdownTimerFilter.Stop();
                    dropDownBack.Visible = false;
                }
            }
        }

        private void dropdownTimerSort_Tick(object sender, EventArgs e)
        {
            if (sortDropDownToggle)
            {
                sortDropDownBack.Height += 10;
                if (sortDropDownBack.Height == sortDropDownBack.MaximumSize.Height)
                {
                    dropdownTimerSort.Stop();
                }
            }
            else
            {
                sortDropDownBack.Height -= 10;
                if (sortDropDownBack.Height == 10)
                {
                    dropdownTimerSort.Stop();
                    sortDropDownBack.Visible = false;
                }
            }
        }

        private void ButtonFilterDropDown_Click(object sender, EventArgs e)
        {
            toggleFilterDropDown();
        }

        private void buttonSortDropDown_Click(object sender, EventArgs e)
        {
            toggleSortDropDown();
        }

        // functions to handle updating sort display
        private void updateSortDisplay()
        {
            switch (sortType.Type)
            {
                case "Alphabetical":
                    labelSortType.Text = "Alphabetical";
                    sortDisplayAlpha.Visible = true;
                    sortDisplayYearGroup.Visible = sortDisplayAccessTime.Visible = false;
                    if (sortType.Reverse) sortDisplayAlpha.Text = "ᐱ";
                    else sortDisplayAlpha.Text = "ᐯ";
                    break;
                case "YearGroup":
                    labelSortType.Text = "Year Group";
                    sortDisplayYearGroup.Visible = true;
                    sortDisplayAccessTime.Visible = sortDisplayAlpha.Visible = false;
                    if (sortType.Reverse) sortDisplayYearGroup.Text = "ᐱ";
                    else sortDisplayYearGroup.Text = "ᐯ";
                    break;
                case "LastAccess":
                    labelSortType.Text = "Last Access";
                    sortDisplayAccessTime.Visible = true;
                    sortDisplayAlpha.Visible = sortDisplayYearGroup.Visible = false;
                    if (sortType.Reverse) sortDisplayAccessTime.Text = "ᐱ";
                    else sortDisplayAccessTime.Text = "ᐯ";
                    break;
                default:
                    throw new Exception("Tried to update sort display with invalid type");
            }
            reloadPupils();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            switch (control.Name)
            {
                case "sortAlpha":
                    if (sortType.Type == "Alphabetical") sortType.Reverse = !sortType.Reverse;
                    else
                    {
                        sortType.Type = "Alphabetical";
                        sortType.Reverse = false;
                    }
                    break;
                case "sortYear":
                    if (sortType.Type == "YearGroup") sortType.Reverse = !sortType.Reverse;
                    else
                    {
                        sortType.Type = "YearGroup";
                        sortType.Reverse = false;
                    }
                    break;
                case "sortAccessTime":
                    if (sortType.Type == "LastAccess") sortType.Reverse = !sortType.Reverse;
                    else
                    {
                        sortType.Type = "LastAccess";
                        sortType.Reverse = false;
                    }
                    break;
                default:
                    throw new Exception("sortButton_Click function was called wrongly");
            }

            updateSortDisplay();
        }

        // User search feature
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (DateTimePicker.Value == DateTimePicker.MinimumDateTime)
            {
                DateTimePicker.Value = DateTime.Now; // This is required in order to show current month/year when user reopens the date popup.
                DateTimePicker.Format = DateTimePickerFormat.Custom;
                DateTimePicker.CustomFormat = " ";
            }
            else
            {
                DateTimePicker.Format = DateTimePickerFormat.Short;
            }

            if (ComboBoxContext.SelectedIndex == 0 && DateTimePicker.Format != DateTimePickerFormat.Custom) ComboBoxContext.SelectedIndex = 2; // defaults to "from", if not set

            reloadPupils();
        }

        private void ComboBoxContext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxContext.SelectedIndex != 0 && DateTimePicker.Format == DateTimePickerFormat.Custom) DateTimePicker.Value = DateTime.Now; // defaults to current date, if not set
            if (ComboBoxContext.SelectedIndex == 0 && DateTimePicker.Format != DateTimePickerFormat.Custom)
            {
                DateTimePicker.Format = DateTimePickerFormat.Custom;
                DateTimePicker.CustomFormat = " ";
            }

            reloadPupils();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {

            ignoreReloads = true;
            SearchBar.Text = "";
            CheckBoxA2E.Checked = false;
            CheckBoxStruggling.Checked = false;
            ComboBoxYearGroup.SelectedIndex = 0;
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = " ";
            ComboBoxContext.SelectedIndex = 0;
            ignoreReloads = false;
            reloadPupils();
            SystemSounds.Beep.Play();

        }

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {

            activeStudent = new Pupil("", "", "", false, "", false, Pupil.YearGroups.S1, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s"), new List<Note>() { }, new List<TodoEntry>() { });

            ProfileViewEdit editForm = new ProfileViewEdit();
            editForm.recordsForm = this;

            editForm.ShowDialog();

            // then, on close of this form
            if (activeStudent.PupilID != "")
            {
                reloadPupils();
                // select newly created student in listbox
                for (int i = 0; i < SearchResults.Items.Count; i++)
                {
                    if (SearchResults.Items[i].ToString() == activeStudent.Name + " (" + activeStudent.PupilID + ")")
                    {
                        SearchResults.SelectedIndex = i;
                        i = SearchResults.Items.Count;
                    };
                }
                // open newly created student
                openActiveStudentForm();
            };
   
        }

        private void ButtonDeleteStudent_Click(object sender, EventArgs e)
        {

            if (SearchResults.GetItemText(SearchResults.SelectedItem) != "No students were found." && SearchResults.SelectedIndex != -1)
            {
                SystemSounds.Hand.Play();
                if ((MessageBox.Show("Are you sure you want to delete this student? Their information and notes will not be retrievable.", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    string Text = SearchResults.GetItemText(SearchResults.SelectedItem);
                    int Index = Text.LastIndexOf("(");
                    string PupilID = Text.Substring(Index + 1, Text.Length - 2 - Index);
                    Mgr.DeletePupilData(Mgr.GetPupilsByProperties(new {PupilID = PupilID})[0]);
                    this.reloadPupils();
                    SystemSounds.Beep.Play();
                }
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Please select the student you wish to delete.", "No student selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // SHORTCUTS (alternate ways of triggering same code)

        private void SearchResults_MouseDoubleClick (object sender, EventArgs e)
        {
            ViewButton_Click(sender, e);
        }

        private void QuickDisplayUpdateEvent(object sender, EventArgs e)
        {

            reloadPupils();

        }

        private void SearchResults_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = SearchResults.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                SearchResults.SelectedIndex = index;
                ContextMenuStudent.Show(Cursor.Position);
                ContextMenuStudent.Visible = true;
            }
            else
            {
                ContextMenuStudent.Visible = false;
            }
        }

    }
}
