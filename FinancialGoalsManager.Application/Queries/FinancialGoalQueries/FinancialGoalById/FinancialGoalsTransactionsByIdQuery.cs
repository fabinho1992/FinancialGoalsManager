using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses;
using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalById
{
    public class FinancialGoalsTransactionsByIdQuery : IRequest<ResultViewModel<FinancialGoalsTransactionsResponse>>
    {
        public Guid Id { get; }
    }
}
