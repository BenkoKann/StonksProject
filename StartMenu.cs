using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Remoting.Activation;
using Console = Colorful.Console;
using System.Drawing;
using Crayon;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Windows.Forms;

using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace stonks2
{
    class StartMenu
    {

       
        
        // static ConsoleKeyInfo cki;

        static ConsoleKeyInfo cki;


        static string[] level =  {"Easy", "Medium", "Hard"};
        static string[] startBalance = { "$1000", "$10,000", "$100,000"};
        static string[] gameDuration = { "10 Days", "100 Days", "365 Days" };

        static int lvl_active = 0;
        public static int startBalance_active = 0;
        static int gameDuration_active = 0;

        static string furry;
        static int shift = 0;

        static int origWidth, width;
        static int origHeight, height;

        static int a;
        static int b;

        public StartMenu() {

            

            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;

            width = (int) (origWidth * 1.3);
            height = (int) (origHeight * 1);

            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(width, height);
            


            init();


        }

        public static void init() {
            refresh();

            int DA = 4;
            int V = 255;
            int ID = 20;

            Console.WriteAscii("STONKS", Color.FromArgb(DA, V, ID));

            //Console.WriteLine("STONKS");
            StatHelp.writeRainbow("Instructions: ");
            string[] data = System.IO.File.ReadAllLines($@"C:\Users\aqwxcdrvtb\source\repos\stonks2\stonks2\instructions.txt");
            foreach(string s in data) {
                Console.WriteLine(s);
            }

            StatHelp.writeRainbow("\nPress number to toggle settings:");
             a = Console.CursorLeft;
             b = Console.CursorTop;

           //  Console.WriteLine("Press number to toggle settings");

            Console.WriteLine("1) [Level] ==> {0}", level[lvl_active % level.Length]);
            Console.WriteLine("2) [Start Balance] ==> {0}", startBalance[startBalance_active % startBalance.Length]);
            Console.WriteLine("3) [Game Duration] ==> {0}", gameDuration[gameDuration_active % gameDuration.Length]);
            Console.WriteLine("4) [Reset Settings]");

            furry = "5) [Start Game]";
            Console.WriteLine(furry);


            

        }

        public static void incrementLevel() {
            lvl_active += 1;
            init();
        }

        public static void incrementStartBalance() {
            startBalance_active += 1;
            init();
        }

        public static void incrementGameDuration()
        {
            gameDuration_active += 1;
            init();
        }

        public static void resetSettings() {

            lvl_active = 0;
            startBalance_active = 0;
            gameDuration_active = 0;
            init();

        }

        public static void refresh() {
         
            Console.Clear();
        }



        static void Main(string[] args)
        {

            new StartMenu();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int t = Console.CursorTop;
            int l = Console.CursorLeft;
            int tf = 0;
            int lf = 0;

            do
            {

               //  StatHelp.writeRainbow("command: ",.5,shift,false);
               // shift += 1;

                while (!Console.KeyAvailable) 
                {
                   
                    if (sw.ElapsedMilliseconds > 50 || (tf == 0 && lf == 0)) { // if time or first iteration
                        Console.SetCursorPosition(a, b-1);
                        StatHelp.writeRainbow("Press number to toggle settings:", .03, (int)(shift*5), false);

                        Console.SetCursorPosition(l, t);

                        StatHelp.writeRainbow("command: ", .2, shift, false);

                        
                       

                        shift += 1;
                        // Console.SetCursorPosition(0, 0);
                        tf = Console.CursorTop;
                        lf = Console.CursorLeft;
                        
                        sw.Restart();

                    }
                    Console.SetCursorPosition(lf, tf);





                }

                cki = Console.ReadKey(true);
                // Console.WriteLine("You pressed the '{0}' key.", cki.KeyChar);


                string ans = cki.KeyChar.ToString();
                

                
              
                    if (ans == "1")
                    {
                        incrementLevel();
                    }
                    else if (ans == "2")
                    {
                        incrementStartBalance();
                    }
                    else if (ans == "3")
                    {
                        incrementGameDuration();
                    }
                    else if (ans == "4")
                    {
                        resetSettings();
                    }
                    else if (ans == "5") {
                       
                        new Game();

                        break;
                    }
                    
               
                

            } while (true);

            /*do
            {
                cki = Console.ReadKey();

                Console.Write(" --- You pressed ");
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");

                Console.WriteLine(cki.Key.ToString());


            } while (cki.Key != ConsoleKey.Escape);*/



           /* string[] lines = System.IO.File.ReadAllLines(@"C:\Users\aqwxcdrvtb\source\repos\stonks2\thetext.txt");

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            Console.ReadLine();*/







        }
    }
}
