using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;
// for rainbow

using System.Drawing;
using Crayon;

namespace stonks2
{
    class StatHelp // static helpers
    {

        public static void writeRainbow(string str, double c = .05, int e = 0, Boolean newline = true) {
            var rainbow = new Rainbow(c);
            for (var i = 0; i < str.Length+e; i++)
            {
                if (i < e) // e allows rainbow shift
                {
                    rainbow.Next();
                }
                else {
                    Console.Write(rainbow.Next().Bold().Text(str[i-e].ToString()));
                }
            }
            if (newline) {
                Console.WriteLine(); // makes new line if newline is true
            }
            
        }

        public static double round(double d, int numPlaces) {  // 2.14123
            d *= (10 * numPlaces);  // (numPlaces = 2)   // 214.123
            d = (int)d; // 214
            d /= (10 * numPlaces); // 2.14
            return d;

        }

        public static string round(string s, int numPlaces)
        {  // 2.14123
            double d;
            if (Double.TryParse(s, out d)) {
                d *= (10 * numPlaces);  // (numPlaces = 2)   // 214.123
                d = (int)d; // 214
                d /= (10 * numPlaces); // 2.14
                return d.ToString();
            }
            return null;
            

        }

        public static void special(string str, int r, int g, int b) {
            Console.WriteAscii(str, Color.FromArgb(r, g, b));
        }


    }
}
