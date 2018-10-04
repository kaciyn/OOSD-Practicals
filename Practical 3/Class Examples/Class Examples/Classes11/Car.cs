using System;

namespace Classes11
{
	/// <summary>
	/// Summary description for AnotherCar.
	/// </summary>
	public class Car
	{
			private string colour;
			private string type;
			private string make;
			private string country;
			private double cost; 

			public Car() // constructor methods
			{
				country="UK"; 
			}
			public Car(string m)
			{
				country="UK";
				make=m;
			}
			public Car(string m, string t)
			{
				country="UK";
				make=m; 	
				type=t;
			}

			public string Country // read only Property
			{
				get { return country; }
			
			}
		
			public string Colour //property for manipulating colour
			{
				get {return colour; }
				set {colour=value; 	}
			}
			public string Type //property for manipulating type
			{
				get {return type;}
				set {type=value;}
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
