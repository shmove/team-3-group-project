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

        /*
         * THEMES
         * 0 - light
         * 1 - dark
        */

        // each colour in the list corresponds to the colour at the same index in the other list, for their respective themes
        // there's some issues when the same colour appears in both lists, so if ur wanting to use the same colour in both just offset it by 1 in any value
        // if adding colours to these lists, add them to the end
        private static readonly List<Color> lightColours = new List<Color>
        {
            Color.FromArgb(0,0,0), // text
            Color.FromArgb(64,64,64), // button tone2 back, button tone1 border
            Color.FromArgb(114,115,117), // less faded text
            Color.FromArgb(164,165,169), // faded text
            Color.FromArgb(230,231,233), // textbox back, button tone2 border, custom dropdown border, window control bar
            Color.FromArgb(237,237,239), // regular border, custom dropdown back
            Color.FromArgb(255,255,255), // background, button tone1 back
            Color.FromArgb(179,179,179), // v thin border
            SystemColors.Highlight // highlight color
        };

        private static readonly List<Color> darkColours = new List<Color>
        {
            Color.FromArgb(220,221,222), // text
            Color.FromArgb(130,114,218), // button tone2 back, button tone1 border
            Color.FromArgb(162,166,171), // less faded text
            Color.FromArgb(142,146,151), // faded text
            Color.FromArgb(44,48,55), // textbox back, button tone2 border, custom dropdown border, window control bar
            Color.FromArgb(49,53,60), // regular border, custom dropdown back
            Color.FromArgb(64,68,75), // background, button tone1 back
            Color.FromArgb(24,28,35), // v thin border
            Color.FromArgb(130,114,218) // highlight color
        };

        /// <summary>
        /// Returns the dark theme alternative of a colour.
        /// </summary>
        /// <param name="colour">The colour to be swapped with its dark theme alternative.</param>
        /// <returns>The dark theme alternative of the colour parameter.</returns>
        private static Color getDarkColour(Color colour)
        {

            // tried to use a switch statement here, but had a ton of errors relating to constant values. doesn't seem possible as far as i can tell :/
            for (int i = 0; i < darkColours.Count; i++)
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
                if (cType.Equals(typeof(Label)) || cType.Equals(typeof(TextBox)) || cType.Equals(typeof(TextBox)) || cType.Equals(typeof(CheckBox)) || cType.Equals(typeof(ComboBox)) || cType.Equals(typeof(ListBox)) || cType.Equals(typeof(PictureBox)))
                {
                    c.BackColor = getDarkColour(c.BackColor);
                    c.ForeColor = getDarkColour(c.ForeColor);
                }
                else if (cType.Equals(typeof(Button)))
                {
                    Button c1 = c as Button;
                    c1.BackColor = getDarkColour(c1.BackColor);
                    c1.ForeColor = getDarkColour(c1.ForeColor);
                    c1.FlatAppearance.BorderColor = getDarkColour(c1.FlatAppearance.BorderColor);
                }
                /* 
                
                 * for some reason, Windows has built in themes for elements like this and you can't custom recolour them. kinda sux (source: https://stackoverflow.com/a/30299278/13460028)
                 * maybe use this? https://social.msdn.microsoft.com/Forums/en-US/5d95b931-0edc-4f6c-8aa7-6d8eb14780a0/datetimepicker-color

                else if (cType.Equals(typeof(DateTimePicker)))
                {
                    DateTimePicker c1 = c as DateTimePicker;
                    c1.CalendarForeColor = getDarkColour(c1.CalendarForeColor);
                    c1.CalendarMonthBackground = getDarkColour(c1.CalendarMonthBackground);
                    c1.CalendarTitleBackColor = getDarkColour(c1.CalendarTitleBackColor);
                    c1.CalendarTitleForeColor = getDarkColour(c1.CalendarTitleForeColor);
                    c1.CalendarTrailingForeColor = getDarkColour(c1.CalendarTrailingForeColor);
                }

                */
                else
                {
                    // panel goes here, as panel can have child controls of its own
                    if (cType.Equals(typeof(Panel)))
                    {
                        c.BackColor = getDarkColour(c.BackColor);
                        c.ForeColor = getDarkColour(c.ForeColor);
                    };
                    // same with form
                    if (parent.GetType().BaseType.Equals(typeof(Form)))
                    {
                        parent.BackColor = getDarkColour(parent.BackColor);
                        parent.ForeColor = getDarkColour(parent.ForeColor);
                    };

                    // recursion; loops through all child controls of current control
                    ToDarkTheme(c);
                }

            };

        }

        public static Color GetThemeColor(int colourIndex, int theme = 0)
        {
            switch (theme)
            {
                case 0:
                    return lightColours[colourIndex];
                case 1:
                    return darkColours[colourIndex];
                default:
                    throw new Exception("Tried to get colour from an invalid theme reference");
            }
        }




        // to be implemented
        class CustomComboBox : ComboBox
        {

        }

    }
}
