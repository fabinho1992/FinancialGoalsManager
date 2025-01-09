using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalsTransactionsCommands.CreateFinancialGoalsTransactions
{
    public class CreateTransactionsCommand : IRequest<ResultViewModel<Guid>>
    {
        public CreateTransactionsCommand(double amount, TransactionTypeEnum transactionType, Guid financialGoalId)
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
