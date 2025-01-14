using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
using FinancialGoalsManager.Domain.Errors;
using FinancialGoalsManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalList
{
    public class FinancialGoalListQueryHandler : IRequestHandler<FinancialGoalListQuery, ResultViewModel<List<FinancialGoalResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinancialGoalListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<FinancialGoalResponse>>> Handle(FinancialGoalListQuery request, CancellationToken cancellationToken)
        {
            var financials = await _unitOfWork.FinancialGoalRepository.GetAllAsync(request);
            if (financials is null)
            {
                return ResultViewModel<List<FinancialGoalResponse>>
                    .Error(FinancialGoalErrors.NotFound.ToString());
            } 

            var financialResponses = financials.Select(f => new FinancialGoalResponse(
                id: f.Id,
                name: f.Name,
                goalAmount: f.GoalAmount,
                deadline: f.Deadline.ToString("d"),
                idealMonthlySaving: f.IdealMonthlySaving,
                status: f.Status,
                createdAt: f.CreatedAt.ToString("d"),
                salvedValue: f.SavedValue,
                selectedMonths:f.SelectedMonths
                
                )).ToList();

            return ResultViewModel<List<FinancialGoalResponse>>.Success(financialResponses);

            
        }
    }
}
