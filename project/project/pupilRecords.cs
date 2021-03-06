﻿using System;
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

        public pupilRecords()
        {
            InitializeComponent();
        }

        private DbPupilDataManager Mgr;

        private void reloadPupils()
        {

            Mgr = new DbPupilDataManager();

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
    }
}
