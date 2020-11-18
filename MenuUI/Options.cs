using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLib
{
    public static class Options
    {

        public static string[] level = { "Easy", "Medium", "Hard" };
        public static string[] startBalance = { "$1000", "$10,000", "$100,000" }; // string displayed in gui
        public static double[] StartBalanceDoub = { 1000, 10000, 100000 }; // double form start balance
        public static string[] gameDuration = { "10 Days", "100 Days", "365 Days" };

        public static int lvl_active = 0;
        public static int startBalance_active = 0;
        public static int gameDuration_active = 0;

        public static void incrementLevel()
        {
            lvl_active += 1;
        }

        public static void incrementStartBalance()
        {
            startBalance_active += 1;
        }

        public static void incrementGameDuration()
        {
            gameDuration_active += 1;
        }

        public static void resetSettings() {
            lvl_active = 0;
            startBalance_active = 0;
            gameDuration_active = 0;
        }

      
    }
}
