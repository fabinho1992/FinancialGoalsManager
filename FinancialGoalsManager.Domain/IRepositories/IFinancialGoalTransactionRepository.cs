using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.IRepositories
{
    public interface IFinancialGoalTransactionRepository
    {
        Task CreateAsync(FinancialGoalTransactions financialGoalTransactions);
        Task<List<FinancialGoalTransactions>> GetAllAsync(PaginationParameters paginationParameters);
        Task<FinancialGoalTransactions> GetByIdAsync(Guid id);
        Task<FinancialGoalTransactions> GetByIdFinancialGoalAsync(Guid id);
    }
}
