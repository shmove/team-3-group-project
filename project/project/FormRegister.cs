using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace project {
    public partial class FormRegister : Form {

        public FormRegister() {
            InitializeComponent();
        }

        public FormLogin loginForm;

        private void button1_Click(object sender, EventArgs e) {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "") {
                MessageBox.Show("Username and password fields are empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if (txtPassword.Text == txtComPassword.Text) {
                loginForm.con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                loginForm.cmd = new OleDbCommand(register, loginForm.con);
                loginForm.cmd.ExecuteNonQuery();
                loginForm.con.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your account has been successfully created.", "Registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else {
                MessageBox.Show("Passwords do not match, please re-enter", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Close();
        }

        private void frmRegister_Load(object sender, EventArgs e) {
            label2.Text = "Username";
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
