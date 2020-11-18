using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.assets
{
    public class Stock
    {
        public string name { get; set; }
        public string ticker { get; set; }

        public int shares { get; set; }
        public double currentPrice { get; set; }

        public double avgCost { get; set; } 

        public double investment { get; set; }

        public double currentValue { get; set; }

        public double totalReturn { get; set; }

        public double percentReturn { get; set; }
        

        public int id { get; private set; }

        private string[] data;

     //   int id;

        public Stock(string name, string ticker, int id) {
            this.name = name;
            this.ticker = ticker;

            this.data = System.IO.File.ReadAllLines($@"../../../Portfolio/assets/stockData/{this.ticker}.txt");
            
            this.currentPrice = grabPrice(1);

            this.id = id; // 0 BASED INDICIES
            
        }

        public void buy(int shares = 1) {
            
            double moneySpent = this.currentPrice * shares;
            if (moneySpent <= Portfolio.Statistics.Balance.cash) {
                Console.Beep(1046, 50);
                this.shares += shares;
                this.investment += moneySpent;
                Portfolio.Statistics.Balance.cash -= moneySpent;
                this.avgCost = this.investment / this.shares;
                currentValue = this.shares * this.currentPrice; // update current value of stock
            }

           

        }

        public void sell(int shares = 1) {
            
            if (this.shares >= shares) { // if amount of shares you have is greater than or equal to amount wanting to sell
                Console.Beep(523, 50);
                this.investment -= this.avgCost * shares; // must go before avg cost can be set to 0
                this.shares -= shares; // shares is m
                if (this.shares == 0)
                {
                    this.avgCost = 0;
                 //   this.investment = 0;
                }
                double moneyGained = this.currentPrice * shares;
                Portfolio.Statistics.Balance.cash += moneyGained;
                currentValue = this.shares * this.currentPrice; // update current value of stock


            }
            
        }

        public double grabPrice(int line) {
            string result = data[line];
            string[] splitData = result.Split(',');
            result = splitData[4];

            updateReturn();


            return stringToDouble(result);

        }

        public void updateReturn() {  // updates totalReturn and percentReturn
            currentValue = this.shares * this.currentPrice;
            totalReturn = currentValue - investment;
            if (shares == 0)
            {
                percentReturn = 0;
            }
            else {
                percentReturn = (totalReturn / investment) * 100;
            }
            
        }

        public double stringToDouble(string s) {
            double output;
            if (Double.TryParse(s, out output))
            {
                return output;
            }

            return -1;
           
        }
    }
}
