using FastReport.Web;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.ServiceReport
{
    public class GenerateDataTableReport : IGenerateDataTableReport
    {
        public void DataTableReportTransactions(IEnumerable<FinancialGoalTransactions> financials, WebReport webReport)
        {
            var transactionsDataTable = new DataTable();

            transactionsDataTable.Columns.Add("Amount", typeof(double));
            transactionsDataTable.Columns.Add("Date Transaction", typeof(DateTime));


            foreach (var item in financials)
            {
                transactionsDataTable.Rows.Add(item.Amount, item.TransactionDate);
            }

            webReport.Report.RegisterData(transactionsDataTable, "Transactions history");
        }
    }
}
