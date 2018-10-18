using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relations1
{
    class House
    {
        
        private Person[] people = new Person[4];
        private int count = 0;
        
        public void addPerson(Person aPerson)
        {
            if (count >= people.Length)
            {
                Console.WriteLine("The house is full!");
            }
            else
            {
                people[count] = aPerson;
                count++;
            }
            
        }

        public void printPeople()
        {
            for (int c = 0; c < count; c++)
            {
                Person p = people[c];
                Console.WriteLine(p.name);
            }
        }
    }
}
