using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class TitleBarControl
    {

        // allows for window dragging
        // https://stackoverflow.com/a/1592899
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Handles dragging a form around when left click is held.
        /// </summary>
        /// <param name="e">MouseEventArgs passed by the event.</param>
        /// <param name="f">The form to be dragged.</param>
        public static void DragWindow(MouseEventArgs e, Form f)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(f.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Visually changes a button when hovered over.
        /// </summary>
        /// <param name="b">The button to be highlighted.</param>
        public static void HoverButton(ProgramConfig Config, Control b)
        {
            b.BackColor = VisualThemes.GetThemeColor(5, Config.VisualTheme);
        }

        /// <summary>
        /// Visually changes a button when mouse stops hovering over it.
        /// </summary>
        /// <param name="b">The button to stop highlighting.</param>
        public static void LeaveButton(ProgramConfig Config, Control b)
        {
            b.BackColor = VisualThemes.GetThemeColor(4, Config.VisualTheme);
        }

        /// <summary>
        /// Handles the left clicking of buttons.
        /// </summary>
        /// <param name="e">MouseEventArgs passed by the event.</param>
        /// <param name="action">The action to be invoked from pressing the button.</param>
        public static void MouseDownButton(MouseEventArgs e, Action action)
        {
            if (e.Button != MouseButtons.Left) return;
            action.Invoke();
        }

        /// <summary>
        /// Handles the unminimisation of forms.
        /// </summary>
        /// <param name="f">The form to be unminimised.</param>
        public static void Unminimise(Form f)
        {
            if (f.WindowState != FormWindowState.Minimized) FadeEffect.FadeIn(f, 100);
        }

    }
}
