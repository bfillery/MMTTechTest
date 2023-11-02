using NUnit.Framework;
using System;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class NumberHelperTests
    {
        [Test]
        [TestCase(1,10,3,3)]
        [TestCase(1, 100, 3, 33)]
        public void CountDivisible_WhenCalled_ReturnsCount(int from, int to, int divisor, int expectedresult)
        {
            //arrange


            //act
            var result = NumberHelper.CountDivisible(from, to, divisor);

            //assert
            Assert.That(result, Is.EqualTo(expectedresult));
        }


        [Test]
        [TestCase(2,2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        public void GetFactorial_WhenCalled_ReturnsFactorial(int target, long expectedResult)
        {
            //arrange


            //act
            var result = NumberHelper.GetFactorial(target);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
           }


        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void GetFactorial_NegativeNumber_ThrowsArithmeticException(int target)
        {
            //arrange


            //act
            //use a delegate and combine act and assert steps

            //assert
            Assert.That(() => NumberHelper.GetFactorial(target),
                Throws.Exception.TypeOf<ArithmeticException>());
        }



        [Test]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        public void GetFactorialRecursively_WhenCalled_ReturnsFactorial(int target, long expectedResult)
        {
            //arrange


            //act
            var result = NumberHelper.GetFactorialRecursively(target);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void GetFactorialRecursively_NegativeNumber_ThrowsArithmeticException(int target)
        {
            //arrange


            //act
            //use a delegate and combine act and assert steps

            //assert
            Assert.That(() => NumberHelper.GetFactorialRecursively(target),
                Throws.Exception.TypeOf<ArithmeticException>());
        }






        [Test]
        [TestCase("1",true)]
        [TestCase("-1", true)]
        [TestCase("1000", true)]
        [TestCase("1,000", false)]
        [TestCase("1.23456", false)]
        [TestCase("", false)]
        [TestCase("Hello world", false)]
        [TestCase("£10", false)]
        public void IsNumeric_Whencalled_ReturnsNumeracyCheck(string check, bool expectedResult)
        {
            //arrange


            //act
            var result = NumberHelper.IsNumeric(check);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }
    
    
    }
}
