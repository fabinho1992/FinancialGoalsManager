using AutoMapper;
using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse;
using FinancialGoalsManager.Domain.Errors;
using FinancialGoalsManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.UserQueries.UserEmail
{
    public class UserEmailQueryHandler : IRequestHandler<UserEmailQuery, ResultViewModel<UserDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<UserDetailsResponse>> Handle(UserEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(request.Email);
            if(user is null)
            {
                return ResultViewModel<UserDetailsResponse>.Error(UsersErrors.NotFound.ToString());
            }

            var userResponse = _mapper.Map<UserDetailsResponse>(user);

            return ResultViewModel<UserDetailsResponse>.Success(userResponse);
        }
    }
}
