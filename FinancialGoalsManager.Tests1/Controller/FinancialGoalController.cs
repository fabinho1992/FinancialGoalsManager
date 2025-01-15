using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
using FinancialGoalsManager.Application.Dtos;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FinancialGoalsManager.Tests1.Controller.Service;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FinancialGoalsManager.Tests1.Controller
{
    public class FinancialGoalControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public FinancialGoalControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenGoalExists()
        {
            // Arrange
            var financialGoalId = "123e4567-e89b-12d3-a456-426655440000"; // Use um ID que você sabe que existe no banco de dados ou mocke o repositório
            var resultId = Guid.Parse(financialGoalId);                                                              // Você pode precisar criar um objeto FinancialGoal no banco de dados antes de chamar o endpoint

            // Act
            var response = await _client.GetAsync($"/api/financialgoals/{resultId}");

            // Assert
            response.EnsureSuccessStatusCode(); // Verifica se o status é 200-299
            var result = await response.Content.ReadFromJsonAsync<ResultViewModel<FinancialGoalByIdResponse>>();
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(resultId, result.Data.Id);
        }

        //[Fact]
        //public async Task GetById_ReturnsNotFound_WhenGoalDoesNotExist()
        //{
        //    // Arrange
        //    var financialId = Guid.NewGuid(); // Um ID que não existe

        //    // Act
        //    var response = await _client.GetAsync($"/api/financialgoals/{financialId}");

        //    // Assert
        //    Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        //    var result = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("NotFound", result); // Verifique se a mensagem de erro está correta
        //}
    }
}
