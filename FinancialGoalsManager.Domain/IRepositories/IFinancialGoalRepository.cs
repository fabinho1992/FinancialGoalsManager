using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.IRepositories
{
    public interface IFinancialGoalRepository
    {
        Task CreateAsync(FinancialGoal financialGoal);
        Task<List<FinancialGoal>> GetAllAsync(PaginationParameters paginationParameters);
        Task<FinancialGoal> GetByIdAsync(Guid id);
        Task<FinancialGoal> GetByStatusAsync(FinancialGoalsStatusEnum goalsStatus);
        Task Update(FinancialGoal financialGoal);
        void Delete(FinancialGoal financialGoal);
    }
}
