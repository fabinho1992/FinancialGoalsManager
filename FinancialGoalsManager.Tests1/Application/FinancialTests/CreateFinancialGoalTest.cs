using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal;
using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using Microsoft.CodeAnalysis;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Tests1.Application.FinancialTests
{
    public class CreateFinancialGoalTest
    {
        [Fact]
        public async Task Create_FinancialGoal_Ok()
        {

            //Arrange
            var mockRepository = new Mock<IUnitOfWork>();

            var userId = Guid.NewGuid();

            var createCommand = new CreateFinancialGoalCommand(userId, "Teste", 100, 
                new DateTime(2026, 01, 18), 1000);

            mockRepository.Setup(x => x
            .FinancialGoalRepository.CreateAsync(It.IsAny<FinancialGoal>()));

            var createFinancialCommandHandle =
                new CreateFinancialGoalCommandHandler(mockRepository.Object);

            //Act
            var result = await createFinancialCommandHandle.Handle(createCommand, CancellationToken.None);

            //Assert
            mockRepository.Verify(x => x.FinancialGoalRepository
            .CreateAsync(It.IsAny<FinancialGoal>()), Times.Once);

            Assert.NotNull(result); // Verifica se o resultado não é nulo

            Assert.IsType<ResultViewModel<Guid>>(result); // Verifica se o resultado é do tipo esperado

        }


        [Fact]
        public async Task Create_FinancialGoal_Error()
        {

            //Arrange
            var mockRepository = new Mock<IUnitOfWork>();
            var userId = Guid.NewGuid();
            var createCommand = new CreateFinancialGoalCommand(userId, "Teste", 100, new DateTime(2022, 01, 18), 1000 );

            mockRepository.Setup(x => x
            .FinancialGoalRepository.CreateAsync(It.IsAny<FinancialGoal>()));

            var createFinancialCommandHandle =
                new CreateFinancialGoalCommandHandler(mockRepository.Object);

            //Act
            var result = await createFinancialCommandHandle.Handle(createCommand, CancellationToken.None);

            //Assert
            Assert.IsType<ResultViewModel<Guid>>(result);
        }
    }
}
