using FinancialGoalsManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses
{
    public class FinancialGoalResponse
    {
        public FinancialGoalResponse(Guid id, string name, double goalAmount, DateTime deadline,
            double idealMonthlySaving, FinancialGoalsStatusEnum status, DateTime createdAt)
        {
            Id = id;
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthlySaving = idealMonthlySaving;
            Status = status;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double GoalAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
        public FinancialGoalsStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
