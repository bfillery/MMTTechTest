using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public static class NumberHelper
    {

        public static int CountDivisible(int from, int to, int divisor)
        {
            int counter = 0;

            for (int i = from; i <= to; i++)
            {
                if (i % divisor == 0) counter++;
            }

            return counter;
        }

        public static long GetFactorial(int number)
        {
            if (number < 0)
                throw new ArithmeticException("Cannot compute factorial of negative integer");

            if (number == 0 || number == 1)
                return 1;


            long result = number;
            for (long i = number - 1; i > 0; i--)
            {
                result *= i;
            }
            return result;

        }

        public static long GetFactorialRecursively(int number)
        {
            if (number < 0)
                throw new ArithmeticException("Cannot compute factorial of negative integer");

            if (number == 0 || number == 1)
                return 1;

            //sexy recursion :)
            return number * GetFactorial(number - 1);

        }

        public static bool IsNumeric(string s)
        {
            return int.TryParse(s, out int n);
        }


        public static int GetMaxFromList(string response, char separator)
        {
            string[] chars = response.Split(separator);

            int maxNumber = 0;

            foreach (var entry in chars)
            {
                if (NumberHelper.IsNumeric(entry))
                {
                    bool success = int.TryParse(entry, out int value);
                    if (success && (value > maxNumber)) maxNumber = value;
                }
            }

            return maxNumber;
        }
    }
}
