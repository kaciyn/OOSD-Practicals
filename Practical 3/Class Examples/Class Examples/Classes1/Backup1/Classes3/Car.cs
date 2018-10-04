using System;

namespace Classes3
{
	/// <summary>
	/// Summary description for Class1.
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
			country="UK"; // in this example all new cars instances made for the UK market
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


