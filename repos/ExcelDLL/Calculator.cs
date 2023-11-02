namespace ExcelDLL
{
    //http://www.geeksengine.com/article/create-dll.html#:~:text=%20%20%201%20Create%20a%20new%20C,the%20DLL%20in%20your%20VBA%20code.%20More%20

    //https://stackoverflow.com/questions/7092553/turn-a-simple-c-sharp-dll-into-a-com-interop-component#:~:text=%20Turn%20a%20simple%20C%23%20DLL%20into%20a,along%20with%20the%20rest%20of%20your...%20More%20

    using System.Runtime.InteropServices;



    public class Calculator
    {

        private decimal NumberOne { get; set; }
        private decimal NumberTwo { get; set; }

        public Calculator(decimal NumberOne, decimal NumberTwo)
        {
            this.NumberOne = NumberOne;
            this.NumberTwo = NumberTwo;
        }

        [ComVisible(true)]

        public decimal AddThem()
        {
            return NumberOne + NumberTwo;
        }

        [ComVisible(true)]
        public decimal SubtractThem()
        {
            return NumberOne - NumberTwo;
        }

        [ComVisible(true)]

        public decimal MultiplyThem()
        {
            return NumberOne * NumberTwo;
        }

        [ComVisible(true)]
        public decimal DivideThem()
        {
            return NumberOne / NumberTwo;
        }
    }

}
