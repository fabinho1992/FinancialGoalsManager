using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses;
using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses
{
    public class FinancialGoalByIdResponse
    {
        public FinancialGoalByIdResponse()
        {
            
        }

        public FinancialGoalByIdResponse(Guid id, string name, double goalAmount,
            DateTime deadline, double idealMonthlySaving, FinancialGoalsStatusEnum status, DateTime createdAt,
            bool isDeleted, double salvedValue, List<FinancialTransactionsResponse> financialGoalTransactions)
        {
            Id = id;
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthlySaving = idealMonthlySaving;
            Status = status;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
            SalvedValue = salvedValue;
            FinancialGoalTransactions = financialGoalTransactions;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double GoalAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
        public FinancialGoalsStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public double SalvedValue { get; set; }
        public List<FinancialTransactionsResponse> FinancialGoalTransactions { get; set; } = new List<FinancialTransactionsResponse>();
    }
}
