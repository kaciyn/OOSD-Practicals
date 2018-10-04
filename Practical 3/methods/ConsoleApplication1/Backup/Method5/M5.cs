using System;

namespace Method5
{
	//(returning arrays from methods)

	class M5
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			
			//We first declare a reference to an array in which to store the returned data  
			//(notice we don’t know its size yet)
			//This reference (usersData) will be assigned to the actual array that is returned from the called method
			int [] myData;

			// call method
			myData = GetData();

			// output to console
			for(int i= 0;i<myData.Length;i++)
			{
				Console.WriteLine(myData[i]);
			}
			Console.ReadLine();
		}

		static int [] GetData() //The method is declared as returning an array
		{

			int [] anArray = new int[10]; //The array to be returned must be created inside the method
  
			for (int x=0;x<anArray.Length;x++)
			{
				anArray[x] = x;
			}
   
			return anArray; //And then the array is returned from the method
		} 

		//watch both myData and anArray using Visual Studio debug
		// change this method to get the data (10 numbers) from the console

		// write a method to display the contents of myData
		// instead of the lnes following '// output to console' in Main
	}
}
