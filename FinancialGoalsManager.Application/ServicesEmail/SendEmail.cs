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
        public Task SendEmailTransaction(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
