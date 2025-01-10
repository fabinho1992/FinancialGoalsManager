using AutoMapper;
using FinancialGoalsManager.Application.Dtos;
using FinancialGoalsManager.Domain.Errors;
using FinancialGoalsManager.Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalCommands.UpdateFinancialGoal
{
    public class UpdateFinancialGoalCommandHandler : IRequestHandler<UpdateFinancialGoalCommand, ResultViewModel<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFinancialGoalCommandHandler> _logger;

        public UpdateFinancialGoalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateFinancialGoalCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultViewModel<Guid>> Handle(UpdateFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var financial = await _unitOfWork.FinancialGoalRepository.GetByIdAsync(request.Id);
            if (financial is null)
            {
                return ResultViewModel<Guid>.Error(FinancialGoalErrors.NotFound.ToString());
            }

            _mapper.Map(request, financial);
            await _unitOfWork.FinancialGoalRepository.Update(financial);
            await _unitOfWork.Commit();

            _logger.LogInformation($"Financial goal de id {financial.Id}, alterado");

            return ResultViewModel<Guid>.Success(financial.Id);
        }
    }
}
