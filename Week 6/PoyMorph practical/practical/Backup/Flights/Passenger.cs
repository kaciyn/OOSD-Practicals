using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights
{

    class Passenger: Flight
    {
        private string theAirline;
        private string theDestination;
        private string theDepartureTime;
        private int thePassengerCount;

        public string airline
        {
            get
            {
                return theAirline;
            }
            set
            {
                theAirline = value;
            }
        }

        public string destination
        {
            get
            {
                return theDestination;
            }
            set
            {
                theDestination = value;
            }
        }

       /* public string departureTime
        {
            get
            {
                return theDepartureTime;
            }
            set
            {
                theDepartureTime = value;
            }
        }*/

        public int passengerCount
        {
            get
            {
                return thePassengerCount;
            }
            set
            {
                thePassengerCount = value;
            }
        }
        public void print()
        {
            Console.WriteLine("Passenger Flight");
            Console.WriteLine(theAirline);
            Console.WriteLine(theDestination + " : " + theDepartureTime);
            Console.WriteLine("Passenger count = " + thePassengerCount);
            
        }
    }
}
