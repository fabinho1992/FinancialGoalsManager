using AutoMapper;
using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
using FinancialGoalsManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalById
{
    public class FinancialGoalByIdQueryHandler : IRequestHandler<FinancialGoalByIdQuery, ResultViewModel<FinancialGoalByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FinancialGoalByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<FinancialGoalByIdResponse>> Handle(FinancialGoalByIdQuery request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.FinancialGoalRepository.GetByIdAsync(request.Id);
            if (goal is null)
            {
                return ResultViewModel<FinancialGoalByIdResponse>.Error("The financial goal could not be found");
            }

            var goalResponse = _mapper.Map<FinancialGoalByIdResponse>(goal);
            return ResultViewModel<FinancialGoalByIdResponse>.Success(goalResponse);
        }
    }
}
