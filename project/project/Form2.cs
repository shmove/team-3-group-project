using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtUser.Text;
            pass = txtPassword.Text;

            if (user == "admin" && pass == "password") /// add a more secure login handler later
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect username or password. Please try again.");
                txtPassword.Text = String.Empty; /// clears password textbox for ease of use
            }
        }
    }
}

