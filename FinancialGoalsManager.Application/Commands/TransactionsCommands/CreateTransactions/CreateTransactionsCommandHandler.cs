using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalsTransactionsCommands.CreateFinancialGoalsTransactions
{
    public class CreateTransactionsCommandHandler : IRequestHandler<CreateTransactionsCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusService _busService;

        public CreateTransactionsCommandHandler(IUnitOfWork unitOfWork, IBusService busService)
        {
            _unitOfWork = unitOfWork;
            _busService = busService;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateTransactionsCommand request, CancellationToken cancellationToken)
        {
            if (request.Amount <= 0)
            {
                return ResultViewModel<Guid>.Error("The transaction value must be positive.");
            }

            if (Math.Round(request.Amount, 2) != request.Amount)
            {
                return ResultViewModel<Guid>.Error("The transaction amount must have a maximum of two decimal places.");
            }

            var newTransaction = new FinancialGoalTransactions(request.Amount, request
                .TransactionType, request.FinancialGoalId);

            await _unitOfWork.FinancialGoalTransactionRepository.CreateAsync(newTransaction);
            await _unitOfWork.Commit();

            await _busService.PublishTransaction(newTransaction);

            return ResultViewModel<Guid>.Success(newTransaction.Id);

        }
    }
}
