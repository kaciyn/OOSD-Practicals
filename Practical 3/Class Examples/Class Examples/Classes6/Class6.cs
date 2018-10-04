using System;

namespace Classes6
{
	/// <summary>
	/// Summary description for Class6.
	/// </summary>
	class Class6
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{

			// this demonstrates the use of static and instance methods
			Profile pf1=new Profile("000");
			pf1.Name="Fred Smith"; 	
			pf1.Telephone="123456"; 
			Profile pf2=new 	Profile("001");
			pf2.Name="Joe Cannon"; 	
			pf2.Telephone="223456"; 
			Profile pf3=new 	Profile("002");
			pf3.Name="Ian Biggs"; 	
			pf3.Telephone="223456"; 
			
			// call the static (class)  method...
			Profile.HowMany();// note the Class name is used here
			
			//call the instances (objects) method...
			pf1.Display();// note the Instance (object) name is used here
			pf2.Display();
			pf3.Display();

			Console.ReadLine();
		}
	}
}
