namespace DataLibrary.Orchestrators
{
    public interface IRegistrationOrchestrator
    {
        bool AddCustomer(string firstName, string lastName, string addressLine1, string addressLine2, string city, string state, string zipcode, string country);
    }
}
