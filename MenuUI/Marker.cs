using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuUI
{
    public class Marker
    {
        private int min, max;

        public int current { get; set; }
        public int previous { get; private set; }


        public Marker(int min, int range, int current = 0) { // INCLUSIVE
            if (current == 0) current = min; // if current not set, it is equal to min value;
            this.min = min;
            this.max = min + range - 1;
            this.current = current;
            this.previous = current;

        }

        public int getIndexedCurrent() {   // ex 3-11 becomes 0-8

            return current - min;
        }

        public bool moveUp() {
            if (current - 1 >= min) {
                previous = current;
                current -= 1;
                return true;
            }
            return false;
        }

        public bool moveDown() {
            if (current + 1 <= max)
            {
                previous = current;
                current += 1;
                return true;
            }
            return false;
        }
    }
}
