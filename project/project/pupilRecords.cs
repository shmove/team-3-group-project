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
        public String dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\Pupils";

        public pupilRecords()
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

            List<string> PupilNames = Mgr.CollatePropertyValuesFromPupils<string>("Name");

            foreach (String name in PupilNames)
            {
                SearchResults.Items.Add(name + " (???)");
            }

        }
    }
}
