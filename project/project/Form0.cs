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
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtUser.Text; 
            pass = txtPassword.Text;

            if(user=="admin" && pass=="password")
            {
                this.Close();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("password is incorrect");
            }


        }
    }
}
