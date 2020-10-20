using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonks2
{
    class Stock
    {
        // TEXT FILE DATA IS FROM EARLIEST POSSIBLE I COULD GET TO NOW. IT IS WEEKLY DATA



        // DISPLAYED INFO /////////////////////////////////////
        private string name; // name of stock
        private double shares = 0;
        private double currentPrice; // latestPrice
        private double avgCost;
        private double investment;
        private double currentValue;
        private double totalReturn;
        private double percentReturn;
        //////////////////////////////////////////////////////
        private string ticker;
        private int id; // used for reference when user move cursor up and down, tells game class to buy or sell stock with certain id.

        private string[] data;






        // private double change = 0;



        Portfolio p;

        public Stock(string name, string ticker, Portfolio p, handler h) {
            this.name = name;
            this.ticker = ticker;
          //  this.currentPrice = currentPrice;
            this.p = p;

            this.id = h.getLength()+1; // if no stocks in arraylist, id=1. if 1 stock in arraylist, id=2

            this.data = System.IO.File.ReadAllLines($@"C:\Users\aqwxcdrvtb\source\repos\stonks2\stonks2\data\{this.ticker}.txt");



        }

        public void RUdata(int line) {  // READ UPDATE DATA
            string result = data[line]; // -4.12%
            string[] splitData = result.Split(',');
            result = splitData[4]; // gets the close data of stock
            setCurrentPrice(result);

            // update other metrics that are being updatated every n seconds
            currentValue = this.shares * this.currentPrice;
            totalReturn = currentValue - investment;
            if (shares == 0) {
                percentReturn = 0;
            } else {
                percentReturn = (totalReturn / investment) * 100;
            }
                
        }

        public void setCurrentPrice(string str) {  // 9.32% // -5.51%

            double output;
            if (Double.TryParse(str.Substring(0, str.Length - 1), out output)) {  // convert percent to double
                /*double cp = getCurrentPrice();
                double addTo = currentPrice * (output/100); // multiplies decimal form of percent with the currentprice
                cp += addTo;
                this.currentPrice = cp;*/
                this.currentPrice = output;

                // currentPrice = output;
            }

        }


        public double getCurrentPrice() {
            return this.currentPrice;
        }

        public double getCurrentValue() {
            return this.currentValue;
        }

    

    /*    public void setChange(string str) { // 9.32% // -5.51%
            this.change = str;
        }*/

        public void buy() {
            if (p.Cash - this.currentPrice > 0) {

                this.shares += 1;
                this.investment += this.currentPrice;
                this.avgCost = this.investment / this.shares; // average cost per share
                                                              //this.currentValue = this.shares * this.currentPrice; // num of shares times price of each share// needs to be moved to class of stock ahd be handled
                p.Cash -= this.currentPrice;
            }
            

        }
        
        public void sell()
        {
            
            if (this.shares > 0) {
                this.shares -= 1;
                this.investment -= this.avgCost;
                p.Cash += this.currentPrice;
            }

            if (this.shares == 0)
            {
                this.avgCost = 0; // no average cost of no shares
            }


            
        }



        public static void initHeader() {
            longLine();
            fcol("name", "shares", "currentPrice", "avgCost", "investment", "currentValue", "totalReturn", "percentReturn");
            longLine();
        }

        public void initData() {
            /* Console.WriteLine($"{this.name}\n{this.currentPrice}\n{this.change}\n{this.totalVal}\n{this.shares}");*/
            fcol(name, shares, currentPrice, avgCost, investment, currentValue, totalReturn, percentReturn);
        }



        public static void fcol(string a, double b, double c, double d, double e, double f, double g, double h) {
            b = StatHelp.round(b, 2);
            c = StatHelp.round(c, 2);
            d = StatHelp.round(d, 2);
            e = StatHelp.round(e, 2);
            f = StatHelp.round(f, 2);
            g = StatHelp.round(g, 2);
            h = StatHelp.round(h, 2);
           //  Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("{0,-16} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-12} | {6,-12} | {7,-12}", a, b, c, d, e, f, g, h+"%");
            // Console.ForegroundColor= ConsoleColor.White;

        }

        public static void fcol(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            /*StatHelp.round(b, 2);
            StatHelp.round(c, 2);
            StatHelp.round(d, 2);
            StatHelp.round(e, 2);
            StatHelp.round(f, 2);*/
            Console.WriteLine("{0,-16} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-12} | {6,-12} | {7,-12}", a, b, c, d, e, f, g, h);
        }

        public static void longLine() {
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        public string getName() {
            return this.name;
        }

        public int getId() {
            return this.id;
        }
        public double getShares()
        {
            return this.shares;
        }
    }
}
