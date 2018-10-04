using System;

namespace Classes2
{
	//In general it is considered good practice for 
	//Class data members (e.g. variables) to be declared
	//as being private.  This example shows the use of a 
	//technique called properties that provides access 
	//protection for the Class variables.  A property acts 
	//like a method (e.g. an accessor method in Java)  
	//It uses the keywords get (also known as an accessor) 
	//and set (also known as a mutator).  You do not declare 
	//the variable value, C# deals with this for you. 
 
	class Class2
	{
		static void Main(string[] args)
		{
			Car car1 = new Car();
			car1.Colour="Red";
			car1.Make="Ford";
			car1.Type="Mondeo";
			car1.Country="UK";
			car1.Cost=15000;
			Console.WriteLine(
				"Car is a " + car1.Make + " " + car1.Type);

		
			Console.ReadLine();
		}
	}

	//1) Step through the running of this code using F11.  
	//Watch the variables in the 'Locals' window.

	//2) Add the other Car properties to the Console.WriteLine 
	//statement  to the car instance then run the program again.

	//3) Add some more of your own car instances with values for 
	//all the properties.   Note that autocomplete works for the
	//properties of the Car classStep through the running of this 
	//code using F11.  Watch the variables in the 'Locals' window.

	//4 Put the Car Class in a separate code file (named Car.cs 
	//with the same namespace).  Step through the running of this 
	//code using F11.  Watch the variables in the 'Locals' window.

	//(Hint use: File/Add New Item/ Code File)

		public class Car
		{	
			private string colour;
			private string type;
			private string make;
			private string country;
			private double cost; 
		
		public string Colour //property for manipulating colour
		{
			get 
				{ 
					return colour; 
				}
			set 
				{ 
				colour=value; 
				}
			// usually the above is written in the more compact form shown below
		}
		public string Type //property for manipulating type
		{
			get {return type;}
			set { type=value;}
		} 
		public string Country //property for manipulating country
		{
			get { return country; }
			set { country=value; }				
		}
		public string Make //property for manipulating make
		{
			get { return make; }
			set { make=value; }	
		}
		public double Cost //property for manipulating cost
		{
			get { return cost; }
			set { cost=value; }	
		}
	}
}
