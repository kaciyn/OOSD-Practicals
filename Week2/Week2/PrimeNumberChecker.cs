using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class PrimeNumberChecker
    {
        public static void ConfirmPrimeNumber()
        {
            Console.WriteLine("Please enter number you want to check is a prime.");
            var numberToCheckIfPrime = Convert.ToInt32(Console.ReadLine());
            

            Console.WriteLine($"{CheckIfIsPrime(numberToCheckIfPrime)}");

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
