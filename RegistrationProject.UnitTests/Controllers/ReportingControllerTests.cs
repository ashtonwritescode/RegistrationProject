using DataLibrary.DTO;
using DataLibrary.Orchestrators;
using Moq;
using NUnit.Framework;
using RegistrationProject.Controllers;
using RegistrationProject.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RegistrationProject.UnitTests.Controllers
{
    [TestFixture]
    public class ReportingControllerTests
    {
        private ReportingController controller;
        private Mock<IReportingOrchestrator> mockReportingOrchestrator;


        [SetUp]
        public void SetUp()
        {
            mockReportingOrchestrator = new Mock<IReportingOrchestrator>();
            controller = new ReportingController(mockReportingOrchestrator.Object);
        }

        [Test]
        public void Test_Index_ReturnsAdminReportView()
        {
            // Arrange
            List<Customer> customerList = new List<Customer>();
            Customer customer = new Customer();
            customerList.Add(customer);
            CustomerModel model = new CustomerModel();

            mockReportingOrchestrator.Setup(x => x.GetCustomers()).Returns(customerList);

            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(result.ViewName, "AdminReport");
;        }
    }
}
