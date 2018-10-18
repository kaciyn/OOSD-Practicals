using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relations1
{
    class Person
    {
        private int theAge;
        private string theName;

        public int age
        {
            get
            {
                return theAge;
            }
            set
            {
                theAge = value;
            }
        }

        public string name
        {
            get
            {
                return theName;
            }
            set
            {
                theName = value;
            }
        }
    }
}
