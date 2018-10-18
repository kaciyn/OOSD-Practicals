using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight p = new Passenger();
            p.airline = "BA";
           // p.departureTime = "12:00";
            p.print();
            Console.ReadLine();
        }
    }
}
