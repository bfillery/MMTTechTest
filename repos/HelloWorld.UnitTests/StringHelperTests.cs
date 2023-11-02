using NUnit.Framework;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class StringHelperTests
    {
        [Test]
        [TestCase("1234567", "7654321")]
        [TestCase("Bruce","ecurB")]
        [TestCase("", "")]
        public void ReverseString_WhenCalled_ReversesText(string text, string expectedResult)
        {
            //arrange


            //act
            var result = StringHelper.ReverseString(text);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("1-2-3-4-5",'-',true)]
        [TestCase("5-4-3-2-1", '-', true)]
        [TestCase("5-4-4-2-1", '-', false)]
        [TestCase("1-2_3-4-5", '-', false)]
        [TestCase("1_2_3_4_5", '_', true)]
        public void IsConsecutive_WhenCalled_ReturnsAssessment(string entries, char separator, bool expectedResult)
        {
            //arrange


            //act
            var result = StringHelper.IsConsecutive(entries, separator);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("1-2-3-4-5",'-',false)]
        [TestCase("1,2,3,4,5", ',', false)]
        [TestCase("", ',', false)]
        [TestCase("1,2,3,4,5", '-', false)]
        [TestCase("1,1,3,4,5", ',', true)]
        public void CheckForDuplicates_WhenCalled_ReturnsIfDuplicates(string entries, char separator, bool expectedResult)
        {
            //arrange


            //act
            var result = StringHelper.CheckForDuplicates(entries, separator);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("hello", "Hello")]
        [TestCase("hELLo", "Hello")]
        [TestCase("hELLo EVERYBODY out There", "Hello Everybody Out There")]
        [TestCase("", "")]
        public void ToTitleCase_WhenCalled_ReturnsProperCase(string entry, string expectedResult)
        {

            //arrange


            //act
            var result = StringHelper.ToTitleCase(entry);


            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("hello world",'o',2)]
        [TestCase("hello world", ' ', 1)]
        [TestCase("hello world", 'z', 0)]
        [TestCase("", 'z', 0)]
        public void CountChars_WhenCalled_ReturnsCharactercount(string text, char ch, int expectedResult)
        {
            //arrange

            //act
            var result = StringHelper.CountChars(text, ch);

            //asert
            Assert.That(result, Is.EqualTo(expectedResult));

        }


        [Test]
        [TestCase("hello world", 3)]
        [TestCase("hello", 2)]
        [TestCase("zzzzzzzzzzz", 0)]
        [TestCase("", 0)]
        public void CountVowels_WhenCalled_ReturnsVowelcount(string text, int expectedResult)
        {
            //arrange

            //act
            var result = StringHelper.CountVowels(text);

            //asert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCase("The rain in Spain",4)]
        [TestCase("TheraininSpain", 1)]
        [TestCase("", 0)]
        public void CountWords_WhenCalled_ReturnsWordCount(string text, int expectedResult)
        {
            //arrange

            //act
            var result = StringHelper.CountWords(text);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase("The rain in Spain", "Spain")]
        [TestCase("TheraininSpain", "TheraininSpain")]
        [TestCase("", "")]
        public void GetLongestWord_WhenCalled_ReturnsWordCount(string text, string expectedResult)
        {
            //arrange

            //act
            var result = StringHelper.GetLongestWord(text);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }


}
