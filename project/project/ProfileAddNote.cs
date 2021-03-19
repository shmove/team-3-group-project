using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static project.PupilDataManager.SharedResources.Types;

namespace project
{
    public partial class ProfileAddNote : Form
    {

        public ProfileEditView profileForm;
        private String initialNote; // for editing notes
        private String initialDate;
        private DbPupilDataManager Mgr;

        public ProfileAddNote()
        {
            InitializeComponent();
        }

        private void ProfileAddNote_Load(object sender, EventArgs e)
        {

            Mgr = profileForm.searchForm.Mgr; // loads DBPupilDataManager

            // Changes window title
            switch (profileForm.noteContext)
            {
                case "add":
                    this.Text = profileForm.activeStudent.Name + " - Add Note";
                    break;
                case "edit":
                    this.Text = profileForm.activeStudent.Name + " - Edit Note";

                    // split text of selected item
                    string[] selectedItem = ((ProfileEditView)profileForm).SearchResults.GetItemText(((ProfileEditView)profileForm).SearchResults.SelectedItem).Split('[');

                    // founder.Remove(founder.Length - 1, 1);
                    initialNote = selectedItem[0].Remove(selectedItem[0].Length - 1, 1);
                    initialDate = selectedItem[1].Trim(' ', ']');

                    TextBoxNote.Text = initialNote;
                    break;
            }
        }

        private void ButtonAddNote_Click(object sender, EventArgs e)
        {
            // I'd really like to make newlines possible here, but it doesn't seem like that's gonna happen :(
            string newNote = TextBoxNote.Text.Replace("\r", " ").Replace("\n", "");

            switch (profileForm.noteContext)
            {
                case "add":
                    string currentDate = DateTime.Now.ToString("d-M-yyyy");
                    profileForm.activeStudent.Notes.Add(new Note(currentDate, newNote));

                    break;
                case "edit":
                    // iterates through notes and overwrites initial note (probably could be done better)
                    bool Found = false;
                    foreach(Note i_Note in profileForm.activeStudent.Notes) if(i_Note.Text == initialNote){
                        i_Note.Text = newNote;
                        Found = true;
                        break;
                    }
                    if(!Found) throw new Exception("The specified note wasn't found.");
                    break;
            }

            profileForm.activeStudent.LastAccess = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s"); // updates last accessed time

            // Write new info to db
            Mgr.WritePupilData(profileForm.activeStudent);
            SystemSounds.Beep.Play();

            this.Close();

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
