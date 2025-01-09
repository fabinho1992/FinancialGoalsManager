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
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double GoalAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
        public FinancialGoalsStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<FinancialTransactionsResponse> FinancialGoalTransactions { get; set; } = new List<FinancialTransactionsResponse>();
    }
}
