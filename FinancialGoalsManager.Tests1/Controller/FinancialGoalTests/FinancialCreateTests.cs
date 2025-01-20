using FinancialGoalsManager.Api.Controllers;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Infrastructure.Repositories;
using FinancialGoalsManager.Tests1.Controller.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinancialGoalsManager.Tests1.Controller.FinancialGoalTests
{
    public class FinancialCreateTests : IClassFixture<ServiceTestsController>
    {
        private  FinancialGoalsController _controller;

        public FinancialCreateTests(ServiceTestsController factory)
        {
            _controller = new FinancialGoalsController(factory._mediator);
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var financialId = Guid.Parse("123e4567-e89b-12d3-a456-426655440000");
            var financial = new FinancialGoal(financialId, "Teste", 100, new DateTime(2026, 01, 10), 1000);
            financial.InsertIdTest(financialId);

            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<FinancialGoalRepository>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(financial); // Retorne um objeto que você espera

            _controller = new FinancialGoalsController(mockMediator.Object);


            // Act
            var result = await _controller.GetById(financialId);

            // Assert

            Assert.IsAssignableFrom<IActionResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Verifica se o status code é 200
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
