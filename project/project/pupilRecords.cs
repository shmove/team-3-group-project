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
    public partial class pupilRecords : Form
    {
        public pupilRecords()
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
