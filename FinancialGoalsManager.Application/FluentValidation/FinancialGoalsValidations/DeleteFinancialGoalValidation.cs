using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.DeleteFinancialGoal;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.FluentValidation.FinancialGoalsValidations
{
    public class DeleteFinancialGoalValidation : AbstractValidator<DeleteFinancialCommand>
    {
        public DeleteFinancialGoalValidation()
        {
            RuleFor(f => f.Id).NotEmpty().NotNull()
                .WithMessage("Id cannot be null");
        }
    }
}
