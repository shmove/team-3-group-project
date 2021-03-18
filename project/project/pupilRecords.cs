using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Pupil activeStudent; // for accessing when creating a new student

        private void reloadPupils()
        {

            List<Pupil> Pupils;

            // FILTERS
            // This can definitely be done better. 
            // This looks fine for now, but on adding more filters it's gonna get a lot worse.
            // Spent a few hours looking into objects in c# and can't figure out a better way to initialise a property ONLY if a condition is met,
            // so spiralling If statement is the only solution I could come up with. soz xoxo
            if (CheckBoxA2E.Checked)
            {
                Pupils = Mgr.GetPupilsByProperties(new { A2E = true });
            } else
            {
                Pupils = Mgr.GetPupilsByProperties(new { });
            }

            // wipes listbox
            SearchResults.Items.Clear();

            // NAME / ID SEARCH
            // if first char is number, assume user is searching by id
            if (SearchBar.Text != "")
            {
                if (Char.IsNumber(SearchBar.Text[0]))
                {
                    foreach (Pupil pupil in Pupils)
                    {
                        if (pupil.PupilID.StartsWith(SearchBar.Text.Trim())) SearchResults.Items.Add(pupil.Name + " (" + pupil.PupilID + ")");
                    }
                }
                else // this feels like yanderedev code
                {
                    foreach (Pupil pupil in Pupils)
                    {
                        if (pupil.Name.ToLower().Contains(SearchBar.Text.Trim().ToLower())) SearchResults.Items.Add(pupil.Name + " (" + pupil.PupilID + ")");
                    }
                }
            }
            else
            {
                foreach (Pupil pupil in Pupils)
                {
                    SearchResults.Items.Add(pupil.Name + " (" + pupil.PupilID + ")");
                }
            }

            // then, check if listbox is empty after function is finished
            if (SearchResults.Items.Count == 0) SearchResults.Items.Add("No students were found.");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            reloadPupils();

        }

        private void ViewButton_Click(object sender, EventArgs e)
        {

            // checks for either a pupil not being selected, or if someone's being cheeky and selected the text that shows up when no students match the search
            if (SearchResults.GetItemText(SearchResults.SelectedItem) != "No students were found." && SearchResults.SelectedIndex != -1)
            {
                ProfileEditView infoForm = new ProfileEditView();
                infoForm.searchForm = this;
                this.Hide();
                infoForm.ShowDialog();
                this.Show();
                reloadPupils();
            }
            else
            {
                MessageBox.Show("Please select the student you wish to view.", "No student selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // User search feature
        private void SearchButton_Click(object sender, EventArgs e)
        {

            reloadPupils();

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {

            SearchBar.Text = "";
            CheckBoxA2E.Checked = false;
            reloadPupils();

        }

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {

            activeStudent = Mgr.GetTestCases(1)[0];

            ProfileViewEdit editForm = new ProfileViewEdit();
            editForm.recordsForm = this;

            this.Hide();
            editForm.ShowDialog();

            // then, on close of this form
            this.Show();
            reloadPupils();

        }

        private void ButtonDeleteStudent_Click(object sender, EventArgs e)
        {

            if (SearchResults.GetItemText(SearchResults.SelectedItem) != "No students were found." && SearchResults.SelectedIndex != -1)
            {
                if ((MessageBox.Show("Are you sure you want to delete this student? Their information and notes will not be retrievable.", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    string Text = SearchResults.GetItemText(SearchResults.SelectedItem);
                    int Index = Text.LastIndexOf("(");
                    string PupilID = Text.Substring(Index + 1, Text.Length - 2 - Index);
                    Mgr.DeletePupilData(Mgr.GetPupilsByProperties(new {PupilID = PupilID})[0]);
                    this.reloadPupils();
                }
            }
            else
            {
                MessageBox.Show("Please select the student you wish to delete.", "No student selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CheckBoxA2E_CheckedChanged(object sender, EventArgs e)
        {

            reloadPupils();

        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {

            // This is a super slick feature but I don't know if I should include it, purely for performance reasons.
            // reloadPupils();

        }


        // SHORTCUTS (alternate ways of triggering same code)

        private void SearchResults_MouseDoubleClick (object sender, EventArgs e)
        {
            ViewButton_Click(sender, e);
        }
    }
}
