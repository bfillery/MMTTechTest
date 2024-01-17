using Microsoft.Extensions.Configuration;
using MMT.Models;
using MMT.Models.DB;
using MMT.Repositories;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace MMT.UnitTests
{
    public class CustomerRepositoryTests
    {

        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetDeliveryAddress_FullyPopulatedCustDTO_ReturnsExpectedAddress()
        {

            //arrange
            CustomerDTO custDTO = new CustomerDTO()
            {
                HouseNumber = "221b",
                Street = "Baker Street",
                Town = "London",
                Postcode = "NW1 6XE"
            };

            string expected = @"221b Baker Street, London, NW1 6XE";

            CustomerRepository custRepo = new(_configuration);


            //act
            var result = custRepo.GetDeliveryAddress(custDTO);

            //assert
            ClassicAssert.AreEqual(result,expected);
        }

        [Test]
        public void GetDeliveryAddress_MissingPostcode_ReturnsExpectedAddress()
        {

            //arrange
            CustomerDTO custDTO = new CustomerDTO()
            {
                HouseNumber = "221b",
                Street = "Baker Street",
                Town = "London"
            };

            string expected = @"221b Baker Street, London";

            CustomerRepository custRepo = new(_configuration);


            //act
            var result = custRepo.GetDeliveryAddress(custDTO);

            //assert
            ClassicAssert.AreEqual(result, expected);
        }

        [Test]
        public void GetDeliveryAddress_MissingTown_ReturnsExpectedAddress()
        {

            //arrange
            CustomerDTO custDTO = new CustomerDTO()
            {
                HouseNumber = "221b",
                Street = "Baker Street",
                Postcode = "NW1 6XE"
            };

            string expected = @"221b Baker Street, NW1 6XE";

            CustomerRepository custRepo = new(_configuration);


            //act
            var result = custRepo.GetDeliveryAddress(custDTO);

            //assert
            ClassicAssert.AreEqual(result, expected);
        }

        //public Task<CustomerDTO> GetCustomer(string Email);


    }
}