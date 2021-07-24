using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            var query =
                from c in context.Courses
                //where c.Author.Id == 1
                group c by c.Level into g
                //orderby c.Level descending, c.Name
                //select new { Name = c.Name, Author = c.Author.Name};
                select g;



            // Linq syntax
            //var query =
            //    from c in context.Courses
            //    where c.Name.Contains("c#")
            //    orderby c.Name
            //    select c;

            //foreach (var course in query)
            //    Console.WriteLine(course.Name);


            //extension methods
            //var courses = context.Courses
            //    .Where(c => c.Name.Contains("c#"))
            //    .OrderBy(c => c.Name);


            foreach (var group in query)
            {
                Console.WriteLine("{0} ({1})",group.Key,group.Count());
                //Console.WriteLine(group.Key);

                //foreach (var course in group)
                //{
                //    Console.WriteLine("\t{0}", course.Name);
                //    //Console.WriteLine("\t{0}", course.Description);
                //}
            }
        }
    }
}
