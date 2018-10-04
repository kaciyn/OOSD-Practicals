using System;

namespace Classes10
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			PaintShop aShop = new PaintShop();

			Colour2 c1 = new Colour2("Red");
			aShop.colourList.Add(c1);
			Colour2 c2 = new Colour2("Orange");
			aShop.colourList.Add(c2);
			Colour2 c3 = new Colour2("Yellow");
			aShop.colourList.Add(c3);

			foreach (Colour2  c in aShop.colourList)
			{
				System.Console.WriteLine("{0}",c.Name);
			}
			System.Console.ReadLine();
		}
	}
}
