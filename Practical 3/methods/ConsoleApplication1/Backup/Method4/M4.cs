using System;

namespace Method4
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class M4 
	{
		//(Passing Arrays as arguments to Methods)

		[STAThread]
		static void Main(string[] args)
		{
			int[] myArray = {1,2,3,4,5};
			MultiplyByTen(myArray);
			// output to console
			for(int i= 0;i<myArray.Length;i++)
			{
				Console.WriteLine(myArray[i]);
			}
			Console.ReadLine();
		}
		static void MultiplyByTen(int[] anArray)// note we don't specify the length of the array
		{
			for(int i= 0;i<anArray.Length;i++)
			{
				anArray[i] = anArray[i]*10;
			}
		}

		//watch both myArray and anArray

		//Arrays are different...

		//When an array is passed to a method only a reference to that array is passed
																				  
		//The array is NOT copied. 
		
		//This means that any changes to the array in the method WILL change the original array!

	}
}

