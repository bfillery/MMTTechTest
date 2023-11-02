using HelloWorld.Fundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class SqlDbConnectionTests
    {
        private DbConnection dbConn;
        private const string connect 
            = @"Server=MYNEWLAPTOP\SQL2017DEV01;Database=IRSS_Live;Trusted_Connection=True;";

        [SetUp]
        public void SetUp()
        {
            dbConn = new SqlDbConnection(connect);
        }
        

        [Test]
        public void Open_WhenCalled_OpensDatabaseConnection()
        {
            //arrange
            const bool expectedResult = true;

            //act
            var result = dbConn.Open();

            //assert
            Assert.That(result,Is.EqualTo(expectedResult));
        }

        [Test]
        public void Close_WhenCalled_ClosesDatabaseConnection()
        {
            //arrange
            const bool expectedResult = true;

            //act
            var result = dbConn.Close();

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
