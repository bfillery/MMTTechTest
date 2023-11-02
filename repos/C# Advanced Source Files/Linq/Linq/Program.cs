using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            //b GOES TO the condition "b.Price <10" and, if this evaluates to True, 
            //then the b in question (here, a Book) will be added to the list output as 'cheapBooks'

            //LINQ Extension methods (probably more powerful)
            var cheapBooks = books
                                .Where(b => b.Price < 10)
                                .Skip(2)  //used for paging
                                .Take(3)
                                .OrderBy(b => b.Price)
                                .Select(b => b.Title); //here, using Select to pick a property
            //also:
            //*Count
            //*Max: e.g.   .Max(b=> b.Price)
            //*Min
            //*Sum: e.g.   .Sum(b=> b.Price)
            //*Average
            
            Console.WriteLine("cheapBooks");

            foreach (var cheapBook in cheapBooks)
                //Console.WriteLine($"Title: {book.Title} costs {book.Price}");
                Console.WriteLine($"Title: {cheapBook}");

            Console.WriteLine();








            //*Single = one and only one
            //*SingleOrDefault - returns default, here null, rather than automatic error
            //*First - first occurring instance in collection. Can supply a predicate
            //*FirstOrDefault - as with above
            //*Last, or LastOrDefault
            //var book = books.Single(b => b.Title == "ASP.NET MVC");
            //Console.WriteLine($"Single book: {book.Title}");

            ////LINQ query operators (more friendly for grouping)
            //var evenCheaperBooks = from b in books
            //                       where b.Price < 9
            //                       orderby b.Price
            //                       select b.Title;

            //Console.WriteLine("evenCheaperBooks");

            //foreach (var book in evenCheaperBooks)
            //    Console.WriteLine($"Title: {book}"); 

            //Console.WriteLine();




            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(2, 3).ToString("C2", CultureInfo.CurrentCulture));
        }

        private static float CalculateDiscount(float price)
        {
            return 0;
        }

    
    }
}
