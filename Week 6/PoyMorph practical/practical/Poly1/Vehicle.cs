using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poly1
{
    class Vehicle
    {
        private string theMake;
        private string theRegistration;

        public string make
        {
            get
            {
                return theMake;
            }
            set
            {
                theMake = value;
            }
        }

        public string registration
        {
            get
            {
                return theRegistration;
            }
            set
            {
                theRegistration = value;
            }
        }

        public void print()
        {
            Console.WriteLine("Registration :" +theRegistration);
            Console.WriteLine("Make :" + theMake);

        }
    }
}
