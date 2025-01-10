using FinancialGoalsManager.Application.Commands.FinancialGoalsTransactionsCommands.CreateFinancialGoalsTransactions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.FluentValidation.TransactionsValidations
{
    public class CreateTransactionValidation : AbstractValidator<CreateTransactionsCommand>
    {
        public CreateTransactionValidation()
        {
            RuleFor(t => t.Amount).NotEmpty().NotNull()
                .WithMessage("Amount cannot be null ")
                .GreaterThan(0)
                .WithMessage("The target value must be greater than zero.");

            RuleFor(t => t.FinancialGoalId).NotEmpty().NotNull()
                .WithMessage("FinancialGoalId connot be null");

            RuleFor(t => t.TransactionType).NotEmpty().NotNull()
                .WithMessage("TransactionType cannot be null");
        }
    }
}
