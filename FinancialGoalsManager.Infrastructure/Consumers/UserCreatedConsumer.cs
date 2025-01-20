using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.Consumers
{
    public class UserCreatedConsumer : IConsumer<User>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserCreatedConsumer> _logger;
        private readonly ISendEmail _sendEmail;

        public UserCreatedConsumer(IUnitOfWork unitOfWork, ILogger<UserCreatedConsumer> logger, ISendEmail sendEmail)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _sendEmail = sendEmail;
        }

        public async Task Consume(ConsumeContext<User> context)
        {
            var @evento = context.Message;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(@evento.Id);
            if (user is not null)
            {
                try
                {
                    await _sendEmail.SendEmailUserCreated(user.Id);
                    _logger.LogInformation($"E-mail enviado para {@evento.Email}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Erro ao enviar e-mail para {@evento.Email}: {ex.Message}");
                }
            }
            else
            {
                _logger.LogWarning($"Usuário com ID {@evento.Id} não encontrado.");
            }
        }
    }
}
