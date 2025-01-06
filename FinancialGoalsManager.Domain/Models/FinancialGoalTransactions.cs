using FinancialGoalsManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Models
{
    public class FinancialGoalTransactions
    {
        public FinancialGoalTransactions(double amount, TransactionTypeEnum transactionType, Guid financialGoalId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            FinancialGoalId = financialGoalId;
            TransactionType = transactionType;
            TransactionDate = DateTime.Now;
            IsDeleted = false;
        }

        public Guid Id { get; private set; }
        public double Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionTypeEnum TransactionType { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid FinancialGoalId { get; private set; }
        public virtual FinancialGoal? FinancialGoal { get; set; }


        public void ItIsDeleted()
        {
            IsDeleted = true;
        }
    }
}
