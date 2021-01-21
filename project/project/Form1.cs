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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {

            ProfileEditView infoForm = new ProfileEditView();
            infoForm.searchForm = this;
            infoForm.Show();

        }
    }
}
