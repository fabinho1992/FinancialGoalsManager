using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.ServicesEmail
{
    public class SendEmail : ISendEmail
    {
        IEmailService _emailService;
        IUnitOfWork _unitOfWork;

        public SendEmail(IEmailService emailService, IUnitOfWork unitOfWork)
        {
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

        public Task SendEmailTransaction(Guid id)
        {
            var financial = _unitOfWork.FinancialGoalTransactionRepository.GetByIdFinancialGoalAsync(id);
            

            return Task.CompletedTask;
        }

        public async Task SendEmailUserCreated(string email)
        {
            var user = await _unitOfWork.UserRepository.GetByEmail(email);

            var message = $"Welcome {user.FullName}, registration completed successfully," +
                $" now you can create a financial goal for your future.";

            await _emailService.SendEmailService("Registered user", message, user.Email, user.FullName);
        }
    }
}
