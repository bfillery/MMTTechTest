using GradeBook.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NuGet.Frameworks;
using System;
using System.Runtime.Serialization;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogMethod(string logMessage);

    public class TypeTests
    {
        public Book GetBook(string name)
        {
            return new Book(name);
        }

        int count = 0;

        string ReturnMessage (string message)
        {
            count++;
            return message.ToUpper() ;
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogMethod log = ReturnMessage;
            //CannotUnloadAppDomainException't increment an unassgned variable: could do log =... as a separate line'
            //could also do log = new WriteLogDelegate(ReturnMessage). 
            //Note: not ReturnMessage() - not INVOKING, just pinting

            log += ReturnMessage; //second hit
            log += IncrementCount; //hit this one too

            var result = log("Hello!"); //o: two hits to RetunMessage and one to INcrementCount

            Assert.Equal(3, count);

        }

        [Fact]
        public void StringsBehaveLikeValuetypes()
        {
            string name = "Bruce";
            var upper = MakeUpperCase(name);

            Assert.Equal("BRUCE", upper);
        }

        private string MakeUpperCase(string param)
        {
            return param.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();

            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");

            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.GetName());

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.SetName(name);
        }


        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");

            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.GetName());

        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.SetName(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.GetName());

        }

        private void SetName(Book book, string name)
        {
            book.SetName(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.GetName());
            Assert.Equal("Book 2", book2.GetName());
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }
    }
}
