//using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
//using FinancialGoalsManager.Application.Dtos;
//using Microsoft.AspNetCore.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Json;
//using System.Text;
//using System.Threading.Tasks;
//using FinancialGoalsManager.Tests1.Controller.Service;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using FinancialGoalsManager.Api.Controllers;
//using FinancialGoalsManager.Domain.IRepositories;
//using FinancialGoalsManager.Domain.Models;
//using Microsoft.AspNetCore.Mvc;
//using Moq;

//namespace FinancialGoalsManager.Tests1.Controller
//{
//    public class FinancialGoalControllerTests : IClassFixture<ServiceTestsController>
//    {
//        private readonly FinancialGoalsController _controller;

//        public FinancialGoalControllerTests(ServiceTestsController controller)
//        {
//            _controller = new FinancialGoalsController(controller._mediator);
//        }

//        [Fact]
//        public async Task GetById_ReturnsOk_WhenGoalExists()
//        {
//            // Arrange
//            var financialGoalId = "123e4567-e89b-12d3-a456-426655440000";
//            var resultId = Guid.Parse(financialGoalId);

//            var mockFinancialGoal = new FinancialGoal("teste", 100, new DateTime(2026, 01, 01), 1000);
//            mockFinancialGoal.InsertIdTest(resultId);

//            // Configurando o mock do IMediator para retornar a meta financeira
//            _controller.Setup(m => m.Send(It.IsAny<GetFinancialGoalByIdQuery>(), It.IsAny<CancellationToken>()))
//                          .ReturnsAsync(mockFinancialGoal);

//            // Act
//            var response = await _controller.GetById(resultId);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(response);
//            var returnValue = Assert.IsType<FinancialGoal>(okResult.Value);
//            Assert.Equal(resultId, returnValue.Id);

//        }

//        //[Fact]
//        //public async Task GetById_ReturnsNotFound_WhenGoalDoesNotExist()
//        //{
//        //    // Arrange
//        //    var financialId = Guid.NewGuid(); // Um ID que não existe

//        //    // Act
//        //    var response = await _client.GetAsync($"/api/financialgoals/{financialId}");

//        //    // Assert
//        //    Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
//        //    var result = await response.Content.ReadAsStringAsync();
//        //    Assert.Contains("NotFound", result); // Verifique se a mensagem de erro está correta
//        //}
//    }
//}
