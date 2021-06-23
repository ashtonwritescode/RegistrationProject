using DataLibrary.Orchestrators;
using RegistrationProject.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RegistrationProject.Controllers
{
    public class ReportingController : Controller
    {
        private readonly IReportingOrchestrator reportingOrchestrator;

        public ReportingController(IReportingOrchestrator reportingOrchestrator)
        {
            this.reportingOrchestrator = reportingOrchestrator;
        }
        public ViewResult Index()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (var customer in reportingOrchestrator.GetCustomers())
            {
                customers.Add(new CustomerModel
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    AddressLine1 = customer.AddressLine1,
                    AddressLine2 = customer.AddressLine2,
                    City = customer.City,
                    State = customer.State,
                    Zipcode = customer.Zipcode,
                    Country = customer.Country,
                    RegistrationDate = customer.RegistrationDate
                });
            }

            return View("AdminReport", customers);
        }
    }
}