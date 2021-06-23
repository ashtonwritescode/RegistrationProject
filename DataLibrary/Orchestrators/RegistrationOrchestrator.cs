using DataLibrary.DTO;
using DataLibrary.Repositories;
using System;

namespace DataLibrary.Orchestrators
{
    public class RegistrationOrchestrator : IRegistrationOrchestrator
    {
        private readonly IRegistrationRepository repository;

        public RegistrationOrchestrator(IRegistrationRepository repository)
        {
            this.repository = repository;
        }

        public bool AddCustomer(string firstName, string lastName, string addressLine1, string addressLine2, string city, string state, string zipcode, string country)
        {
            bool success = false;
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                City = city,
                State = state,
                Zipcode = zipcode,
                Country = country,
                RegistrationDate = DateTime.Now
            };

            if (repository.InsertCustomer(customer).Equals(1))
            {
                success = true;
            }

            return success;
        }
    }
}
