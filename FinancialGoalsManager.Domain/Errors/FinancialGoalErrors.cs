using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Errors
{
    public class FinancialGoalErrors
    {
        public static readonly Error NotFound = new(
            "FinancialGoal.NotFoud", "The Financial Goal could not be found");
    }
}
