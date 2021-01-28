using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace project {
    public partial class FormRegister : Form {
        public FormRegister() {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e) {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "") {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if (txtPassword.Text == txtComPassword.Text) {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your Account has been Successfully Created Matthew :)", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else {
                MessageBox.Show("Passwords does not match unlucky Matt, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            new FormLogin().Show();
            this.Hide();
        }

        private void frmRegister_Load(object sender, EventArgs e) {
            label2.Text = "Username";
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
