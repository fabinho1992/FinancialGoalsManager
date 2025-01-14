using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.TransactionsQueries.TransactionByIdFinancial
{
    public class TransactionFinanQuery : IRequest<ResultViewModel<List<TransactionByIdResponse>>>
    {
        public TransactionFinanQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
