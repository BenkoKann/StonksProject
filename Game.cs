using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;




namespace stonks2
{



    
    class Game
    {
        handler handler;
        Portfolio portfolio;
        static ConsoleKeyInfo cki;

        protected static int origCol = 2; // just shifts over 2
        protected static int origRow = 3;
        protected static int maxRow;


        private static string currentColor = "green";

        

        public Game()
        {
            portfolio = new Portfolio();
            handler = new handler(this, portfolio);
            
            
            Console.Clear();


            // old stocks with old data file below

            // handler.addObject(new Stock("apple", "appl", 50, portfolio, handler));
            // handler.addObject(new Stock("dowJones", "dji", 100, portfolio, handler));


            // stocks with data from csv file below
            handler.addObject(new Stock("hawaii bank", "boh", portfolio, handler));
            handler.addObject(new Stock("paypal", "pypl", portfolio, handler));
            handler.addObject(new Stock("facebook", "fb", portfolio, handler));
            handler.addObject(new Stock("s&p500", "gspc", portfolio, handler));
            handler.addObject(new Stock("amazon", "amzn", portfolio, handler));
            handler.addObject(new Stock("crude oil", "cl=f", portfolio, handler));
            handler.addObject(new Stock("emerson electric", "emr", portfolio, handler));
            handler.addObject(new Stock("costco", "cost", portfolio, handler));
            handler.addObject(new Stock("macys", "m", portfolio, handler));
            handler.addObject(new Stock("silver trust", "slv", portfolio, handler));

            Game.maxRow = Game.origRow + this.handler.getLength() - 1;

            handler.initAll();

            listenForKeys();

            int DA = 4;
            int V = 255;
            int ID = 20;

            Console.Clear();
            StatHelp.special("END WORTH: ", DA, V, ID);
            Console.WriteLine("$"+Math.Round(portfolio.NetWorth, 2));







            Console.ReadLine();

        }

        public void setRedBox(string color = "green") {
            if (color == "green")
            {
                WriteAt("    ", 70, 0, "green");
            }
            else {
                WriteAt("    ", 70, 0, "red");
            }
            
        }

        public void listenForKeys() {
            setRedBox();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            int i = 100;
            do
            {
                /*cki = Console.ReadKey();

                

                Console.Write(" --- You pressed ");
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");

                Console.WriteLine(cki.Key.ToString());*/

                while (!Console.KeyAvailable)
                {
                    if (sw.ElapsedMilliseconds > 2000 || i == 100) { // if 2 sec passed or i==20 (first iteration)
                        double nw = 0; // networth
                        foreach (Stock s in handler.getStocks()) {
                            s.RUdata(i);

                            nw += s.getCurrentValue(); // adding up all of the values of the stocks currently owned
                          
                        }
                        portfolio.NetWorth = nw + portfolio.Cash; // value of invested money plus cash holdings
                       
                        i++;
                        sw.Restart();
                        handler.initAll(currentColor);
                        
                    }
                }


                cki = Console.ReadKey();
                ClearCurrentConsoleLine();

                

                if (cki.KeyChar.ToString() == "s")
                {
             
                    /*WriteAt("", 70, -1);*/
                    WriteAt("    ", 70, 0, "clear");
                    WriteAt("    ", 70, 1, Game.currentColor);
                }
                else if (cki.KeyChar.ToString() == "w") {
                    WriteAt("    ", 70, 0, "clear");
                    WriteAt("    ", 70, -1, Game.currentColor);
                }

                if (cki.KeyChar.ToString() == "d")
                {
                    //3 4 5 6 7 8 9 10 11 12
                    handler.getStockById(origRow - 2).buy();

                    // Console.Clear();
                    handler.initAll("green");

                }
                else if (cki.KeyChar.ToString() == "a") {
                    handler.getStockById(origRow - 2).sell();

                    // Console.Clear();
                    handler.initAll("red");
                }




            } while (cki.Key != ConsoleKey.Escape);
        }

        public static void WriteAt(string s, int x, int y, string color) {
            try
            {


                if (origRow + y < 3 || origRow + y > maxRow)
                {
                    y = 0; // no increment down or up
                }

                Console.SetCursorPosition(origCol + x, origRow + y);

                if (color.ToLower() == "red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    currentColor = "red";
                }
                else if (color.ToLower() == "green") {
                    Console.BackgroundColor = ConsoleColor.Green;
                    currentColor = "green";
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                
                Console.Write(s);
                Console.ResetColor();

                origRow = origRow + y;
                origCol = 0;


                Console.SetCursorPosition(0, 0);
            }
            catch (ArgumentOutOfRangeException e) {
                // do nothing
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


    }
}
