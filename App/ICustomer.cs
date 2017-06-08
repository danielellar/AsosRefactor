using System;

namespace App
{
    public interface ICustomer
    {
        ICompany Company { get; set; }
        int CreditLimit { get; set; }
        DateTime DateOfBirth { get; set; }
        string EmailAddress { get; set; }
        string Firstname { get; set; }
        bool HasCreditLimit { get; set; }
        int Id { get; set; }
        string Surname { get; set; }
    }
}