using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.UserQueries.UserEmail
{
    public class UserEmailQuery : IRequest<ResultViewModel<UserDetailsResponse>>
    {
        public UserEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }
    }
}
