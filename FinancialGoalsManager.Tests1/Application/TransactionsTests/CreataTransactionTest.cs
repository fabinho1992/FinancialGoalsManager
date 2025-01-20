using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal;
using FinancialGoalsManager.Application.Commands.FinancialGoalsTransactionsCommands.CreateFinancialGoalsTransactions;
using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services.Bus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Tests1.Application.TransactionsTests
{
    public class CreataTransactionTest
    {
        [Fact]
        public async Task Create_Transaction_Sucess()
        {
            //Arrange
            var mockRepository = new Mock<IUnitOfWork>();

            var mockBus = new Mock<IBusService>();

            var financialId = Guid.Parse("123e4567-e89b-12d3-a456-426655440000");
            var financial = new FinancialGoal(financialId, "Teste", 100, new DateTime(2026,01,10), 1000);
            financial.InsertIdTest(financialId);
            var createCommand = new CreateTransactionsCommand(100,
                TransactionTypeEnum.Deposit, financialId);


            mockRepository.Setup(x => x
            .FinancialGoalTransactionRepository.CreateAsync(It.IsAny<FinancialGoalTransactions>()));

            var createFinancialCommandHandle =
                new CreateTransactionsCommandHandler(mockRepository.Object, mockBus.Object);

            //Act
            var result = await createFinancialCommandHandle.Handle(createCommand, CancellationToken.None);

            //Assert

            Assert.NotNull(result);
            Assert.IsType<ResultViewModel<Guid>>(result);

        }
    }
}
