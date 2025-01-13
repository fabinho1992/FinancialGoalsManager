using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses;
using FinancialGoalsManager.Domain.Errors;
using FinancialGoalsManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionsList
{
    public class TransactionListQueryHandler : IRequestHandler<TransactionListQuery, ResultViewModel<List<FinancialTransactionsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<FinancialTransactionsResponse>>> Handle(TransactionListQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.FinancialGoalTransactionRepository
                .GetAllAsync(request);

            if (transactions is null)
            {
                return ResultViewModel<List<FinancialTransactionsResponse>>
                    .Error(FinancialTransactionsErrors.NotFound.ToString());
            }

            var transactionsResponse = transactions.Select(t => new FinancialTransactionsResponse(
                id: t.Id,
                amount: t.Amount,
                transactionDate: t.TransactionDate.ToString(),
                transactionType: t.TransactionType
                )).ToList();

            return ResultViewModel<List<FinancialTransactionsResponse>>
                .Success(transactionsResponse); 

        }
    }
}
