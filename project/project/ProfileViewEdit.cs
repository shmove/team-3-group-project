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
        public bool imgChanged = false;

        public ProfileViewEdit()
        {
            InitializeComponent();
        }

        private void reloadImage(string customDir)
        {

            PupilFileManager Mgr = new PupilFileManager($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\..\Local\PupilRecordsProgram\Pupils\");

            if (customDir == "")
            {
                StudentImage.Image = Mgr.GetPupilImage(pupilForm.activeStudent);
            }
            else
            {
                StudentImage.Image = Image.FromFile(customDir);
            }
        }

        private void ProfileViewEdit_Load(object sender, EventArgs e)
        {

            // Loads current student data into display
            this.Text = pupilForm.activeStudent.Name + " (" + pupilForm.activeStudent.PupilID + ") - Edit";

            TextBoxName.Text = pupilForm.activeStudent.Name;
            TextBoxStudentID.Text = pupilForm.activeStudent.PupilID;
            TextBoxCompany.Text = pupilForm.activeStudent.Company;
            CheckBoxA2E.Checked = pupilForm.activeStudent.A2E;

            reloadImage("");

        }

        private void ButtonChangeImage_Click(object sender, EventArgs e)
        {

            // unloads image to prevent read/write errors
            var openedFile = StudentImage.Image;
            StudentImage.Image = null;
            openedFile.Dispose();

            OpenFileDialog openImageDialog = new OpenFileDialog();

            openImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openImageDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";
            openImageDialog.FilterIndex = 0;
            openImageDialog.RestoreDirectory = true;

            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                reloadImage(openImageDialog.FileName);
                imgChanged = true;
            };
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

            PupilFileManager Mgr = new PupilFileManager($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\..\Local\PupilRecordsProgram\Pupils\");

            pupilForm.activeStudent.Name = TextBoxName.Text;
            pupilForm.activeStudent.PupilID = TextBoxStudentID.Text;
            pupilForm.activeStudent.Company = TextBoxCompany.Text;
            pupilForm.activeStudent.A2E = CheckBoxA2E.Checked;

            if (imgChanged)
            {
                Mgr.SavePupilImage(pupilForm.activeStudent, StudentImage.Image);
            }

            Mgr.WritePupilData(pupilForm.activeStudent);

            this.Close();
        }
    }
}
