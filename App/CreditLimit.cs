using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CreditLimitValidator : IValidator
    {
        private readonly ICustomer _customer;
        private readonly ICompany _company;
        public CreditLimitValidator(ICustomer customer, ICompany company)
        {
            _customer = customer;
            _company = company;
        }

        public bool Validate()
        {
            switch (_company.Name)
            {
                case "VeryImportantClient":
                    VeryImportantClient(_customer);
                    break;
                case "ImportantClient":
                    ImportantClient(_customer);
                    break;
                default:
                    DefaultClient(_customer);
                    break;
            }

            if (_customer.HasCreditLimit && _customer.CreditLimit < 500)
            {
                return false;
            }

            return true;
        }

        private static void DefaultClient(ICustomer customer)
        {
            // Do credit check
            customer.HasCreditLimit = true;
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                var creditLimit =
                    customerCreditService.GetCreditLimit(
                        customer.Firstname,
                        customer.Surname,
                        customer.DateOfBirth);
                customer.CreditLimit = creditLimit;
            }
        }

        private static void ImportantClient(ICustomer customer)
        {
            // Do credit check and double credit limit
            customer.HasCreditLimit = true;
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                var creditLimit =
                    customerCreditService.GetCreditLimit(
                        customer.Firstname,
                        customer.Surname,
                        customer.DateOfBirth);
                creditLimit = creditLimit * 2;
                customer.CreditLimit = creditLimit;
            }
        }

        private static void VeryImportantClient(ICustomer customer)
        {
            // Skip credit check
            customer.HasCreditLimit = false;
        }
    }
}
