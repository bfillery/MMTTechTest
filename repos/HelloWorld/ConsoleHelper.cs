using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class ConsoleHelper
    {
        public static void ClearAndAnnounce(string message)
        {
            const string underline = @"-------------------------------";
            
            Console.Clear();
            Console.WriteLine(message.ToUpper());
            Console.WriteLine(underline);
            Console.WriteLine("\n");
        }

        public int PromptForValue(string promptText, string exitCode = "OK", int numberOfTries = 0)
        {
            bool success = false;
            var result = string.Empty;
            int returnValue = 0;



            while (!success || numberOfTries > 0)
            {
                Console.WriteLine(promptText);
                result = Console.ReadLine();

                numberOfTries--;

                if (result == exitCode)
                {
                    returnValue = 0;
                    break;
                }

                success = int.TryParse(result, out returnValue);
            }

            return returnValue;
        }
    }
}
