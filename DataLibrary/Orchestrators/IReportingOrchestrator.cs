using DataLibrary.DTO;
using System.Collections.Generic;

namespace DataLibrary.Orchestrators
{
    public interface IReportingOrchestrator
    {
        List<Customer> GetCustomers();
    }
}
