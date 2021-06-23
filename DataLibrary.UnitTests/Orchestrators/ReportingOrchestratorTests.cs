using DataLibrary.DTO;
using DataLibrary.Orchestrators;
using DataLibrary.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataLibrary.UnitTests.Orchestrators
{
    [TestFixture]
    public class ReportingOrchestratorTests
    {
        private ReportingOrchestrator reportingOrchestrator;
        private Mock<IReportingRepository> mockReportingRepository;

        [SetUp]
        public void Setup()
        {
            mockReportingRepository = new Mock<IReportingRepository>();
            reportingOrchestrator = new ReportingOrchestrator(mockReportingRepository.Object);
        }

        [Test]
        public void Test_GetCustomers_ReturnsCustomerList()
        {
            // Arrange
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer()
            {
                FirstName = "Test"
            };

            customers.Add(customer);
            mockReportingRepository.Setup(x => x.GetCustomers<Customer>()).Returns(customers);

            // Act
            var result = reportingOrchestrator.GetCustomers();

            // Assert
            Assert.AreEqual(result, customers);
        }
    }
}
