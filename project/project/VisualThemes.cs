using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class VisualThemes
    {

        // each colour in the list corresponds to the colour at the same index in the other list, for their respective themes
        private static List<Color> lightColours = new List<Color>
        {
            Color.FromArgb(0,0,0),
            Color.FromArgb(64,64,64),
            Color.FromArgb(114,115,117),
            Color.FromArgb(164,165,169),
            Color.FromArgb(230,231,233),
            Color.FromArgb(237,237,239),
            Color.FromArgb(243,243,244),
            Color.FromArgb(255,255,255),
            Color.FromArgb(179,179,179) // v thin border
        };

        private static List<Color> darkColours = new List<Color>
        {
            Color.FromArgb(254,254,254),
            Color.FromArgb(235,235,235),
            Color.FromArgb(210,210,210),
            Color.FromArgb(190,190,190),
            Color.FromArgb(112,112,112),
            Color.FromArgb(120,120,120),
            Color.FromArgb(128,128,128),
            Color.FromArgb(88,88,88),
            Color.FromArgb(100,100,100) // v thin border
        };

        /// <summary>
        /// Returns the dark theme alternative of a colour.
        /// </summary>
        /// <param name="colour">The colour to be swapped with its dark theme alternative.</param>
        /// <returns>The dark theme alternative of the colour parameter.</returns>
        private static Color getDarkColour(Color colour)
        {

            // tried to use a switch statement here, but had a ton of errors relating to constant values. doesn't seem possible as far as i can tell :/
            for (int i=0; i < darkColours.Count; i++)
            {
                if (colour.ToArgb().Equals(lightColours[i].ToArgb()))
                {
                    colour = darkColours[i];
                    i = darkColours.Count; // end loop early
                }
            }

            return colour;

        }

        /// <summary>
        /// Switches colours based off of a colour pallete to a 'dark theme'.
        /// </summary>
        /// <param name="parent">The parent of all controls to be converted to dark theme.</param>
        public static void ToDarkTheme(Control parent)
        {
            // https://stackoverflow.com/a/15186905
            // loops through all controls on the form
            foreach (Control c in parent.Controls)
            {
                Type cType = c.GetType();
                // tried to use switch again, but it really wants me to use if/else's here. switch doesn't work on type for some reason
                if (cType.Equals(typeof(Label)) || cType.Equals(typeof(TextBox)) || cType.Equals(typeof(TextBox)) || cType.Equals(typeof(CheckBox)) || cType.Equals(typeof(ComboBox)) || cType.Equals(typeof(DateTimePicker)) || cType.Equals(typeof(ListBox)) || cType.Equals(typeof(Button)))
                {
                    c.BackColor = getDarkColour(c.BackColor);
                    c.ForeColor = getDarkColour(c.ForeColor);
                }
                else
                {
                    if (cType.Equals(typeof(Panel)))
                    {
                        c.BackColor = getDarkColour(c.BackColor);
                        c.ForeColor = getDarkColour(c.ForeColor);
                    };

                    if (parent.GetType().BaseType.Equals(typeof(Form)))
                    {
                        parent.BackColor = getDarkColour(parent.BackColor);
                        parent.ForeColor = getDarkColour(parent.ForeColor);
                    };

                    ToDarkTheme(c);
                }

            };

        }

    }
}
