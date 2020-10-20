using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace stonks2
{
    class Portfolio
    {
        private double cash = 10000;
        private double netWorth = 10000;

        public Portfolio() {
            switch (StartMenu.startBalance_active) {
                case 0:
                    this.cash = 1000;
                    break;
                case 1:
                    this.cash = 10000;
                    break;
                case 2:
                    this.cash = 100000;
                    break;
                default:
                    this.cash = 10000;
                    break;
            }
            this.netWorth = this.cash;
        }

        public double Cash
        {
            get { return cash; }
            set { cash = value;  }
        }

        public double NetWorth
        { 
        
            get { return netWorth;  }
            set { netWorth = value; }
        }

        public void display() {
            
            Console.WriteLine($"Cash: {StatHelp.round(this.cash, 2)}\nNet Worth: {StatHelp.round(this.netWorth, 2)}");
        }

        
    }
}
