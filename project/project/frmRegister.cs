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

namespace project
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" && Password.Text == "" && Confirmpassword.Text == "")
            {
                MessageBox.Show("must enter username and password", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Password.Text == Confirmpassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + Username.Text + "','" + Password.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Username.Text = "";
                Password.Text = "";
                Confirmpassword.Text = "";

                MessageBox.Show("Your acount creation has been successfull", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }    
            else
            {
                MessageBox.Show("Passwords do not match", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Text = "";
                Confirmpassword.Text = "";
                Password.Focus();
            }
        }

        private void chkboxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxShowPas.Checked)
            {
                Password.PasswordChar = '\0';
                Confirmpassword.PasswordChar = '\0';
            }
            else
            {
                Password.PasswordChar = '*';
                Confirmpassword.PasswordChar = '*';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Username.Text = "";
            Password.Text = "";
            Confirmpassword.Text = "";
            Username.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
