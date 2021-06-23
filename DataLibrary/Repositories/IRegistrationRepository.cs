namespace DataLibrary.Repositories
{
    public interface IRegistrationRepository
    {
        int InsertCustomer<T>(T data);
    }
}
