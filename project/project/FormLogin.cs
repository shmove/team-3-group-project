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
        private DbPupilDataManager Manager;

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
            this.Close();
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
            this.WindowState = FormWindowState.Minimized;
        }

        // FORM CODE

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            Manager = new DbPupilDataManager(); //Sets up the database in the case of a first time load. Though, it does seem pretty strange to be calling the pupil manager to create the user table; I might change that in the future.
            

            return;


            // initialises database connection
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram"))
            {
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\Databases\db_users.mdb");
                cmd = new OleDbCommand();
                da = new OleDbDataAdapter();
            }
            else
            {
                Console.WriteLine("File path not detected. Performing first time setup...");
                // this is temporary, and just to demonstrate which folders should exist
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\Pupils");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\Databases");
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            OleDbConnection Connection = new OleDbConnection(Manager.ConnectionString);
            DbUser User = DbUser.GetUserFromDatabase(Connection, txtUsername.Text);
           bool Success = User?.Authenticate(Connection, txtpassword.Text) ?? false;
            if(Success){
                pupilRecords pupilRecords = new pupilRecords(User);
                pupilRecords.FormClosed += (s, args) => this.Close(); // on the event of the pupilRecords form closing, this one closes too
                this.Hide();
                pupilRecords.Show();
            }else{
                MessageBox.Show("Invalid username or password, please try again.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtUsername.Focus();
            }
            return;
            
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtpassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true) {
                this.Hide();
                pupilRecords pupilRecords = new pupilRecords();
                pupilRecords.FormClosed += (s, args) => this.Close(); // on the event of the pupilRecords form closing, this one closes too
                pupilRecords.Show();
            } else {
                MessageBox.Show("Invalid username or password, please try again.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtUsername.Focus();
            }
            con.Close();
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
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

    }
}
