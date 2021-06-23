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
    public class RegistrationControllerTests
    {
        private RegistrationController controller;
        private Mock<IRegistrationOrchestrator> mockRegistrationOrchestrator;


        [SetUp]
        public void SetUp()
        {
            mockRegistrationOrchestrator = new Mock<IRegistrationOrchestrator>();
            controller = new RegistrationController(mockRegistrationOrchestrator.Object);
        }

        [Test]
        public void Test_Index_ReturnsRegistrationView()
        {
            // Arrange
            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewName, "Registration");
        }

        [Test]
        public void Test_Register_ReturnsConfirmationView()
        {
            // Arrange
            CustomerModel customerModel = new CustomerModel();
            mockRegistrationOrchestrator.Setup(x => x.AddCustomer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Act
            ViewResult result = controller.Register(customerModel);

            // Assert
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(result.ViewName, "Confirmation");
        }

        [Test]
        public void Test_Register_ReturnsRegistrationFailedView()
        {
            // Arrange
            CustomerModel customerModel = new CustomerModel();
            mockRegistrationOrchestrator.Setup(x => x.AddCustomer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            // Act
            ViewResult result = controller.Register(customerModel);

            // Assert
            Assert.IsNull(result.Model);
            Assert.AreEqual(result.ViewName, "RegistrationFailed");
        }
    }
}
