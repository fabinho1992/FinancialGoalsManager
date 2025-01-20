using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.UserQueries.UsersList
{
    public class UsersListQuery : PaginationParameters, IRequest<ResultViewModel<List<UserListResponse>>>
    {
        public UsersListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
