using FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse;
using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialGoalsManager.Domain.IRepositories;

namespace FinancialGoalsManager.Application.Queries.UserQueries.UsersList
{
    public class UserListQueryHandler : IRequestHandler<UsersListQuery, ResultViewModel<List<UserListResponse>>>
    {
        private IUnitOfWork _unitOfWork;

        public UserListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<UserListResponse>>> Handle(UsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync(request);
            if (users is null)
            {
                return ResultViewModel<List<UserListResponse>>.Error("User not found");
            }

            var usersResponse = new List<UserListResponse>();   
            foreach (var user in users)
            {
                var userResponse = new UserListResponse(user.Id, user.FullName, user.Cpf, user.Email);
                usersResponse.Add(userResponse);
            }

            return ResultViewModel<List<UserListResponse>>.Success(usersResponse);
        }
    }
}
