using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{

    class FadeEffect
    {

        /// <summary>
        /// Fades a form in, then stops.
        /// Based off of this: https://codingvision.net/c-form-fade-in-fade-out
        /// </summary>
        /// <param name="f">Windows form to be faded in</param>
        /// <param name="ms">Transition time in ms</param>
        public static void FadeIn(System.Windows.Forms.Form f, int ms)
        {

            if (!f.Visible) f.Show();
            f.Opacity = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Start();

            timer.Tick += delegate
            {

                if (f.Opacity >= 1)
                {
                    timer.Stop();
                }
                else f.Opacity += (1.0 / (ms / 10.0));

            };

        }

        /// <summary>
        /// Fades a form out, then stops.
        /// Based off of this: https://codingvision.net/c-form-fade-in-fade-out
        /// </summary>
        /// <param name="f">Windows form to be faded out</param>
        /// <param name="ms">Transition time in ms</param>
        public static void FadeOut(System.Windows.Forms.Form f, int ms)
        {

            f.Opacity = 1;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Start();

            timer.Tick += delegate

            {

                if (f.Opacity <= 0.2)
                {
                    timer.Stop();
                    f.Opacity = 0;
                } 
                else f.Opacity -= ( 1.0 / ( ms / 10.0) );

            };

        }

        // for if you've forgotten how actions work :)
        // Action action = new Action(() => _myMessage = "hello");

        /// <summary>
        /// Fades a form out then invokes an action.
        /// Based off of this: https://stackoverflow.com/a/20799039
        /// </summary>
        /// <param name="f">Windows form to be faded out</param>
        /// <param name="ms">Transition time in ms</param>
        /// <param name="action">Action to be invoked following fade-out</param>
        public static void FadeOut(System.Windows.Forms.Form f, int ms, Action action)
        {
            FadeOut(f, ms);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += delegate

            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = ms;
            timer.Start();
        }

    }
}
