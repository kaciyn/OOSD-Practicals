using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class PrimeNumbers
    {
        public static void PrimeNumberPrinter()
        {
            Console.WriteLine("Please enter number between 1 and 10,000.");
            var numberToGetPrimesTo = Convert.ToInt64(Console.ReadLine());

            while (numberToGetPrimesTo > 10000 || numberToGetPrimesTo < 1)
            {
                Console.WriteLine("You weren't listening. Please enter number between 1 and 10,000.");
                 numberToGetPrimesTo = Convert.ToInt64(Console.ReadLine());
            }

            Console.WriteLine($"Printing all prime numbers from 1 to {numberToGetPrimesTo}");

            for (var number = 1; number < numberToGetPrimesTo; number++)
            {
                if (CheckIfIsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }

        static bool CheckIfIsPrime(int number)
        {
            int i;
            if (number == 1) return true;

            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
