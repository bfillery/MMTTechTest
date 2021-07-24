using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{


    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger errorLogger;

        [SetUp]
        public void SetUp()
        {
            errorLogger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_ShouldSetTheLastErrorProperty()
        {
            //Arrange
            //Handled by SetUp


            //Act
            errorLogger.Log("a");

            //Assert
            Assert.That(errorLogger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ShouldThrowArgumentNullException(string error)
        {
            //Arrange
            //Handled by SetUp

            //Act
            // this would throw an error, rightly
            //errorLogger.Log(error); 

            //Assert 
            //use a delegate and combine act and assert steps
            Assert.That(() => errorLogger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorloggedEvent()
        {
            //Arrange, Handled in part by SetUp
            var id = Guid.Empty;

            //subscribe to event with Lambda expression
            errorLogger.ErrorLogged += (sender, args) => { id = args; };

            //Act
            errorLogger.Log("a");


            //Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
