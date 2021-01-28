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

        public String dataDir = @""; // for testing, fill this in with your own working dir - will be in appdata or smthn later

        public Form1()
        {
            InitializeComponent();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {

            ProfileEditView infoForm = new ProfileEditView();
            infoForm.searchForm = this;
            this.Hide();
            infoForm.ShowDialog();
            this.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            PupilFileManager Mgr = new PupilFileManager(dataDir);

            string[] PupilNames = Mgr.GetPupilNameArray();

            foreach (String name in PupilNames)
            {
                SearchResults.Items.Add(name + " (???)");
            }

        }
    }
}
