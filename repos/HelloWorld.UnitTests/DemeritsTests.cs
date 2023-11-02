
using HelloWorld.Fundamentals;
using NUnit.Framework;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class DemeritsTests
    {

        [Test]
        [TestCase(10,20,0)]
        [TestCase(20, 10, 2)]
        [TestCase(20, 20, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(10, 0, 2)]
        [TestCase(1000, 0, 200)]
        public void CalculateDemerits_WhenCalled_ShouldReturnDemeritPoints(int speed, int limit, int returnValue)
        {
            //arrange


            //act
            var result = Demerits.CalculateDemerits(speed, limit);

            //assert
            Assert.That(result, Is.EqualTo(returnValue));
        }
    }
}
