using DataLibrary.DTO;
using DataLibrary.Orchestrators;
using DataLibrary.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataLibrary.UnitTests.Orchestrators
{
    [TestFixture]
    public class RegistrationOrchestratorTests
    {
        private RegistrationOrchestrator registrationOrchestrator;
        private Mock<IRegistrationRepository> mockRegistrationRepository;

        [SetUp]
        public void SetUp()
        {
            mockRegistrationRepository = new Mock<IRegistrationRepository>();
            registrationOrchestrator = new RegistrationOrchestrator(mockRegistrationRepository.Object);
        }

        [Test]
        public void Test_AddCustomer_Success()
        {
            // Arrange
            mockRegistrationRepository.Setup(x => x.InsertCustomer<Customer>(It.IsAny<Customer>())).Returns(1);

            // Act
            bool result = registrationOrchestrator.AddCustomer("firstname", "lastname", "addressline1", "addressline2", "city", "state", "zipcode", "country");

            // Assert
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Test_AddCustomer_Failure()
        {
            // Arrange
            mockRegistrationRepository.Setup(x => x.InsertCustomer<Customer>(It.IsAny<Customer>())).Returns(0);

            // Act
            bool result = registrationOrchestrator.AddCustomer("firstname", "lastname", "addressline1", "addressline2", "city", "state", "zipcode", "country");

            // Assert
            Assert.AreEqual(result, false);
        }
    }
}
