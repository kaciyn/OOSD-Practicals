using System;
using System.Collections;

namespace Classes9
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class9
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			ArrayList colourList = new ArrayList();

			Colour c1 = new Colour("Red");
			colourList.Add(c1);
			Colour c2 = new Colour("Orange");
			colourList.Add(c2);
			Colour c3 = new Colour("Yellow");
			colourList.Add(c3);

			foreach (Colour  c in colourList)
			{
					System.Console.WriteLine("{0}",c.Name);
			}

			Console.ReadLine();

		
		}
	}
}
