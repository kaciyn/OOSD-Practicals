using System;

namespace Classes4
{
	/// <summary>
	/// Summary description for Class2.
	/// </summary>
	public class Cars
	{
		
		private string colour;
		private string type;
		private string make;
		private string country;
		private double cost; 

		public Cars() // constructor methods
		{
			country="UK"; 
		}
		public Cars(string m)
		{
			country="UK";
			make=m;
		}
		public Cars(string m, string t)
		{
			country="UK";
			make=m; 	
			type=t;
		}

	    public Cars(string m, string t,string c)
	    {
	        country = "UK";
	        make = m;
	        type = t;
	        colour = c;
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

