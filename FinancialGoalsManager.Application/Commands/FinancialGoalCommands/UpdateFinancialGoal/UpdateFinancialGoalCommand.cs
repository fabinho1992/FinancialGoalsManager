using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalCommands.UpdateFinancialGoal
{
    public class UpdateFinancialGoalCommand : IRequest<ResultViewModel<Guid>>
    {
        public UpdateFinancialGoalCommand(string name, double goalAmount, DateTime deadline, double idealMonthlySaving, Guid id)
        {
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthlySaving = idealMonthlySaving;
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double GoalAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
        
    }
}
