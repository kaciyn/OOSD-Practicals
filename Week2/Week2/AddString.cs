using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class AddString
    {
        public static void AddNumbersInString()
        {
            Console.WriteLine("Please enter a comma delimited list of numbers you want added.");
            var numberStringsToAdd = Console.ReadLine().Split(',');
            double total = 0;

            foreach (var numberString in numberStringsToAdd)
            {
                total = total + Convert.ToDouble(numberString);
            }

            Console.WriteLine($"Total: {total}");

            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }
    }
}
