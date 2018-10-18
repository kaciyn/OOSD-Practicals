using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poly1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> fleet = new List<Vehicle>();

            Car c = new Car();
            c.make = "Ford";
            c.registration = "abc 123";
            c.seats = 5;

            fleet.Add(c);

            Truck t = new Truck();
            t.make = "Big Truck";
            t.registration = "def 456";
            t.weight = 10;

            fleet.Add(t);

            foreach (Vehicle v in fleet)
            {
                v.print();
            }
            Console.ReadLine();
        }
    }
}
