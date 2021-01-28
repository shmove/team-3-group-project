using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class ProfileEditView : Form
    {

        public pupilRecords searchForm;
        private Pupil activeStudent;

        public ProfileEditView()
        {
            InitializeComponent();
        }

        private static void populateNotes(ListBox SearchResults, Pupil activeStudent)
        {
            SearchResults.Items.Clear();
            foreach (Notes noteGroup in activeStudent.Notes) {
                foreach (string note in noteGroup.NotesList)
                {
                    SearchResults.Items.Add(note + " [" + noteGroup.Date + "]");
                }
            }
        }

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

        private void ProfileEditView_Load(object sender, EventArgs e)
        {

            ComboBoxContext.SelectedIndex = 0; // set default selection

            PupilFileManager Mgr = new PupilFileManager(searchForm.dataDir);

            string[] highlightedField = ((pupilRecords)searchForm).SearchResults.GetItemText(((pupilRecords)searchForm).SearchResults.SelectedItem).Split('(');

            string studentName = highlightedField[0].Trim(); // Gets pupil name from substring array, removing trailing space
            string studentID = highlightedField[1].Trim('(',' ', ')');

            Console.WriteLine("studentName: '" + studentName + "'");
            Console.WriteLine("studentID: '" + studentID + "'");

            // When searching by id, the correct student will always be able to be accessed through students[0]
            List <Pupil> students = Mgr.GetPupilsByProperties(new { Name = studentName }); // Replace with ID, when implemented

            // saves student info globally (locally? global to this form at least. idk how c# works) so it can be accessed by other form events
            activeStudent = students[0];

            this.Text = activeStudent.Name + " - Info"; // this.Text = activeStudent.Name + "(" + activeStudent.id + ") - Info";
            LabelStudentName.Text = activeStudent.Name;
            // LabelStudentNo.Text = activeStudent.id;
            LabelCompany.Text = activeStudent.Company;

            string groups = "";
            if (activeStudent.A2E) groups += "A2E, ";
            // additional groups go here
            groups = groups.Trim(',', ' ');
            if (groups == "") LabelGroups.Visible = false;
            else LabelGroups.Text = groups;

            populateNotes(SearchResults, activeStudent);

            try
            {
                StudentPhoto.Image = Image.FromFile($@"{searchForm.dataDir}\Pupil_{studentName}\{activeStudent.ImgRef}");
                // StudentPhoto.Image = Image.FromFile($@"{searchForm.dataDir}\Pupil{studentID}_{studentName}\{activeStudent.ImgRef}")
            }
            catch (Exception err)
            {
                // This usually means a picture hasn't been set, but write to console just in case
                Console.WriteLine(err);
                StudentPhoto.Image = Image.FromFile($@"{searchForm.dataDir}\default.jpg");
            }

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {

            // Only display notes from the date selected in the DateTimePicker on clicking this button
            // Dates are formatted in file as: 1-1-2021
            string selectedDate = DateTimePicker.Value.Day.ToString() + "-" + DateTimePicker.Value.Month.ToString() + "-" + DateTimePicker.Value.Year.ToString();

            SearchResults.Items.Clear();

            switch (ComboBoxContext.SelectedIndex)
            {
                case 0:
                    // all notes AFTER specified date
                    foreach (Notes noteGroup in activeStudent.Notes)
                    {
                        int relative = compareDates(selectedDate, noteGroup.Date);
                        if (relative == 1 || relative == 0)
                        {
                            foreach (string note in noteGroup.NotesList)
                            {
                                SearchResults.Items.Add(note + " [" + noteGroup.Date + "]");
                            }
                        }
                    }
                    break;
                case 1:
                    // all notes FROM specified date
                    foreach (Notes noteGroup in activeStudent.Notes)
                    {
                        int relative = compareDates(selectedDate, noteGroup.Date);
                        if (relative == 0)
                        {
                            foreach (string note in noteGroup.NotesList)
                            {
                                SearchResults.Items.Add(note);
                            }
                        }
                    }
                    break;
                case 2:
                    // all notes BEFORE specified date
                    foreach (Notes noteGroup in activeStudent.Notes)
                    {
                        int relative = compareDates(selectedDate, noteGroup.Date);
                        if (relative == -1 || relative == 0)
                        {
                            foreach (string note in noteGroup.NotesList)
                            {
                                SearchResults.Items.Add(note + " [" + noteGroup.Date + "]");
                            }
                        }
                    }
                    break;
            }

            if (SearchResults.Items.Count == 0) SearchResults.Items.Add("No notes on this date.");

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {

            // Reload all notes
            populateNotes(SearchResults, activeStudent);

        }
    }
}
