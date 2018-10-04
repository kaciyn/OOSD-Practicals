using System;
using System.Collections;
using System.Collections.Generic;

namespace Classes10
{
	/// <summary>
	/// Summary description for Rainbow.
	/// </summary>
	public class PaintShop
	{
	    public IList colourList = new List<Colour2>();

	    public void DisplayColours()
	    {
	        foreach (Colour2 colour in colourList)
	        {
	            System.Console.WriteLine("{0}", colour.Name);
            }
	        System.Console.ReadLine();

        }
        // add a display method that displays all the colours
        // in a PaintShop
    }
}
