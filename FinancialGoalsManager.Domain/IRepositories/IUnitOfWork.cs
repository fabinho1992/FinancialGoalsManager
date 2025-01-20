using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IFinancialGoalRepository FinancialGoalRepository { get; }
        IFinancialGoalTransactionRepository FinancialGoalTransactionRepository { get; }
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}
