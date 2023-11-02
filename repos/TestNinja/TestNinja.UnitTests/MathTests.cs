using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //this isn't NUnit, but will be 
        //reinitialised before each test by NUnit using the [SetUp] attribute method
        //Note: [TearDown] is fo rintegration tests
        private Math _math;

        [SetUp]//NUnit attribute
        public void SetUp()
        {
            _math = new Math();
        }


        [Test]
        //[Ignore("Because testing is gay")] //[Ignore(because) better than commenting out
        public void Add_WhenCalled_ReturnsTheSumOfArguments()
        {
            //Arrange
            //var math = new Math(); --handled by [SetUp]

            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLImit()
        {
            //Arrange
            //var math = new Math(); --handled by [SetUp]

            //Act
            var result = _math.GetOddNumbers(5);

            Assert.Multiple(() =>
            {
                //Assert
                //super-general
                Assert.That(result, Is.Not.Empty);

                Assert.That(Enumerable.Count(result), Is.EqualTo(3));  //IEnumerable doesn't have a Count() method

                //Assert.That(result, Does.Contain(1));
                //Assert.That(result, Does.Contain(3));
                //Assert.That(result, Does.Contain(5));
                Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 })); //equivalent to preceding three

                //Assert.That(result, Is.Ordered); //useful if the results should be sorted
                //Assert.That(result, Is.Unique); //check for dupes in your array
            
            
            });
        }


        [Test]
        //parameterised testing
        [TestCase(2,1,2)] //first arg is greater
        [TestCase(1, 2, 2)] //second arg is greater
        [TestCase(2, 2, 2)] //args are equal
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedresult)
        {
            //Arrange
            //var math = new Math(); --handled by [SetUp]

            //Act
            var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedresult));
        }






        //********************************************
        //replaced by parametrised test [TestCase], above


        //[Test]
        //public void Max_SecondArgumentIsGreater_ReturnsTheSecondArgument()
        //{
        //    //Arrange
        //    //var math = new Math(); --handled by [SetUp]

        //    //Act
        //    var result = _math.Max(1,2);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_ArgumentsAreEqual_ReturnsTheSameArgument()
        //{
        //    //Arrange
        //    //var math = new Math(); --handled by [SetUp]

        //    //Act
        //    var result = _math.Max(2, 2);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(2));
        //}
        //********************************************
    }
}
