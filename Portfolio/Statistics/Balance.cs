using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Statistics
{
    public static class Balance
    {
        public static double cash { get; set; }
        public static double netWorth { get; set; }

        // needs to take in a stocks object so has acess to other stocks
        public static void setNetWorth(Stocks stocks) { // sums up value of each stock and adds current cash. That total is net worth.
            double nw = 0;
            foreach (assets.Stock s in stocks.getStocks()) {
                nw += s.currentValue;
            }

            nw += cash;
            netWorth = nw;
        }

    }
}
