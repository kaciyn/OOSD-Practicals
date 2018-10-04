using System;

namespace Method2
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class M2
	{
		static void Main(string[] args)
		{
			string myName = "John";

			SayHello(myName);
			
			Console.ReadLine();
		}

		//Method with one argument in the round brackets: one argument of type string is passed to it 
		//Note... the value of myName is copied to Name (the variable itself is not changed)
		//keyword void:  no return arguments
		static void SayHello(string Name)
		{
				Console.WriteLine("Hello " + Name);
		}

		//add a few more myName = "John"; and SayHello(); lines 
		//to demonstrate stepping into

		//change the value of what is stored in Name to show that this does not affect the value of myName
		//e.g.
		//static void SayHello(string Name)
		//{
		// 	Name = Name.ToUpper();
		//	Console.WriteLine("Hello " + Name);
		//}	

	}
}
