using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CustomerValidator : IValidator
    {
        private readonly ICustomer _customer;
        public CustomerValidator(ICustomer customer)
        {
            _customer = customer;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(_customer.Firstname) || string.IsNullOrEmpty(_customer.Surname))
            {
                return false;
            }

            if (!_customer.EmailAddress.Contains("@") && !_customer.EmailAddress.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            var age = now.Year - _customer.DateOfBirth.Year;
            if (now.Month < _customer.DateOfBirth.Month ||
                now.Month == _customer.DateOfBirth.Month &&
                now.Day < _customer.DateOfBirth.Day)
            {
                age--;
            }

            if (age < 21)
            {
                return false;
            }
            return true;
        }
    }
}
