using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights
{
    interface Flight
    {
     
        string airline
        {
            get;
            set;
        }

        string destination
        {
            get;
            set;
        }

        string departureTime
        {
            get;
            set;
        }


        void print();

    }
}
