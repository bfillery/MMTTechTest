using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Fundamentals;

namespace HelloWorld.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Fundamentals.Stack stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Fundamentals.Stack();
        }


        [Test]
        public void Push_WhenPassedNull_ThrowsInvalidOperationException()
        {
            //arrange


            //act
            //use a delegate and combine act and assert steps

            //assert
            Assert.That(() => stack.Push(null),
                Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase("a", "a")]
        public void Push_WhenCalledWithObject_AddsToStack(object obj, object expectedResult)
        {
            //arrange


            //act
            stack.Push(obj);

            ArrayList objects = stack.GetStack();
            var result = objects[objects.Count - 1].ToString();

            //assert
            Assert.That(result, Is.EqualTo(expectedResult.ToString()));
        }
    }
}
