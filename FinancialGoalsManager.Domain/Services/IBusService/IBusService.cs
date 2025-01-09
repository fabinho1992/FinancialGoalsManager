using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Services.Bus
{
    public interface IBusService
    {
        Task Publish<T>(T message);
    }
}
