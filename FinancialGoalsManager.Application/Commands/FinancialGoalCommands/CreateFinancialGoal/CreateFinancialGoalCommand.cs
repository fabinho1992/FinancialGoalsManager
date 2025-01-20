using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal
{
    public class CreateFinancialGoalCommand : IRequest<ResultViewModel<Guid>> 
    {
        public CreateFinancialGoalCommand(Guid userId, string name, double goalAmount, DateTime deadline, double idealMonthlySaving)
        {
            UserId = userId;
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthlySaving = idealMonthlySaving;
        }

        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public double GoalAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
    }
}
