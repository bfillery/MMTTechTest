using HelloWorld.Fundamentals;
using NUnit.Framework;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class ValidityTests
    {
        [Test]
        [TestCase(1,true)]
        [TestCase(5, true)]
        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(100, false)]
        public void IsValid_WhenCalled_ReturnsValidity(int NumberToTest,bool ExpectedResult)
        {
            //arrange

            //act
            var result = Validity.IsValid(NumberToTest);

            //assert
            Assert.That(result, Is.EqualTo(ExpectedResult));
        }
    }
}
