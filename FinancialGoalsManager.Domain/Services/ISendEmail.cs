using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Services
{
    public interface ISendEmail
    {
        Task SendEmailUserCreated(Guid id);
        Task SendEmailTransaction(Guid id);
    }
}
