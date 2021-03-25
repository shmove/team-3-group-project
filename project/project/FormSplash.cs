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
    public partial class FormSplash : Form
    {

        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormLogo_Load(object sender, EventArgs e)
        {
            FadeEffect.FadeIn(this, 300);
        }

        // ticks 3secs after program opening
        private void WindowTimer_Tick(object sender, EventArgs e)
        {
            WindowTimer.Stop();
            FormLogin loginForm = new FormLogin();
            loginForm.FormClosed += (s, args) => this.Close(); // on the event of the login form closing, this one closes too
            FadeEffect.FadeOut(this, 200, new Action(() => loginForm.Show()));
        }
    }
}
