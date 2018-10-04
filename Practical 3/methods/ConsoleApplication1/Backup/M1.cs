using System;
namespace Method1
{
	class M1
	{
		static void Main(string[] args)
		{
			SayHello();
			
			Console.ReadLine();
		}

		//Method with no arguments in the round brackets: no arguments are passed to it 
		//keyword void:  no return arguments
		static void SayHello()
		{
			Console.WriteLine("Hello");
		}
		//add a few more SayHello(); lines to demonstrate stepping into

		//Note: The main  method always executes first
		//Then it calls  the SayHello() method
		//The SayHello() method just produces a console with the message “hello”
		//Control then returns to the main method
	}
}
