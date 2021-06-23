using System.Collections.Generic;

namespace DataLibrary.Repositories
{
    public interface IReportingRepository
    {
        List<T> GetCustomers<T>();
    }
}
