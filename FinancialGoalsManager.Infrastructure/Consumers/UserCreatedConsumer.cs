using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Domain.Services;
using FinancialGoalsManager.Infrastructure.Migrations;
using Hangfire;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = FinancialGoalsManager.Domain.Models.User;

namespace FinancialGoalsManager.Infrastructure.Consumers
{
    public class UserCreatedConsumer : IConsumer<User>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserCreatedConsumer> _logger;
        private readonly ISendEmail _sendEmail;
        private readonly IEmailService _emailService;

        public UserCreatedConsumer(IUnitOfWork unitOfWork, ILogger<UserCreatedConsumer> logger, ISendEmail sendEmail, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _sendEmail = sendEmail;
            _emailService = emailService;
        }

        public async Task Consume(ConsumeContext<User> context)
        {
            var @evento = context.Message;
            //var user = await _unitOfWork.UserRepository.GetByIdAsync(@evento.Id);
            if (@evento is not null)
            {
                try
                {
                    // Agendar o envio do e-mail para 1 minuto depois
                    BackgroundJob.Schedule(() => _sendEmail.SendEmailUserCreated(@evento.Email), TimeSpan.FromMinutes(1));
                    _logger.LogInformation($"E-mail agendado para ser enviado para {@evento.Email} em 1 minuto.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Erro ao enviar e-mail para {@evento.Email}: {ex.Message}");
                    _logger.LogError($"{@evento.Email} {@evento.FullName}{@evento.Cpf}");
                }
            }
            else
            {
                _logger.LogWarning($"Usuário com ID {@evento.Id} não encontrado.");
                _logger.LogWarning($"{evento.Email} {evento.FullName}");
            }
        }
    }
}
