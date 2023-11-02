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
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            //arrange
            var formatter = new HtmlFormatter();

            //act
            var result=formatter.FormatAsBold("abc");

            //specific assertion
            //NB assertions against strings are case sensitive by default
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //more general, and can combine            
            //https://docs.nunit.org/articles/nunit/writing-tests/assertions/multiple-asserts.html
            Assert.Multiple(() =>
            {
                Assert.That(result, Does.StartWith("<strong>"));
                Assert.That(result, Does.EndWith("</strong>"));
                Assert.That(result, Does.Contain("abc"));
            });

        }
    }
}
