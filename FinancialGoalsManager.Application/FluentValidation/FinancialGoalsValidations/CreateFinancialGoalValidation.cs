using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.FluentValidation.FinancialGoalsValidations
{
    public class CreateFinancialGoalValidation : AbstractValidator<CreateFinancialGoalCommand>
    {
        public CreateFinancialGoalValidation()
        {
            RuleFor(f => f.Name).NotEmpty().NotNull()
                .WithMessage("Name cannot be null")
                .MaximumLength(50).WithMessage("Must contain a maximum of 50 characters")
                .MinimumLength(3).WithMessage("Must contain a minimum of 3 characters");

            RuleFor(f => f.Deadline)
                .NotNull()
                .WithMessage("Deadline cannot be null")
                .GreaterThan(DateTime.Today)
                .WithMessage("Deadline must be greater than today.");

            RuleFor(f => f.GoalAmount).NotNull()
                .WithMessage("The target value cannot be null.")
                .GreaterThan(0)
                .WithMessage("The target value must be greater than zero.")
                .LessThanOrEqualTo(100000)
                .WithMessage("The target value cannot be greater than 10,000.");

            RuleFor(f => f.IdealMonthlySaving).NotNull()
                .WithMessage("The target value cannot be null.")
                .GreaterThan(0)
                .WithMessage("The target value must be greater than zero.")
                .LessThanOrEqualTo(1000)
                .WithMessage("The target value cannot be greater than 100.");
        }

    }

}

