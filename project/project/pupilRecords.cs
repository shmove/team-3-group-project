using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static project.PupilDataManager.SharedResources.Types;

namespace project
{
    public partial class pupilRecords : Form
    {

        public pupilRecords()
        {
            InitializeComponent();
        }

        private DbPupilDataManager Mgr;

        private void reloadPupils()
        {

            Mgr = new DbPupilDataManager();

            Pupil[] PupilArray = Mgr.GetTestCases(4);

            List<Pupil> Pupils = Mgr.GetPupilsByProperties(new { });

            foreach (Pupil pupil in Pupils)
            {
                SearchResults.Items.Add(pupil.Name + " (" + pupil.PupilID + ")");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            reloadPupils();

        }

        private void ViewButton_Click(object sender, EventArgs e)
        {

            ProfileEditView infoForm = new ProfileEditView();
            infoForm.searchForm = this;
            this.Hide();
            infoForm.ShowDialog();
            this.Show();

        }

    }
}
