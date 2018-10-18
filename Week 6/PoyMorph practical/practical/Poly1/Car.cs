using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poly1
{
    class Car:Vehicle
    {
        private int theSeats;
    
        public int seats
        {
            get
            {
                return theSeats;
            }
            set
            {
                theSeats = value;
            }
        }
    
        public new void print()
        {
            Console.WriteLine("Car ");
            Console.WriteLine("Seats:"+theSeats);

        }
    }
}
