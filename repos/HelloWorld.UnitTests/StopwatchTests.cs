using HelloWorld.Fundamentals;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace HelloWorld.UnitTests
{

    [TestFixture]
    public class StopwatchTests
    {
        private Stopwatch stopwatch;

        [SetUp]
        public void SetUp()
        {
            stopwatch  = new Stopwatch();
        }


        [Test]
        public void GetTimings_whenCalled_ReturnsDictionaryOfTimings()
        {
            //arrange

            //act
            var result = stopwatch.GetTimings();

            //assert
            Assert.That(result, Is.TypeOf<Dictionary<int, Stopwatch.timing>>());
        }

        [Test]
        public void Start_IfAlreadyStarted_ThrowsInvalidOperationException()
        {
            //arrange
            

            //act
            stopwatch.Start();
            //stopwatch.Start();
            //would throw exception

            //assert
            //use a delegate and combine act and assert steps

            Assert.That(() => stopwatch.Start(),
                Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Stop_IfCalled_AddsATiming()
        {
            //arrange


            //act
            stopwatch.Start();
            System.Threading.Thread.Sleep(2000);
            stopwatch.Stop();
            var result = stopwatch.GetTimings()[0];

            //assert
            Assert.That(result.duration, Is.EqualTo(TimeSpan.FromSeconds(2)));
        }
    }
}
