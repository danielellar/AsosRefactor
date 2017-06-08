using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Test
{
    [TestClass]
    public class CreditLimit
    {
        /// <summary>
        /// Tests that VeryImportantClient works with the correct data
        /// </summary>
        [TestMethod]
        public void VeryImportantClientName()
        {
            var customerService = new CustomerService();
            ICustomer customer = new Customer
            {
                EmailAddress = "TestEmail",
                Surname = "Blogs",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                Firstname = "Joe",
                Company = new Company
                {
                    Id = 1,
                    Classification = Classification.Gold,
                    Name = "VeryImportantClient"
                }
            };

            var successful = customerService.AddCustomer(customer);
            Assert.IsTrue(successful);
        }

        /// <summary>
        /// Tests that VeryImportantClient fails with underage applicant
        /// </summary>
        [TestMethod]
        public void VeryImportantClientUnderAge()
        {
            var customerService = new CustomerService();
            ICustomer customer = new Customer
            {
                EmailAddress = "TestEmail",
                Surname = "Blogs",
                DateOfBirth = DateTime.UtcNow.AddYears(-12),
                Firstname = "Joe",
                Company = new Company
                {
                    Id = 1,
                    Classification = Classification.Gold,
                    Name = "VeryImportantClient"
                }
            };

            var successful = customerService.AddCustomer(customer);
            Assert.IsFalse(successful);
        }       
    }
}
