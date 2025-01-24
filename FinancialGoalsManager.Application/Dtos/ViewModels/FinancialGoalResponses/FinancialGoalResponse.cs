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
        public FinancialGoalResponse()
        {
            
        }

        public FinancialGoalResponse(Guid id, string name, double goalAmount, string deadline,
            double idealMonthlySaving, FinancialGoalsStatusEnum status, string createdAt, double salvedValue, int selectedMonths)
        {
            Id = id;
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthlySaving = idealMonthlySaving;
            Status = status;
            CreatedAt = createdAt;
            SalvedValue = salvedValue;
            SelectedMonths = selectedMonths;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double SalvedValue { get; private set; }
        public int SelectedMonths { get; private set; }
        public double GoalAmount { get; private set; }
        public string Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
        public FinancialGoalsStatusEnum Status { get; private set; }
        public string CreatedAt { get; private set; }
    }
}
