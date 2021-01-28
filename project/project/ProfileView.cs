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
    public partial class ProfileEditView : Form
    {

        public pupilRecords searchForm;

        public ProfileEditView()
        {
            InitializeComponent();
        }

        private void ProfileEditView_Load(object sender, EventArgs e)
        {

            PupilFileManager Mgr = new PupilFileManager(@"C:\Users\Matthew Liddle\Documents\Software Dev Course\Work Placement\testDir\");

            string[] highlightedField = ((pupilRecords)searchForm).SearchResults.GetItemText(((pupilRecords)searchForm).SearchResults.SelectedItem).Split('(');

            string studentName = highlightedField[0].Trim(); /// Gets pupil name from substring array, removing trailing space
            string studentID = highlightedField[1].Trim('(',' ', ')');

            Console.WriteLine("studentName: '" + studentName + "'");
            Console.WriteLine("studentID: '" + studentID + "'");

            List <Pupil> students = Mgr.GetPupilsByProperties(new { Name = studentName }); /// Replace with ID, when implemented

            foreach(Pupil student in students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Company);
            };

        }
    }
}
