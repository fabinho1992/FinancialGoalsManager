using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
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

        public CreateTransactionsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateTransactionsCommand request, CancellationToken cancellationToken)
        {
            var newTransaction = new FinancialGoalTransactions(request.Amount, request
                .TransactionType, request.FinancialGoalId);

            await _unitOfWork.FinancialGoalTransactionRepository.CreateAsync(newTransaction);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(newTransaction.Id);

        }
    }
}
