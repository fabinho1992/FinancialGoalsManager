using FinancialGoalsManager.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Models
{
    public class FinancialGoal
    {
        public FinancialGoal(string name, double goalAmount, DateTime deadline, double idealMonthlySaving)
        {
            Id = Guid.NewGuid();
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthlySaving = idealMonthlySaving;
            Status = FinancialGoalsStatusEnum.InProgress;
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            SavedValue = 0;
            CalculateSelectedMonths();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double GoalAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public double IdealMonthlySaving { get; private set; }
        public FinancialGoalsStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int SelectedMonths { get; private set; }
        public double SavedValue { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<FinancialGoalTransactions> FinancialGoalTransactions { get; set; } = new List<FinancialGoalTransactions>();


        public void ItIsDeleted()
        {
            IsDeleted = true;
        }

        public void DepositAmout(double value)
        {
            SavedValue += value;
        }

        public void CalculateSelectedMonths()
        {
            // Obtém a data atual sem a hora
            DateTime currentDate = DateTime.Today;

            // Calcula a diferença entre a Deadline e a data atual
            int monthsDifference = ((Deadline.Year - currentDate.Year) * 12) + Deadline.Month - currentDate.Month;

            // Atribui o valor calculado à propriedade SelectedMonths
            SelectedMonths = monthsDifference;
        }

        public void InsertIdTest(Guid id)
        {
            Id = id;
        }
    }

}
