using System;

namespace Method3
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class M3
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			int x = 5;
			int y = 10;
			string comparison = CompareSize(x, y);
			Console.WriteLine(comparison);
			Console.ReadLine();
		}

		//Method with two arguments passed to it  and one return value of type string
		//There are two argument of type string in the round brackets

		static string CompareSize(int number1, int number2)// note no ; here!!!
		{
			string answer = "";	
			if(number1 > number2) answer = number1.ToString() + " is bigger then " + number2.ToString();
			if(number1 < number2) answer = number1.ToString() + " is smaller then " + number2.ToString();
			if(number1 == number2) answer = number1.ToString() + " is equal to " + number2.ToString();
			return answer; //this returns the argument
		}

		// change the values of x and y to show that the program works

		//amend the program so that the user enters the values of x and y

	    // change to a windows application and use to compare the size of two labels 
		// the size of the labels should be controlled by the user via slider components


	}
}
