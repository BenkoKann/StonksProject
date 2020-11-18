using Portfolio;
using System;
using System.Diagnostics;
using MenuUI;
using MenuLib;

namespace ConsoleUISeparate
{
    class Game
    {

        Stocks stocks;
        static ConsoleKeyInfo cki;
        private int line;
        private string currentColor = "green";

        Marker marker;

        public Game() {
            Console.Clear();

           Portfolio.Statistics.Balance.cash = Portfolio.Statistics.Balance.netWorth = Options.StartBalanceDoub[Options.startBalance_active]; // sets cash in balance class to the option picked from menu

            stocks = new Stocks();
            marker = new Marker(1, stocks.getLength());
          


            fcol("name", "ticker", "shares", "currentPrice", "avgCost", "investment", "currentValue", "totalReturn", "percentReturn");

            

            listenForKeys(); // aka game loop

            Console.ReadLine();
        }


        public void listenForKeys() {

            Stopwatch sw = new Stopwatch();
            sw.Start();

            line = 1;

            do {
                while (!Console.KeyAvailable) {
                    if (sw.ElapsedMilliseconds > 2000 || line == 1) // if time to update data or first iteration
                    {
                        line += 1;
                        displayData(line);
                        sw.Restart();
                    }
                }  // end of while no key available


                cki = Console.ReadKey();
                ClearCurrentConsoleLine();

                if (cki.KeyChar == 'w') {
                    /*stocks.getStocksByName("paypal").buy();
                    displayData(line);*/

                    if (marker.moveUp()) {
                        WriteAt("   ", 12, marker.previous); // clear
                    }
                    WriteAt("   ", 12, marker.current, currentColor);
                }
                if (cki.KeyChar == 's') {
                    if (marker.moveDown())
                    {
                        WriteAt("   ", 12, marker.previous); // clear
                    }
                    WriteAt("   ", 12, marker.current, currentColor);

                }
                if (cki.KeyChar == 'd') {
                    currentColor = "green";

                    stocks.getStocksByID(marker.getIndexedCurrent()).buy();
                    displayData(line);
                }
                if (cki.KeyChar == 'a')
                {
                    currentColor = "red";
                    stocks.getStocksByID(marker.getIndexedCurrent()).sell();
                    displayData(line);
                }

                if (cki.KeyChar == 'e') {
                    stocks.liquidateStocks();
                }



            } while (cki.Key != ConsoleKey.Escape);

            Console.Clear();
            Console.WriteLine("Game Over, all assets were liquidated");
            int i = 500;
            while (i >= 100) {
                Console.Beep(i, 100);
                i -= 10;
            }
            stocks.liquidateStocks();
            displayPortfolioData();
            Console.ReadLine();
        }

        public static void WriteAt(string s, int left, int top, string color = "asd") {
            int l = Console.CursorLeft;
            int t = Console.CursorTop;

            Console.SetCursorPosition(left, top);
            if (color.ToLower() == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (color.ToLower() == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            
            Console.Write(s);
            Console.ResetColor();

            Console.SetCursorPosition(l, t);
        }

        public void displayData(int line) {
            
            Console.SetCursorPosition(0, 1);
            foreach (Portfolio.assets.Stock s in stocks.getStocks())
            {

                s.currentPrice = s.grabPrice(line);
                fcol(s.name, s.ticker, s.shares, s.currentPrice, s.avgCost, s.investment, s.currentValue, s.totalReturn, s.percentReturn);
            }

            displayPortfolioData();

            WriteAt("   ", 12, marker.current, currentColor);

            
        }

        public void displayPortfolioData() {
            Portfolio.Statistics.Balance.setNetWorth(stocks); // need to set net worth
            double cashDisplayed = Math.Round(Portfolio.Statistics.Balance.cash, 2);
            double netWorthDisplayed = Math.Round(Portfolio.Statistics.Balance.netWorth, 2);

            Console.WriteLine($"\nCash: {cashDisplayed} Net Worth: {netWorthDisplayed}");
        }















        public static void fcol(string a, string b, string c, string d, string e, string f, string g, string h, string i) {
            Console.WriteLine("{0,-16} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-12} | {6,-12} | {7,-12} | {8,-12}", a, b, c, d, e, f, g, h, i);
        }
        public static void fcol(string a, string b, double c, double d, double e, double f, double g, double h, double i)
        {
            c = Math.Round(c, 2);
            d = Math.Round(d, 2);
            e = Math.Round(e, 2);
            f = Math.Round(f, 2);
            g = Math.Round(g, 2);
            h = Math.Round(h, 2);
            i = Math.Round(i, 2);
            Console.WriteLine("{0,-16} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-12} | {6,-12} | {7,-12} | {8,-12}", a, b, c, d, e, f, g, h, i);

        }


        public static void ClearCurrentConsoleLine() {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
