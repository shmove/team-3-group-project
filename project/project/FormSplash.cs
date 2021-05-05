using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public ProgramConfig Config;

        private void FormLogo_Load(object sender, EventArgs e)
        {
            // reads config from file (or uses default if file is not present)
            String jsonString;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\config.json"))
            {
                jsonString = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\config.json");
            }
            else
            {
                jsonString = "{\"SplashSkip\":false,\"VisualTheme\":0}";
            }

            Config = JsonConvert.DeserializeObject<ProgramConfig>(jsonString);

            if (Config.SplashSkip)
            {
                WindowTimer.Stop();
                this.Opacity = 0;
                FormLogin loginForm = new FormLogin();
                loginForm.Config = Config;
                loginForm.FormClosed += (s, args) => this.Close(); // on the event of the login form closing, this one closes too
                this.Hide();
                loginForm.Show();
            }
            else
            {
                if (Config.VisualTheme == 1) VisualThemes.ToDarkTheme(this);
                FadeEffect.FadeIn(this, 300);
            }
        }

        // ticks 3secs after program opening
        private void WindowTimer_Tick(object sender, EventArgs e)
        {
            WindowTimer.Stop();
            FormLogin loginForm = new FormLogin();
            loginForm.Config = Config;
            loginForm.FormClosed += (s, args) => this.Close(); // on the event of the login form closing, this one closes too
            FadeEffect.FadeOut(this, 200, new Action(() => 
            {
                this.Hide();
                new DbPupilDataManager();
                loginForm.Show();
            }));
        }
    }
}