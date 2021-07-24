using GradeBook.Interfaces;
using System;
using System.Threading;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        public Book GetBook()
        {
            var book = new Book("");

            book.AddGrade(89.2);
            book.AddGrade(90.5);
            book.AddGrade(78.3);

            return book;
        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = GetBook();
            var expected = 86;

            //act
            var stats = book.GetStatistics();

            //assert
            Assert.Equal(expected, stats.Average,1);
        }

        [Fact]
        public void BookCalculatesLetterGrade()
        {
            //arrange
            var book = GetBook();
            var expected = 'B';

            //act
            var stats = book.GetStatistics();

            //assert
            Assert.Equal(expected, stats.Letter);
        }

        [Fact]
        public void BookCalculatesTotalGrades()
        {
            //arrange
            var book = GetBook();
            var expected = 258;

            //act
            var stats = book.GetStatistics();

            //assert
            Assert.Equal(expected, stats.Total,1);
        }

        [Fact]
        public void BookIdentifiesHighestGrade()
        {
            //arrange
            var book = GetBook(); 
            var expected = 90.5;

            //act
            var stats = book.GetStatistics();

            //assert
            Assert.Equal(expected, stats.HighGrade,1);
        }

        [Fact]
        public void BookIdentifiesLowestGrade()
        {
            //arrange
            var book = GetBook();
            var expected = 78.3;

            //act
            var stats = book.GetStatistics();

            //assert
            Assert.Equal(expected, stats.LowGrade,1);
        }

        [Fact]
        public void BookDoesNotAcceptNegativeGrade()
        {
            //arrange
            var book = GetBook();
            var expected =book.GetGrades().Count;

            //act
            try
            {
                book.AddGrade(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops: {ex.Message}");
            }
            finally
            {
                //assert
                Assert.Equal(expected, book.GetGrades().Count);
            }
        }

        [Fact]
        public void BookDoesNotAcceptGreaterThan100Grade()
        {
            //arrange
            var book = GetBook();
            var expected = book.GetGrades().Count;

            //act
            try
            {
                book.AddGrade(150);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Oops: {ex.Message}");
            }
            finally
            {
                //assert
                Assert.Equal(expected, book.GetGrades().Count);
            }
            
        }
    }
}
