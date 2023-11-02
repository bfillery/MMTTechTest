
using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime? date = null; //'DateTime?' instead of 'Nullable<DateTime>'
            DateTime date2 = date ?? DateTime.Today;

            DateTime date3 = (date != null) ? date.GetValueOrDefault() : DateTime.Today;



            Console.WriteLine(date2);



        }
    }
}
