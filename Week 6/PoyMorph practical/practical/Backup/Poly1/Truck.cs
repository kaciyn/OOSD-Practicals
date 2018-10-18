using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poly1
{
    class Truck:Vehicle
    {
        private int theWeight;
    
        public int weight
        {
            get
            {
                return theWeight;
            }
            set
            {
                theWeight = value;
            }
        }
    
        public new void print()
        {
            Console.WriteLine("Truck");
            Console.WriteLine("Weight: " + weight);
        }
    }
}
