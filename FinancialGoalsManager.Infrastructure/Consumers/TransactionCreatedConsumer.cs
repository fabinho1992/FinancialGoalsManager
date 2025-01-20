using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Infrastructure.Repositories;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.Consumers
{
    public class TransactionCreatedConsumer : IConsumer<FinancialGoalTransactions>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TransactionCreatedConsumer> _logger;

        public TransactionCreatedConsumer(IUnitOfWork unitOfWork, ILogger<TransactionCreatedConsumer> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<FinancialGoalTransactions> context)
        {
            var @evento = context.Message;
            var financialGoal = await _unitOfWork.FinancialGoalRepository.GetByIdAsync(@evento.FinancialGoalId);
            if (financialGoal != null && evento.TransactionType == TransactionTypeEnum.Deposit)
            {
                financialGoal.DepositAmout(@evento.Amount);
                await _unitOfWork.FinancialGoalRepository.Update(financialGoal);
                await _unitOfWork.Commit();
            }

            _logger.LogInformation($"Depositado o valor R${@evento.Amount},00 / Id {evento.FinancialGoalId}");
        }
    }
}

