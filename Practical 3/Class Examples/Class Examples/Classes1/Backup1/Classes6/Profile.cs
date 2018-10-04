using System;

namespace Classes6
{
	/// <summary>
	/// Summary description for Profile.
	/// </summary>
	public class Profile
	{
		private static int numberProfile=0;// a static variable
		private string code;
		private string name;
		private string telephone;
	
		// Constructor
		public Profile(string c)
		{
			numberProfile++;
			code=c;
		}

		public string Name //property for manipulating name
		{
			get {return name; }
			set {name=value; 	}
		}
		public string Telephone //property for manipulating telephone
		{
			get {return telephone; }
			set {telephone=value; 	}
		}
		//Instance Method

		public void Display()
		{
			Console.WriteLine(code + " " 
				+ name + " " + telephone);
		}		

			
		// Static Method
		public static void HowMany()
		{
			Console.WriteLine("There are " + numberProfile + " profiles ");
		}
	}
	
}
