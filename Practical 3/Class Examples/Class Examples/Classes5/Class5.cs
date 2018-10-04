using System;

namespace Classes5
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

			// Put code here to create 3 car instances

		    var car = new AnotherCar("Ford", "Mondeo") {Cost = 10};
		    var car1=new AnotherCar("Tesla","I don't know cars"){Cost = 10000000};
            var car2=new AnotherCar("Toyota","Prius"){Cost = 5000};
			// Add a method named 'Display'to the AnotherCar Class
			// This method should output the details of a  car instance
			// to the Console

			// Put code here to call that method to display the 
			// details of a each car instance 

           var anotherCar=new AnotherCar();
            anotherCar.Display(car);
		    anotherCar.Display(car1);
		    anotherCar.Display(car2);

        }
    }
}
