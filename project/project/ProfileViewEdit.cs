using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
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
        private DbPupilDataManager Mgr;

        public ProfileViewEdit()
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

        private void reloadImage(string customDir)
        {

            if (customDir == "")
            {
                StudentImage.Image = Mgr.GetPupilImage(activeStudent);
            }
            else
            {
                // loads image and resizes to correct resolution
                Image fullSizeImg = Image.FromFile(customDir);
                if (fullSizeImg.Size.Height > fullSizeImg.Size.Width) StudentImage.Image = ResizeImage(fullSizeImg, 114, fullSizeImg.Size.Height*(114.0/fullSizeImg.Size.Width));
                else StudentImage.Image = ResizeImage(fullSizeImg, fullSizeImg.Size.Width * (142.0 / fullSizeImg.Size.Height) , 142);
                fullSizeImg.Dispose();
            }
        }

        // resizes image
        public static Bitmap ResizeImage(Image image, double width, double height) // https://stackoverflow.com/a/24199315
        {
            var destRect = new Rectangle(0, 0, Convert.ToInt32(Math.Floor(width)), Convert.ToInt32(Math.Floor(height)));
            var destImage = new Bitmap(Convert.ToInt32(Math.Floor(width)), Convert.ToInt32(Math.Floor(height)));

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void toggleA2EDisplay(bool context)
        {
            if (context)
            {
                label5.Visible = true;
                TextBoxA2EDesc.Visible = true;
                TextBoxBack4.Visible = true;
                CheckBoxStruggling.Location = new Point(255, 173);
            }
            else
            {
                label5.Visible = false;
                TextBoxA2EDesc.Visible = false;
                TextBoxBack4.Visible = false;
                CheckBoxStruggling.Location = new Point(255, 147);
            }
        }

        private void ProfileViewEdit_Load(object sender, EventArgs e)
        {

            ComboBoxYearGroup.SelectedIndex = 0;
            VisualThemes.ToDarkTheme(this);

            if (pupilForm != null)
            {

                Mgr = pupilForm.searchForm.Mgr;

                // creates local variable for ease of use with both contexts (create + edit)
                activeStudent = pupilForm.activeStudent;

                // Loads current student data into display
                this.Text = activeStudent.Name + " (" + activeStudent.PupilID + ") - Edit";

                TextBoxName.Text = activeStudent.Name;
                TextBoxStudentID.Text = activeStudent.PupilID;
                TextBoxCompany.Text = activeStudent.Company;
                CheckBoxA2E.Checked = activeStudent.A2E;
                TextBoxA2EDesc.Text = activeStudent.A2EDescription;
                toggleA2EDisplay(activeStudent.A2E);
                CheckBoxStruggling.Checked = activeStudent.Struggling;
                switch (activeStudent.YearGroup.ToString())
                {
                    case "S1":
                        ComboBoxYearGroup.SelectedIndex = 0;
                        break;
                    case "S2":
                        ComboBoxYearGroup.SelectedIndex = 1;
                        break;
                    case "S3":
                        ComboBoxYearGroup.SelectedIndex = 2;
                        break;
                    case "S4":
                        ComboBoxYearGroup.SelectedIndex = 3;
                        break;
                    case "S5":
                        ComboBoxYearGroup.SelectedIndex = 4;
                        break;
                    case "S6":
                        ComboBoxYearGroup.SelectedIndex = 5;
                        break;
                    case "College1":
                        ComboBoxYearGroup.SelectedIndex = 6;
                        break;
                    case "College2":
                        ComboBoxYearGroup.SelectedIndex = 7;
                        break;
                    case "Uni1":
                        ComboBoxYearGroup.SelectedIndex = 8;
                        break;
                    case "Uni2":
                        ComboBoxYearGroup.SelectedIndex = 9;
                        break;
                    case "Uni3":
                        ComboBoxYearGroup.SelectedIndex = 10;
                        break;
                    case "Uni4":
                        ComboBoxYearGroup.SelectedIndex = 11;
                        break;
                };

                reloadImage("");
            }
            else
            {

                Mgr = recordsForm.Mgr;

                // creates local variable for ease of use with both contexts (create + edit)
                activeStudent = recordsForm.activeStudent;

                this.Text = "New Student - Edit";
                toggleA2EDisplay(false);

            };

            FadeEffect.FadeIn(this, 100);

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
                SystemSounds.Beep.Play();
            };
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

            if (TextBoxStudentID.Text == "" | TextBoxName.Text == "")
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Please ensure both student name and ID are provided. These are required fields.", "Insufficient info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                activeStudent.Name = TextBoxName.Text;
                activeStudent.PupilID = TextBoxStudentID.Text;
                activeStudent.Company = TextBoxCompany.Text;
                activeStudent.A2E = CheckBoxA2E.Checked;
                if (activeStudent.A2E) activeStudent.A2EDescription = TextBoxA2EDesc.Text; // peepoWave
                else activeStudent.A2EDescription = "";
                Pupil.YearGroups[] yearGroups = {Pupil.YearGroups.S1, Pupil.YearGroups.S2, Pupil.YearGroups.S3, Pupil.YearGroups.S4, Pupil.YearGroups.S5, Pupil.YearGroups.S6, Pupil.YearGroups.College1, Pupil.YearGroups.College2, Pupil.YearGroups.Uni1, Pupil.YearGroups.Uni2, Pupil.YearGroups.Uni3, Pupil.YearGroups.Uni4};
                activeStudent.YearGroup = yearGroups[ComboBoxYearGroup.SelectedIndex];
                activeStudent.LastAccess = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.s");
                activeStudent.Struggling = CheckBoxStruggling.Checked;

                if (imgChanged || pupilForm == null)
                {
                    Mgr.SavePupilImage(activeStudent, StudentImage.Image);
                }

                Mgr.WritePupilData(activeStudent);
                SystemSounds.Beep.Play();

                // if this is a new pupil, create db connection to give user access to pupil
                if (pupilForm == null)
                {
                    OleDbConnection Connection = new OleDbConnection(Mgr.ConnectionString);
                    Mgr.User.GetAccessTo(Connection, activeStudent);
                }

                // writes back to parent form
                if (pupilForm != null) pupilForm.activeStudent = activeStudent;
                else recordsForm.activeStudent = activeStudent;

                FadeEffect.FadeOut(this, 100, new Action(() => this.Close()));

            }
            
        }

        private void CheckBoxA2E_CheckedChanged(object sender, EventArgs e)
        {
            toggleA2EDisplay(CheckBoxA2E.Checked);
        }

        // CUSTOM DRAW METHODS

        private void ComboBoxYearGroup_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          VisualThemes.GetThemeColor(8, 1)); //Choose the color

            e.DrawBackground(); // draw back
            e.Graphics.DrawString(ComboBoxYearGroup.Items[e.Index].ToString(), e.Font, new SolidBrush(VisualThemes.GetThemeColor(0, 1)), e.Bounds, StringFormat.GenericDefault); // draw text
        }
    }
}
