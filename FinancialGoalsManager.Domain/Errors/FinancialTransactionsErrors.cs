using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Errors
{
    public class FinancialTransactionsErrors
    {
        public static readonly Error NotFound = new(
            "Transaction.NotFound", "The Transaction could not be found");
    }
}
