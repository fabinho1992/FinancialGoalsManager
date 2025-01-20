using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Services.Bus
{
    public interface IBusService
    {
        Task PublishTransaction<T>(T message);
        Task PublishTransactionCreated<T>(T message);
        Task PublishUserCreated<T>(T message);
    }
}
