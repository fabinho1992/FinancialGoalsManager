using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Errors;
using FinancialGoalsManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalCommands.DeleteFinancialGoal
{
    internal class DeleteFinancialCommandHandler : IRequestHandler<DeleteFinancialCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFinancialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeleteFinancialCommand request, CancellationToken cancellationToken)
        {
            var financial = await _unitOfWork.FinancialGoalRepository.GetByIdAsync(request.Id);
            if (financial is null)
            {
                return ResultViewModel.Error(FinancialGoalErrors.NotFound.ToString());
            }

            _unitOfWork.FinancialGoalRepository.Delete(financial);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
