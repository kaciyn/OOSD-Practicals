using System;

namespace Classes3
{
	class Class2
	{
		static void Main(string[] args)
		{
			Car car1 = new Car();
			car1.Colour="Red";
			car1.Make="Ford";
			car1.Type="Mondeo";
			car1.Cost=15000;
			Console.WriteLine(
				"Car is a" + 
				" " + car1.Country + 
				" " + car1.Make + 
				" " + car1.Type +
				" " + car1.Colour +
				" " + car1.Cost
				);
		
			Console.ReadLine();
		}
	}
}
