using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonks2
{
    class handler
    {
        Game g;
        Portfolio p;

        public handler(Game g, Portfolio p) {
            this.g = g;
            this.p = p;
        }

       
        private ArrayList stocks = new ArrayList();

        public ArrayList getStocks() {
            return stocks;
        }

        public int getLength() {
            return stocks.Count;
        }

        public void addObject(Stock s) {
            stocks.Add(s);
        }

        public void removeObject(Stock s) {
            stocks.Remove(s);
        }

        public void initAll(string color = "green") {

            Stock.initHeader();

            foreach (Stock s in stocks) {
              
                s.initData();
            }

            Stock.longLine();
            g.setRedBox(color);

            int t = Console.CursorTop;
            int l = Console.CursorLeft;

            Console.SetCursorPosition(0, 14);
            p.display();
            Console.SetCursorPosition(t, l);

        }

        public Stock getStocksByName(string name) {
            foreach (Stock s in stocks) {
                if (s.getName().ToLower() == name.ToLower()) {
                    return s;
                }

            }
            return null;
        }

        public Stock getStockById(int id) {
            foreach (Stock s in stocks) {
                if (s.getId() == id) {
                    return s;
                }
            }
            return null;
        }

       


    }
}
