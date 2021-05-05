using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        public ProgramConfig Config;

        // WINDOW CONTROL BAR

        private void PanelWindowControls_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.DragWindow(e, this);
        }

        private void PanelWindowClose_MouseHover(object sender, EventArgs e)
        {
            TitleBarControl.HoverButton(Config, PanelWindowClose);
        }

        private void PanelWindowClose_MouseLeave(object sender, EventArgs e)
        {
            TitleBarControl.LeaveButton(Config, PanelWindowClose);
        }

        private void PanelWindowClose_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.MouseDownButton(e, new Action(() =>
            {
                FadeEffect.FadeOut(this, 100, new Action(() => this.Close()));
            }));
        }

        private void PanelWindowMinimise_MouseHover(object sender, EventArgs e)
        {
            TitleBarControl.HoverButton(Config, PanelWindowMinimise);
        }

        private void PanelWindowMinimise_MouseLeave(object sender, EventArgs e)
        {
            TitleBarControl.LeaveButton(Config, PanelWindowMinimise);
        }

        private void PanelWindowMinimise_MouseDown(object sender, MouseEventArgs e)
        {
            TitleBarControl.MouseDownButton(e, new Action(() =>
            {
                FadeEffect.FadeOut(this, 100, new Action(() => this.WindowState = FormWindowState.Minimized));
            }));
        }


        // FORM CODE

        private void FormSettings_Load(object sender, EventArgs e)
        {
            if (Config.VisualTheme == 1) VisualThemes.ToDarkTheme(this);

            CheckBoxSplash.Checked = Config.SplashSkip;
            ComboBoxTheme.SelectedIndex = Config.VisualTheme;

            FadeEffect.FadeIn(this, 100);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            FadeEffect.FadeOut(this, 100, new Action(() =>
            {
                this.Close();
            }));
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Config.SplashSkip = CheckBoxSplash.Checked;
            Config.VisualTheme = ComboBoxTheme.SelectedIndex;

            // write new config to file
            string jsonString = JsonConvert.SerializeObject(Config);
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\PupilRecordsProgram\config.json");
            sw.WriteLine(jsonString);
            sw.Close();

            FadeEffect.FadeOut(this, 100, new Action(() =>
            {
                this.Close();
            }));
        }

        // CUSTOM DRAW METHODS

        private void ComboBoxTheme_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          VisualThemes.GetThemeColor(8, Config.VisualTheme)); //Choose the color

            e.DrawBackground(); // draw back
            e.Graphics.DrawString(ComboBoxTheme.Items[e.Index].ToString(), e.Font, new SolidBrush(VisualThemes.GetThemeColor(0, Config.VisualTheme)), e.Bounds, StringFormat.GenericDefault); // draw text
        }

    }
}
