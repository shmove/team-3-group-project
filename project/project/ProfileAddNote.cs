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
    public partial class ProfileAddNote : Form
    {

        public ProfileEditView profileForm;

        public ProfileAddNote()
        {
            InitializeComponent();
        }

        private void ProfileAddNote_Load(object sender, EventArgs e)
        {
            // Changes window title
            this.Text = profileForm.activeStudent.Name + " - Add Note";
        }

        private void ButtonAddNote_Click(object sender, EventArgs e)
        {
            // I'd really like to make newlines possible here, but it doesn't seem like that's gonna happen :(
            string newNote = TextBoxNote.Text.Replace("\r", " ").Replace("\n", "");
            string currentDate = DateTime.Now.ToString("d/M/yyyy").Replace("/","-");
            bool groupFound = false;

            for (int i = 0; i < profileForm.activeStudent.Notes.Count; i++)
            {
                if (currentDate == profileForm.activeStudent.Notes[i].Date)
                {
                    groupFound = true;
                    profileForm.activeStudent.Notes[i].NotesList.Add(newNote);
                }
            }

            if (!groupFound)
            {
                // TODO
                // Add note into student object, in new group with date (or alternate db setup)
                // TODO
            }

            // Write new info to disk
            PupilFileManager Mgr = new PupilFileManager(profileForm.searchForm.dataDir);

            Mgr.WritePupilData(profileForm.activeStudent);

            this.Close();

        }
    }
}
