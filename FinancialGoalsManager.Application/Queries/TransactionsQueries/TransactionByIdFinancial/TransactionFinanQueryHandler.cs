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

namespace FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionByIdFinancial
{
    public class TransactionFinanQueryHandler : IRequestHandler<TransactionFinanQuery, ResultViewModel<List<TransactionByIdResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionFinanQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<TransactionByIdResponse>>> Handle(TransactionFinanQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.FinancialGoalTransactionRepository
                .GetByIdFinancialGoalAsync(request.Id);

            if (transactions is null)
            {
                return ResultViewModel<List<TransactionByIdResponse>>
                    .Error(FinancialTransactionsErrors.NotFound.ToString());
            }

            var transactionResponse = transactions.Select(t => new TransactionByIdResponse(
                id: t.Id,
                nameBox: t.FinancialGoal!.Name,
                boxId: t.FinancialGoal.Id,
                amount: t.Amount,
                transactionDate: t.TransactionDate.ToString("d"),
                transactionType: t.TransactionType
                )).ToList();

            return ResultViewModel<List<TransactionByIdResponse>>.Success(transactionResponse);


        }
    }
}
