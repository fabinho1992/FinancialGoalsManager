using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal
{
    public class CreateFinancialGoalCommandHandler : IRequestHandler<CreateFinancialGoalCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFinancialGoalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<Guid>> Handle(CreateFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var financialGoal = new FinancialGoal(request.UserId, request.Name, request.GoalAmount,
                request.Deadline, request.IdealMonthlySaving);

            await _unitOfWork.FinancialGoalRepository.CreateAsync(financialGoal);
            await _unitOfWork.Commit();

            return ResultViewModel<Guid>.Success(financialGoal.Id);

        }
    }
}
