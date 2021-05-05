using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using static project.PupilDataManager.SharedResources.Types;

namespace project {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
        }

        public OleDbConnection con;
        public OleDbCommand cmd;
        public OleDbDataAdapter da;
        public ProgramConfig Config;
        private DbPupilDataManager Manager;

        // WINDOW CONTROL BAR

        private void PanelWindowControls_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.DragWindow(e, this);
        }

        private void PanelWindowClose_MouseHover(object sender, EventArgs e)
        {
            TitleBarControl.HoverButton(Config, PanelWindowClose);
        }

        private void PanelWindowClose_MouseLeave(object sender, EventArgs e)
        {
            TitleBarControl.LeaveButton(Config, PanelWindowClose);
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
            TitleBarControl.HoverButton(Config, PanelWindowMinimise);
        }

        private void PanelWindowMinimise_MouseLeave(object sender, EventArgs e)
        {
            TitleBarControl.LeaveButton(Config, PanelWindowMinimise);
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            Manager = new DbPupilDataManager(); //Sets up the database in the case of a first time load. Though, it does seem pretty strange to be calling the pupil manager to create the user table; I might change that in the future.
            if (Config.VisualTheme == 1) VisualThemes.ToDarkTheme(this);
            FadeEffect.FadeIn(this, 100);
        }

        private void button1_Click(object sender, EventArgs e) {
            OleDbConnection Connection = new OleDbConnection(Manager.ConnectionString);
            DbUser User = DbUser.GetUserFromDatabase(Connection, txtUsername.Text);
           bool Success = User?.Authenticate(Connection, txtpassword.Text) ?? false;
            if(Success){
                pupilRecords pupilRecords = new pupilRecords(User);
                pupilRecords.Config = Config;
                pupilRecords.FormClosed += (s, args) => this.Close(); // on the event of the pupilRecords form closing, this one closes too
                FadeEffect.FadeOut(this, 100, new Action(() => 
                {
                    this.Hide();
                    pupilRecords.Show();
                }));
            }else{
                MessageBox.Show("Invalid username or password, please try again.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e) {
            if (checkbxShowPas.Checked) {
                txtpassword.PasswordChar = '\0';

            } else {
                txtpassword.PasswordChar = '•';

            }
        }

        private void label6_Click(object sender, EventArgs e) {
            FormRegister registerForm = new FormRegister();
            registerForm.loginForm = this;
            registerForm.Config = Config;
            FadeEffect.FadeOut(this, 100, new Action(() => 
            {
                this.Hide();
                registerForm.Show();
            }));
            registerForm.FormClosed += (s, args) => FadeEffect.FadeIn(this, 100);
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
