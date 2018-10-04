using System;

namespace Classes4
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class4
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
			{
				Cars car1 = new Cars();// contructor method with no arguments passed
				car1.Colour="Red";
				car1.Make="Ford";
				car1.Type="Mondeo";
				car1.Cost=15000;
				Console.WriteLine(
					"Car1 is a" + 
					" " + car1.Country + 
					" " + car1.Make + 
					" " + car1.Type +
					" " + car1.Colour +
					" " + car1.Cost
					);

			Cars car2 = new Cars("Vauxhall");// contructor method with one argument passed
			car2.Colour="Blue";
			car2.Type="Astra";
			car2.Cost=20000;
			Console.WriteLine(
				"Car2 is a" + 
				" " + car2.Country + 
				" " + car2.Make + 
				" " + car2.Type +
				" " + car2.Colour +
				" " + car2.Cost
				);

			//write your own code that uses the constructor
			//that takes two arguments

			// then change the Cars Class to add a constructor method 
			// that takes three arguements
		
				Console.ReadLine();
			}
	}
}
