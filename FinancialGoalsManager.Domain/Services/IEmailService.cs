using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Services
{
    public interface IEmailService
    {
        Task SendEmailService(string subject, string message, string userEmail, string userName);
    }
}
