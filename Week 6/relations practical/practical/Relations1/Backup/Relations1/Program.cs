using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relations1
{
    class Program
    {
        static void Main(string[] args)
        {
            House myHouse = new House();
            
            Person fred = new Person();
            fred.name = "Fred";
            myHouse.addPerson(fred);

            Person jim = new Person();
            jim.name = "James";
            myHouse.addPerson(jim);

            Person sally = new Person();
            sally.name = "Sally";
            myHouse.addPerson(sally);

            Person rob = new Person();
            rob.name = "Rob";
            myHouse.addPerson(rob);

            Person alison = new Person();
            alison.name = "Alison";
            myHouse.addPerson(alison);

            myHouse.printPeople();

            Console.ReadLine();
        }
    }
}
