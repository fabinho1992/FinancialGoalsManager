using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services.Bus;
using MassTransit;
using MediatR;
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

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IBusService bus)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Cpf, request.Email);

            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.Commit();

            await _bus.PublishTransaction(user);

            return ResultViewModel<Guid>.Success(user.Id);
        }
    }
}
