using System;

namespace App
{
    public class CustomerService
    {
        public bool AddCustomer(ICustomer customer)
        {
            IValidator customerValidator = new CustomerValidator(customer);
            if (!customerValidator.Validate())
            {
                return false;
            }

            ICompanyRepository companyRepository = new CompanyRepository();
            ICompany company = companyRepository.GetById(customer.Company.Id);
            IValidator creditLimitValidator = new CreditLimitValidator(customer, company);
            if (!creditLimitValidator.Validate())
            {
                return false;
            }

            CustomerDataAccess.AddCustomer(customer);
            return true;
        }
    }
}