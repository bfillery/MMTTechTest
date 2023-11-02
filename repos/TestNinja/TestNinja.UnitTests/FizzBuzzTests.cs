using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDivisibleByFiveAndThree_ShouldReturnFizzBuzz()
        {
            //arrange

            //act
            var result = FizzBuzz.GetOutput(15);

            //assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleByFiveOnly_ShouldReturnBuzz()
        {
            //arrange

            //act
            var result = FizzBuzz.GetOutput(5);

            //assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleByThreeOnly_ShouldReturnFizz()
        {
            //arrange

            //act
            var result = FizzBuzz.GetOutput(3);

            //assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputIsZero_ShouldReturnFizzBuzz()
        {
            //arrange

            //act
            var result = FizzBuzz.GetOutput(0);

            //assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputNotDivisibleByFieOrThree_ShouldReturnSameNumber()
        {
            //arrange

            //act
            var result = FizzBuzz.GetOutput(4);

            //assert
            Assert.That(result, Is.EqualTo("4"));
        }
    }
}
