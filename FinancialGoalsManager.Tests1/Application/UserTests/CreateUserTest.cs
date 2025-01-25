
using FinancialGoalsManager.Application.Commands.UserCommands.CreateUser;
using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services.Bus;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Tests1.Application.UserTests
{
    public class CreateUserTest
    {
        [Fact]
        public async Task Create_User_Sucess()
        {
            //Arrange
            var mockRepository = new Mock<IUnitOfWork>();

            var mockBus = new Mock<IBusService>();

            var mockLogger = new Mock<ILogger<CreateUserCommand>>();

            var userId = Guid.Parse("123e4567-e89b-12d3-a456-426655440000");
            var user = new CreateUserCommand("Teste", "99999999999", "Teste@gmail.com");

            mockRepository.Setup(x => x
                    .UserRepository.CreateAsync(It.IsAny<User>()));
            var createUserHandler = new CreateUserCommandHandler(mockRepository.Object, mockBus.Object, mockLogger.Object);

            //Act
            var result = await createUserHandler.Handle(user, CancellationToken.None);

            //Assert
            mockRepository.Verify(x => x.UserRepository
            .CreateAsync(It.IsAny<User>()), Times.Once);

            Assert.NotNull(result); // Verifica se o resultado não é nulo

            Assert.IsType<ResultViewModel<Guid>>(result); // Verifica se o resultado é do tipo esperado
        }
    }
}
