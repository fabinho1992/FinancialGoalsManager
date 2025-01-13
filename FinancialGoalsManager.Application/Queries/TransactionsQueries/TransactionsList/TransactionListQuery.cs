using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionsList
{
    public class TransactionListQuery : PaginationParameters, IRequest<ResultViewModel<List<FinancialTransactionsResponse>>>
    {
        public TransactionListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
