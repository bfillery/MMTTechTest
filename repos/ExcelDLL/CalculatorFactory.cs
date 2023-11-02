
using System.Runtime.InteropServices;


namespace ExcelDLL
{

    //https://stackoverflow.com/questions/32810787/vba-importing-com-registered-dll-and-calling-constructor-with-arguments
    public class CalculatorFactory
    {
        [ComVisible(true)]

        public Calculator Create(decimal NumberOne, decimal NumberTwo) => new Calculator(NumberOne, NumberTwo);
    }
}
