using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.ReportsQueries.TransactionsReports
{
    public class TransactionsReportQuery : IRequest<IEnumerable<FinancialGoalTransactions>>
    {
        public TransactionsReportQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
