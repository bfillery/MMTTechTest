using GradeBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

        static void Main()
        {
            //using var book = new Book("Bruce's book");

            using var book = new DiskBook("Bruce's grade book");

            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);            

            if(book.GetGrades().Count > 0)
            {
                book.GetStatistics();

            }
            book.OutputResults();
            Console.WriteLine("Complete!");

        }

        private static void EnterGrades(Book book)
        {
            Console.WriteLine("Enter a grade value between 0.00 and 100.00, or Q to exit.");
            var input = Console.ReadLine();

            while (input.ToUpper() != "Q")
            {
                var result = double.TryParse(input, out double grade);

                try
                {
                    if (result == true)
                    {
                        book.AddGrade(grade);
                        Console.WriteLine("Another? or Q to exit.");
                    }

                    else
                    {
                        Console.WriteLine("No: enter a value between 0.00 and 100.00, or Q to exit.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Out of range value: {e.Message} {grade}. Try again (or Q to exit)");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Uknown/ unexpected error occurred: {e.Message}");
                }

                finally
                {
                    input = Console.ReadLine();
                }
            }
        }

    }
}
