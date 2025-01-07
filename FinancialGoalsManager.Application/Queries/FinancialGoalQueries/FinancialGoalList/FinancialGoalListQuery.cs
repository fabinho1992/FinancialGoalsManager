using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalList
{
    public class FinancialGoalListQuery : PaginationParameters, IRequest<ResultViewModel<List<FinancialGoalResponse>>>
    {
        public FinancialGoalListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
