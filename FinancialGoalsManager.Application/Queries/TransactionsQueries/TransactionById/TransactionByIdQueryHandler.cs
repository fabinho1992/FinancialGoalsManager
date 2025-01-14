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

namespace FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionById
{
    public class TransactionByIdQueryHandler : IRequestHandler<TransactionByIdQuery, ResultViewModel<TransactionByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<TransactionByIdResponse>> Handle(TransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.FinancialGoalTransactionRepository.GetByIdAsync(request.Id);
            if (transaction is null)
            {
                return ResultViewModel<TransactionByIdResponse>.Error(FinancialTransactionsErrors.NotFound.ToString());
            }

            var transactionResponse = new TransactionByIdResponse(
                transaction.Id, transaction.FinancialGoal!.Name, transaction.FinancialGoal.Id,
                transaction.Amount, transaction.TransactionDate.ToString("d"), transaction.TransactionType);

            return ResultViewModel<TransactionByIdResponse>.Success(transactionResponse);
        }
    }
}
