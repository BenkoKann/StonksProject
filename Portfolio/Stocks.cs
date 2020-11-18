using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Portfolio
{
    public class Stocks
    {
        private ArrayList stocks = new ArrayList();

        public Stocks() {
            addObject(new Portfolio.assets.Stock("hawaii bank", "boh", getLength()));
            addObject(new Portfolio.assets.Stock("paypal", "pypl", getLength()));
            addObject(new Portfolio.assets.Stock("facebook", "fb", getLength()));
            addObject(new Portfolio.assets.Stock("s&p500", "gspc", getLength()));
            addObject(new Portfolio.assets.Stock("amazon", "amzn", getLength()));
            addObject(new Portfolio.assets.Stock("crude oil", "cl=f", getLength()));
            addObject(new Portfolio.assets.Stock("emerson electric", "emr", getLength()));
            addObject(new Portfolio.assets.Stock("costco", "cost", getLength()));
            addObject(new Portfolio.assets.Stock("macys", "m", getLength()));
            addObject(new Portfolio.assets.Stock("silver trust", "slv", getLength()));

        }
        public ArrayList getStocks()
        {
            return stocks;
        }

        public int getLength()
        {
            return stocks.Count;
        }

        public void addObject(assets.Stock s)
        {
            stocks.Add(s);
        }

        public void removeObject(assets.Stock s)
        {
            stocks.Remove(s);
        }

        public void liquidateStocks() { // sell all stocks
            foreach (assets.Stock s in stocks) {
                if (s.shares > 0) {
                    s.sell(s.shares);
                }
            }
        }

        public assets.Stock getStocksByName(string name)
        {
            foreach (assets.Stock s in stocks)
            {
                if (s.name.ToLower() == name.ToLower())
                {
                    return s;
                }

            }
            return null;
        }

        public assets.Stock getStocksByID(int id)
        {
            foreach (assets.Stock s in stocks)
            {
                if (s.id == id)
                {
                    return s;
                }

            }
            return null;
        }
    }
}
