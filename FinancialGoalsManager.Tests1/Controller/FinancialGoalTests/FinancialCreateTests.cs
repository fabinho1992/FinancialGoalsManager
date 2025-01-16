using FinancialGoalsManager.Api.Controllers;
using FinancialGoalsManager.Domain.Models;
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
        private readonly FinancialGoalsController _controller;
        private readonly IMediator _mediator;

        public FinancialCreateTests(ServiceTestsController factory)
        {
            _controller = new FinancialGoalsController(factory._mediator);
            _mediator = factory._mediator;
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var financialId = Guid.Parse("123e4567-e89b-12d3-a456-426655440000");
            var financial = new FinancialGoal("Teste", 100, new DateTime(2026, 01, 10), 1000);
            financial.InsertIdTest(financialId);
            // Aqui você deve configurar o mock para retornar um resultado esperado
            _mediator.Setu(m => m.Send(It.IsAny<FinancialGoalRepository>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new FinancialGoal("Teste", 100, new DateTime(2026, 01, 10), 1000)); // Retorne um objeto que você espera

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
