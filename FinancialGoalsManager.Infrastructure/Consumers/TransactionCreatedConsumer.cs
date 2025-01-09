using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Infrastructure.Repositories;
using MassTransit;
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

        public TransactionCreatedConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<FinancialGoalTransactions> context)
        {
            var evento = context.Message;
            var financialGoal = await _unitOfWork.FinancialGoalRepository.GetByIdAsync(evento.FinancialGoalId);
            if (financialGoal != null && evento.TransactionType == TransactionTypeEnum.Deposit)
            {
                financialGoal.DepositAmout(evento.Amount);
                await _financialGoalRepository.UpdateAsync(financialGoal);
            }
        }
    }
}
}
