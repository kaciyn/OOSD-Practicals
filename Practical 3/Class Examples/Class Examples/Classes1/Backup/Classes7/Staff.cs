using System;

namespace Classes7
{
	/// <summary>
	/// Summary description for Staff.
	/// </summary>
	public class Staff : People // Inherit from People
		{ 
			public void Display() 
			{
				Console.WriteLine("Name: "+Name);
			}
		}
}
