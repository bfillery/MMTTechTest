//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture] //[TestClass]
    public class ReservationTests
    {
        [Test]//[TestMethod]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange - initialise/ prepare object we want to test
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
        }

        [Test]//[TestMethod]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange - initialise/ prepare object we want to test
            var user = new User();
            var reservation = new Reservation{ MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]//[TestMethod]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            //Arrange - initialise/ prepare object we want to test
            var reservation = new Reservation{ MadeBy = new User() };

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.IsFalse(result);
        }
    }
}
