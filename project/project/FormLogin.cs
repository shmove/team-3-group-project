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

namespace project {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
        }

        public OleDbConnection con;
        public OleDbCommand cmd;
        public OleDbDataAdapter da;

        private void frmLogin_Load(object sender, EventArgs e)
        {

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
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\Pupils");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\Databases");
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtpassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true) {
                new pupilRecords().Show();
                this.Hide();
            } else {
                MessageBox.Show("Invalid username or password, please try again", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
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

    }
}
