using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static project.PupilDataManager.SharedResources.Types;

namespace project
{
    public partial class ProfileEditView : Form
    {

        public pupilRecords searchForm; // all data from parent form
        public string activeUUID; // stores pupil UUID for easier referencing of pupil
        public Pupil activeStudent; // stores student data that is currently being accessed
        public String noteContext; // for access of the note editing context (ie add/edit)
        private DbPupilDataManager Mgr; // instance of pupildatamanager

        public ProfileEditView()
        {
            InitializeComponent();
        }

        // WINDOW CONTROL BAR

        private void PanelWindowControls_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.DragWindow(e, this);
        }

        private void PanelWindowClose_MouseHover(object sender, EventArgs e)
        {
            TitleBarControl.HoverButton(PanelWindowClose);
        }

        private void PanelWindowClose_MouseLeave(object sender, EventArgs e)
        {
            TitleBarControl.LeaveButton(PanelWindowClose);
        }

        private void PanelWindowClose_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.MouseDownButton(e, new Action(() =>
            {
                FadeEffect.FadeOut(this, 100, new Action(() => this.Close()));
            }));
        }

        private void PanelWindowMinimise_MouseHover(object sender, EventArgs e)
        {
            TitleBarControl.HoverButton(PanelWindowMinimise);
        }

        private void PanelWindowMinimise_MouseLeave(object sender, EventArgs e)
        {
            TitleBarControl.LeaveButton(PanelWindowMinimise);
        }

        private void PanelWindowMinimise_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.MouseDownButton(e, new Action(() =>
            {
                FadeEffect.FadeOut(this, 100, new Action(() => this.WindowState = FormWindowState.Minimized));
            }));

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            TitleBarControl.Unminimise(this);
        }


        // FORM CODE

        // run when form is first loaded - saves pupil uuid for referencing and loads pupil data
        private void ProfileEditView_Load(object sender, EventArgs e)
        {

            VisualThemes.ToDarkTheme(this);
            FadeEffect.FadeIn(this, 100);

            Mgr = searchForm.Mgr;

            // save student info to activeStudent and update activeUUID
            string[] highlightedField = ((pupilRecords)searchForm).SearchResults.GetItemText(((pupilRecords)searchForm).SearchResults.SelectedItem).Split('(');

            string studentID = highlightedField[1].Trim('(', ' ', ')'); // Isolates pupilID from substring array

            // gets student data from pupilID displayed in previous form's listbox
            List<Pupil> students = Mgr.GetPupilsByProperties(new { PupilID = studentID });
            activeStudent = students[0];

            activeUUID = activeStudent.PupilUUID;

            // Wipes DateTimePicker display
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = " ";
            ComboBoxContext.SelectedIndex = -1;

            loadStudentInfo(); // update display
            populateNotes();

        }

        // overwrites activeStudent with most recent data
        private void updateActiveStudent()
        {

            List<Pupil> students = Mgr.GetPupilsByProperties(new { PupilUUID = activeUUID });
            activeStudent = students[0];

        }

        // updates display with activeStudent info
        private void loadStudentInfo()
        {
            this.Text = activeStudent.Name + " (" + activeStudent.PupilID + ") - Info";
            LabelStudentName.Text = activeStudent.Name;
            LabelStudentNo.Text = activeStudent.PupilID;
            LabelCompany.Text = activeStudent.Company;
            LabelYearGroup.Text = activeStudent.YearGroup.ToString();

            if (activeStudent.A2E)
            {
                LabelGroups.Text = "A2E";
                LabelGroups.Visible = true;
            }
            else
            {
                LabelGroups.Visible = false;
            }

            if (activeStudent.Struggling)
            {
                ImageFlag.Visible = true;
                LabelStruggling.Visible = true;
            }
            else
            {
                ImageFlag.Visible = false;
                LabelStruggling.Visible = false;
            }

            StudentPhoto.Image = Mgr.GetPupilImage(activeStudent);
        }

        // updates notes display with all notes attached to activeStudent
        private void populateNotes()
        {
            SearchResults.Items.Clear();
            foreach (Note i_Note in activeStudent.Notes)
            {
                SearchResults.Items.Add(i_Note.Text + " [" + i_Note.Date + "]");
            }

            if (SearchResults.Items.Count == 0) SearchResults.Items.Add("No notes were found.");
        }

        // function used to compare string dates for sorting notes
        private static int compareDates(String selectedDate, String noteDate)
        {
            string[] selectedStrArray = selectedDate.Split('-');
            string[] noteStrArray = noteDate.Split('-');

            int[] selectedIntArray = new int[3];
            int[] noteIntArray = new int[3];

            for (int i = 0; i < 3; i++)
            {
                selectedIntArray[i] = int.Parse(selectedStrArray[i]);
                noteIntArray[i] = int.Parse(noteStrArray[i]);
            }

            // Compare years
            if (selectedIntArray[2] > noteIntArray[2]) return 1;
            if (selectedIntArray[2] < noteIntArray[2]) return -1;
            // Compare months
            if (selectedIntArray[1] > noteIntArray[1]) return 1;
            if (selectedIntArray[1] < noteIntArray[1]) return -1;
            // Compare days
            if (selectedIntArray[0] > noteIntArray[0]) return 1;
            if (selectedIntArray[0] == noteIntArray[0]) return 0;
            if (selectedIntArray[0] < noteIntArray[0]) return -1;

            // if all else fails, which it won't...
            return 0;
        }

        private void searchNotes()
        {

            // Only display notes from the date selected in the DateTimePicker on clicking this button
            // Dates are formatted in file as: 1-1-2021
            string selectedDate = DateTimePicker.Value.Day.ToString() + "-" + DateTimePicker.Value.Month.ToString() + "-" + DateTimePicker.Value.Year.ToString();

            SearchResults.Items.Clear();

            switch (ComboBoxContext.SelectedIndex)
            {
                case 0:
                    // all notes AFTER specified date
                    foreach (Note i_Note in activeStudent.Notes)
                    {
                        int relative = compareDates(selectedDate, i_Note.Date);
                        if (relative == 1 || relative == 0)
                        {
                            SearchResults.Items.Add(i_Note.Text + " [" + i_Note.Date + "]");
                        }
                    }
                    break;
                case 1:
                    // all notes FROM specified date
                    foreach (Note i_Note in activeStudent.Notes)
                    {
                        int relative = compareDates(selectedDate, i_Note.Date);
                        if (relative == 0)
                        {
                            SearchResults.Items.Add(i_Note.Text);
                        }
                    }
                    break;
                case 2:
                    // all notes BEFORE specified date
                    foreach (Note i_Note in activeStudent.Notes)
                    {
                        int relative = compareDates(selectedDate, i_Note.Date);
                        if (relative == -1 || relative == 0)
                        {
                            SearchResults.Items.Add(i_Note.Text + " [" + i_Note.Date + "]");
                        }
                    }
                    break;
            }

            if (SearchResults.Items.Count == 0) SearchResults.Items.Add("No notes were found.");

        }

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
                DateTimePicker.Format = DateTimePickerFormat.Long;
            }

            if (ComboBoxContext.SelectedIndex == -1) ComboBoxContext.SelectedIndex = 1; // defaults to "from", if not set

            searchNotes(); // reloads notes based off of search
        }

        private void ComboBoxContext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxContext.SelectedIndex != -1 && DateTimePicker.Format == DateTimePickerFormat.Custom) DateTimePicker.Value = DateTime.Now; // defaults to current date, if not set

            searchNotes();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            DateTimePicker.Value = DateTimePicker.MinimumDateTime;
            ComboBoxContext.SelectedIndex = -1;
            // Reload all notes
            populateNotes();
        }

        private void ButtonAddNote_Click(object sender, EventArgs e)
        {
            ProfileAddNote addNote = new ProfileAddNote();
            noteContext = "add"; // lets the next form know that we are adding and not editing a note
            addNote.profileForm = this;
            addNote.ShowDialog();

            // then, on close of this form
            updateActiveStudent();
            populateNotes();
        }

        private void ButtonEditNote_Click(object sender, EventArgs e)
        {
            if (SearchResults.GetItemText(SearchResults.SelectedItem) != "No notes were found." && SearchResults.SelectedIndex != -1)
            {
                ProfileAddNote addNote = new ProfileAddNote();
                noteContext = "edit"; // lets the next form know that we are editing and not adding a note
                addNote.profileForm = this;
                addNote.ShowDialog();

                // then, on close of this form
                updateActiveStudent();
                populateNotes();
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Please select the note you wish to edit.", "No note selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ButtonEditInfo_Click(object sender, EventArgs e)
        {
            ProfileViewEdit editForm = new ProfileViewEdit();
            editForm.pupilForm = this;

            // unloads image to prevent read/write errors
            var openedFile = StudentPhoto.Image;
            StudentPhoto.Image = null;
            openedFile.Dispose();
            ImageBoxPlaceholder.Visible = true;
            StudentPhoto.Visible = false;

            editForm.ShowDialog();

            // then, on close of this form
            ImageBoxPlaceholder.Visible = false;
            StudentPhoto.Visible = true;
            updateActiveStudent(); // updates student data
            loadStudentInfo();
        }

        private void ButtonDeleteNote_Click(object sender, EventArgs e)
        {
            if (SearchResults.GetItemText(SearchResults.SelectedItem) != "No notes were found." && SearchResults.SelectedIndex != -1)
            {
                SystemSounds.Hand.Play();
                if ((MessageBox.Show("Are you sure you want to delete this note?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    activeStudent.Notes.RemoveAt(SearchResults.SelectedIndex);
                    Mgr.WritePupilData(activeStudent);
                    populateNotes();
                    SystemSounds.Beep.Play();
                }
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Please select the note you wish to delete.", "No note selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LabelGroups_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeStudent.A2E)
            {
                toolTip1.SetToolTip(LabelGroups, activeStudent.A2EDescription); // displays A2EDescription when hovering over the A2E text
            }    
        }

        // context menus
        private void SearchResults_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = SearchResults.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                SearchResults.SelectedIndex = index;
                ContextMenuNote.Show(Cursor.Position);
                ContextMenuNote.Visible = true;
            }
            else
            {
                ContextMenuNote.Visible = false;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SearchResults.SelectedItem.ToString());
        }

        // SHORTCUTS (alternate ways of triggering same code)
        private void SearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ButtonEditNote_Click(sender, e);
        }

        private void StudentPhoto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ButtonEditInfo_Click(sender, e);
        }

        // CUSTOM DRAW METHODS

        // https://stackoverflow.com/a/3663856
        private void SearchResults_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          VisualThemes.GetThemeColor(8, 1)); //Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            Brush txtColorBrush = new SolidBrush(VisualThemes.GetThemeColor(0, 1));
            e.Graphics.DrawString(SearchResults.Items[e.Index].ToString(), e.Font, txtColorBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();

            txtColorBrush.Dispose();
        }

        private void ComboBoxContext_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          VisualThemes.GetThemeColor(8, 1)); //Choose the color

            e.DrawBackground(); // draw back
            e.Graphics.DrawString(ComboBoxContext.Items[e.Index].ToString(), e.Font, new SolidBrush(VisualThemes.GetThemeColor(0, 1)), e.Bounds, StringFormat.GenericDefault); // draw text
        }

    }
}
