using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.TransactionsCommands.WithdrawTransaction
{
    public class WithdrawTransCommand : IRequest<ResultViewModel<Guid>>
    {
        public WithdrawTransCommand(double amount, TransactionTypeEnum transactionType, Guid financialGoalId)
        {
            Amount = amount;
            TransactionType = transactionType;
            FinancialGoalId = financialGoalId;
        }

        public double Amount { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
        public Guid FinancialGoalId { get; private set; }
    }
}
