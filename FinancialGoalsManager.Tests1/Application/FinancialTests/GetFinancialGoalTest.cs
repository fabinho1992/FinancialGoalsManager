using AutoMapper;
using FinancialGoalsManager.Application.Profiles;
using FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalById;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Tests1.Application.FinancialTests
{
    public class GetFinancialGoalTest
    {
        [Fact]
        public async Task Get_FinancialGoal_Ok()
        {
            //Arrange
            var mockRepository = new Mock<IUnitOfWork>();
            var finacialId = new Guid();
            var financial = new FinancialGoal(finacialId, "teste", 100,
                new DateTime(2026 , 01, 18), 1000);

            
            financial.InsertIdTest(finacialId);

            mockRepository.Setup(x => x.FinancialGoalRepository
            .GetByIdAsync(financial.Id)).ReturnsAsync(financial);

            // Configura o AutoMapper
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FinanciaGoalProfile>());
            var mapper = config.CreateMapper();

            var donorQuery = new FinancialGoalByIdQuery(financial.Id);
            var handler = new FinancialGoalByIdQueryHandler(mockRepository.Object, mapper );

            /// Act
            var result = await handler.Handle(donorQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(finacialId, result.Data.Id);
            Assert.Equal("teste", result.Data.Name);
            Assert.Equal(100, result.Data.GoalAmount);
            Assert.Equal(new DateTime(2026, 01, 18), result.Data.Deadline);
        }
    }
}
