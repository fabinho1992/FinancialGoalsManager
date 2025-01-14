using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.ReportsQueries.TransactionsReports
{
    public class TransactionsReportQueryHandler : IRequestHandler<TransactionsReportQuery, IEnumerable<FinancialGoalTransactions>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FinancialGoalTransactions>> Handle(TransactionsReportQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.FinancialGoalTransactionRepository.GetByIdFinancialGoalAsync(request.Id);

            return transactions;
        }
    }
}
