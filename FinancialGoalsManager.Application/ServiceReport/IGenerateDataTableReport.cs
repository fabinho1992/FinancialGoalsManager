using FastReport.Web;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.ServiceReport
{
    public interface IGenerateDataTableReport
    {
        void DataTableReportTransactions(IEnumerable<FinancialGoalTransactions> financials, WebReport webReport);
    }
}
