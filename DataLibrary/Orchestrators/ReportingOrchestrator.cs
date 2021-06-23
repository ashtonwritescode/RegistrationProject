using DataLibrary.DTO;
using DataLibrary.Repositories;
using System.Collections.Generic;

namespace DataLibrary.Orchestrators
{
    public class ReportingOrchestrator : IReportingOrchestrator
    {
        private readonly IReportingRepository repository;

        public ReportingOrchestrator(IReportingRepository repository)
        {
            this.repository = repository;
        }
        public List<Customer> GetCustomers()
        {
            return repository.GetCustomers<Customer>();
        }
    }
}
