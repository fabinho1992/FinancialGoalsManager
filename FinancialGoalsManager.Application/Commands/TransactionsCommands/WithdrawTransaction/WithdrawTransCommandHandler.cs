using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinancialGoalsManager.Application.Commands.TransactionsCommands.WithdrawTransaction
{
    public class WithdrawTransCommandHandler : IRequestHandler<WithdrawTransCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public WithdrawTransCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(WithdrawTransCommand request, CancellationToken cancellationToken)
        {
            if (request.TransactionType != TransactionTypeEnum.Withdraw)
            {
                return ResultViewModel<Guid>.Error("Wrong transaction selected, please choose withdrawal.");
            }

            if (request.Amount <= 0)
            {
                return ResultViewModel<Guid>.Error("The transaction value must be positive.");
            }

            if (Math.Round(request.Amount, 2) != request.Amount)
            {
                return ResultViewModel<Guid>.Error("The transaction amount must have a maximum of two decimal places.");
            }

            var transaction = new FinancialGoalTransactions(request.Amount,
                request.TransactionType, request.FinancialGoalId);

            await _unitOfWork.FinancialGoalTransactionRepository.CreateAsync(transaction);
            await _unitOfWork.Commit();

            var financialGoal = await _unitOfWork.FinancialGoalRepository.GetByIdAsync(request.FinancialGoalId);
            if (financialGoal is null)
            {
                return ResultViewModel<Guid>.Error("Financial goal not found");
            }

            financialGoal.Withdraw(transaction.Amount);
            await _unitOfWork.FinancialGoalRepository.Update(financialGoal);
            await _unitOfWork.Commit();



            return ResultViewModel<Guid>.Success(transaction.Id);


        }
    }
}
