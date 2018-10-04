using System;

namespace Classes
{

	class Classes1
	{
		static void Main(string[] args)
		{
			Cup cup = new Cup();
			cup.Colour = "Red";
			cup.Handle = "Small";
		    cup.Shape = "wonky";
		    cup.Size = "BIG";
		    cup.Transparency = 2;

            Cup cup1=new Cup();
		    cup1.Colour = "blue";
		    cup1.Handle = "average";
		    cup1.Shape = "curvy ;)";
		    cup1.Size = "middling";
		    cup1.Transparency = 100;

            cup.DisplayCup();
		    cup1.DisplayCup();

            // 1) step through the running of this code using F11
            //    watch the variables in the 'Locals' window

            // 2) add Shape, Size and Transparancy values to the above cup instance
            //    then run the program again

            // 3) add some more of your own cup instances
            //    with values for Colour, Handle, Shape, Size, Transparancy, and Handle
            //    step through the running of this code using F11
            //    watch the variables in the 'Locals' window

            System.Console.ReadLine();
		}
	}

	public class Cup 
	{
		public string Shape;
		public string Colour;
		public string Size;
		public int Transparency;
		public string Handle;

		public void DisplayCup()
		{
			System.Console.WriteLine("Cup is {0}, {1}", Colour, Handle);
		}

	}

	
}
