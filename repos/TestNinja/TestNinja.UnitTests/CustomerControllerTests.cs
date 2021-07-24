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
    public class CustomerControllerTests
    {

        private CustomerController controller;


        [SetUp]
        public void SetUp()
        {
            controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            //arrange]
            //var controller = new CustomerController();

            //act
            var result = controller.GetCustomer(0);

            //assert
            Assert.That(result, Is.TypeOf<NotFound>());
            //Assert.That(result, Is.InstanceOf<NotFound>()); //could also be a derivate of NotFound
            ;        }

        public void GetCustomer_IdIsNotZero_ReturnOk()
        {

            //arrange]
            //var controller = new CustomerController();

            //act
            var result = controller.GetCustomer(1);

            //assert
            Assert.That(result, Is.TypeOf<Ok>());

        }
    }
}
