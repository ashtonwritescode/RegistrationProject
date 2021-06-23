using DataLibrary.Orchestrators;
using RegistrationProject.Models;
using System.Web.Mvc;

namespace RegistrationProject.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationOrchestrator registrationOrchestrator;

        public RegistrationController(IRegistrationOrchestrator registrationOrchestrator)
        {
            this.registrationOrchestrator = registrationOrchestrator;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View("Registration");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Register(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                bool customerAddedSuccessfully = registrationOrchestrator.AddCustomer(model.FirstName, 
                    model.LastName, 
                    model.AddressLine1, 
                    model.AddressLine2, 
                    model.City, 
                    model.State, 
                    model.Zipcode, 
                    model.Country);

                if (customerAddedSuccessfully)
                {
                    return View("Confirmation", model);
                }
                else
                {
                    return View("RegistrationFailed");
                }
            }

            return View();
        }
    }
}