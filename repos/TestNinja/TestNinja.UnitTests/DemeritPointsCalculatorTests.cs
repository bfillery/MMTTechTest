using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator calculator;
        private int maxSpeed = DemeritPointsCalculator.GetMaxSpeed();


        [SetUp]
        public void SetUp()
        {
            calculator = new DemeritPointsCalculator();
        }


        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        [TestCase(500)]
        public void CalculateDemeritPoints_SpeedIsOutofRange_ShouldThrowArgumentOutOfRangeException(int speed)
        {
            //arrange
            //handled by setup

            //act
            //would throw exception

            //assert
            //use a delegate and combine act and assert steps
            Assert.That(() => calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }



        [Test]
        [TestCase(0,0)]
        [TestCase(64,0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int returnValue)
        {
            //arrange
            //handled by setup

            //act
            var result = calculator.CalculateDemeritPoints(speed);

            //assert
            Assert.That(result, Is.EqualTo(returnValue));
        }


    }
}
