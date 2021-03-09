using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static project.PupilDataManager.SharedResources.Types;

namespace project
{
    public partial class ProfileViewEdit : Form
    {

        public ProfileEditView pupilForm;
        public pupilRecords recordsForm;
        public bool imgChanged = false;
        public Pupil activeStudent;

        public ProfileViewEdit()
        {
            InitializeComponent();
        }

        private void reloadImage(string customDir)
        {

            PupilFileManager Mgr = new PupilFileManager($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\..\Local\PupilRecordsProgram\Pupils\");

            if (customDir == "")
            {
                StudentImage.Image = Mgr.GetPupilImage(activeStudent);
            }
            else
            {
                StudentImage.Image = Image.FromFile(customDir);
            }
        }

        private void ProfileViewEdit_Load(object sender, EventArgs e)
        {

            if (pupilForm != null)
            {

                // creates local variable for ease of use with both contexts (create + edit)
                activeStudent = pupilForm.activeStudent;

                // Loads current student data into display
                this.Text = activeStudent.Name + " (" + activeStudent.PupilID + ") - Edit";

                TextBoxName.Text = activeStudent.Name;
                TextBoxStudentID.Text = activeStudent.PupilID;
                TextBoxCompany.Text = activeStudent.Company;
                CheckBoxA2E.Checked = activeStudent.A2E;

                reloadImage("");
            }
            else
            {

                // creates local variable for ease of use with both contexts (create + edit)
                activeStudent = recordsForm.activeStudent;

                this.Text = "New Student - Edit";
                reloadImage("");

            };

        }

        private void ButtonChangeImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog openImageDialog = new OpenFileDialog();

            openImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openImageDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";
            openImageDialog.FilterIndex = 0;
            openImageDialog.RestoreDirectory = true;

            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                // unloads image to prevent read/write errors
                var openedFile = StudentImage.Image;
                StudentImage.Image = null;
                openedFile.Dispose();

                reloadImage(openImageDialog.FileName);
                imgChanged = true;
            };
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

            if (TextBoxStudentID.Text == "" | TextBoxName.Text == "")
            {
                MessageBox.Show("Please ensure both student name and ID are provided. These are required fields.", "Insufficient info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DbPupilDataManager Mgr = new DbPupilDataManager();

                activeStudent.Name = TextBoxName.Text;
                activeStudent.PupilID = TextBoxStudentID.Text;
                activeStudent.Company = TextBoxCompany.Text;
                activeStudent.A2E = CheckBoxA2E.Checked;

                if (imgChanged)
                {
                    Mgr.SavePupilImage(activeStudent, StudentImage.Image);
                }

                Mgr.WritePupilData(activeStudent);

                // writes back to parent form
                if (pupilForm != null) pupilForm.activeStudent = activeStudent;
                else recordsForm.activeStudent = activeStudent;

                this.Close();

            }
            
        }
    }
}
