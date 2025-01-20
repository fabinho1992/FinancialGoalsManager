using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services;
using FinancialGoalsManager.Domain.Services.Bus;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusService _bus;
        private readonly ILogger<CreateUserCommand> _logger;
        private readonly IEmailService _emailService;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IBusService bus, ILogger<CreateUserCommand> logger, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Cpf, request.Email);

            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.Commit();

            _logger.LogInformation($"{user.Id}");

            var message = $"Welcome Fabio, registration completed successfully," +
               $" now you can create a financial goal for your future.";
            _logger.LogInformation(message);
            await _emailService.SendEmailService("Registered user", message.ToString(), "f.santosdev1992@gmail.com", "Fabio");
            await _bus.PublishTransaction(user);
            

            return ResultViewModel<Guid>.Success(user.Id);
        }
    }
}
