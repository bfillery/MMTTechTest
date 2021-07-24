using NUnit.Framework;

namespace HelloWorld.UnitTests
{
    public class DateTimeHelperTests
    {
        [Test]
        [TestCase("19:00",true)]
        [TestCase("1st January 2020 19:00", false)]
        [TestCase("29:00", false)]
        [TestCase("hello", false)]
        [TestCase("", false)]
        public void IsValidTime_WhenCalled_Validates(string entry, bool expectedResult)
        {
            //arrange

            //act
            var result = DateTimeHelper.IsValidTime(entry);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
