using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using static project.PupilDataManager.SharedResources.Types;

namespace project {
    public partial class FormRegister : Form {

        public FormRegister() {
            InitializeComponent();
        }

        public FormLogin loginForm;

        // WINDOW CONTROL BAR

        // allows for window dragging
        // https://stackoverflow.com/a/1592899
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void PanelWindowControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PanelWindowClose_MouseHover(object sender, EventArgs e)
        {
            PanelWindowClose.BackColor = Color.FromArgb(255, 210, 211, 213);
        }

        private void PanelWindowClose_MouseLeave(object sender, EventArgs e)
        {
            PanelWindowClose.BackColor = Color.FromArgb(255, 230, 231, 233);
        }

        private void PanelWindowClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            FadeEffect.FadeOut(this, 100, new Action(() => this.Close()));
        }

        private void PanelWindowMinimise_MouseHover(object sender, EventArgs e)
        {
            PanelWindowMinimise.BackColor = Color.FromArgb(255, 210, 211, 213);
        }

        private void PanelWindowMinimise_MouseLeave(object sender, EventArgs e)
        {
            PanelWindowMinimise.BackColor = Color.FromArgb(255, 230, 231, 233);
        }

        private void PanelWindowMinimise_MouseDown(object sender, MouseEventArgs e)
        {
            FadeEffect.FadeOut(this, 100, new Action(() =>
            this.WindowState = FormWindowState.Minimized
            ));
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) FadeEffect.FadeIn(this, 100);
        }

        // FORM CODE

        private void button1_Click(object sender, EventArgs e) {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtComPassword.Text == "") {
                MessageBox.Show("Username and/or password fields are empty.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if (txtPassword.Text == txtComPassword.Text) {
                OleDbConnection Connection = new OleDbConnection(new DbPupilDataManager().ConnectionString); //I hate every bit of this... I'll refactor it soon
                DbUser User = new DbUser(txtUsername.Text);
                User.SaveUser(Connection, txtPassword.Text);
                /*loginForm.con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                loginForm.cmd = new OleDbCommand(register, loginForm.con);
                loginForm.cmd.ExecuteNonQuery();
                loginForm.con.Close();*/

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your account has been successfully created.", "Registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            } else {
                MessageBox.Show("Passwords do not match, please re-enter.", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e) {
            if (checkbxShowPas.Checked) {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            } else {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e) {
            FadeEffect.FadeOut(this, 100, new Action(() => this.Close()));
        }

        private void frmRegister_Load(object sender, EventArgs e) {
            label2.Text = "Username";
            VisualThemes.ToDarkTheme(this);
            FadeEffect.FadeIn(this, 100);
        }

        private void txtComPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
