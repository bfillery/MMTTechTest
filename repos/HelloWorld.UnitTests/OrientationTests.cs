using HelloWorld.Fundamentals;
using NUnit.Framework;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class OrientationTests
    {

        [Test]
        [TestCase(0,0,true)]
        [TestCase(10, 1, true)]
        [TestCase(10, 10, true)]
        [TestCase(10, 15, false)]
        [TestCase(10, 5000, false)]
        public void IsPortrait_WhenCalled_ReturnsOrientation(int Height, int Width,bool ExpectedResult)
        {
            //arrange

            //act
            var result = Orientation.IsPortrait(Height, Width);

            //assert
            Assert.That(result, Is.EqualTo(ExpectedResult));
        }
    }
}
