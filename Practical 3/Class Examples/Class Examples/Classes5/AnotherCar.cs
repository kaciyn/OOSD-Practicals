using System;

namespace Classes5
{
    /// <summary>
    /// Summary description for AnotherCar.
    /// </summary>
    public class AnotherCar
    {
        private string colour;
        private string type;
        private string make;
        private string country;
        private double cost;

        public AnotherCar() // constructor methods
        {
            country = "UK";
        }
        public AnotherCar(string m)
        {
            country = "UK";
            make = m;
        }
        public AnotherCar(string m, string t)
        {
            country = "UK";
            make = m;
            type = t;
        }

        public string Country // read only Property
        {
            get { return country; }

        }

        public string Colour //property for manipulating colour
        {
            get { return colour; }
            set { colour = value; }
        }
        public string Type //property for manipulating type
        {
            get { return type; }
            set { type = value; }
        }

        public string Make //property for manipulating make
        {
            get { return make; }
            set { make = value; }
        }
        public double Cost //property for manipulating cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public void Display(AnotherCar car)
        {
            Console.WriteLine(
                $"The car is a" +
                " " + car.Country +
                " " + car.Make +
                " " + car.Type +
                " " + car.Colour +
                " " + car.Cost
            );
            Console.ReadLine();
        }
    }
}
