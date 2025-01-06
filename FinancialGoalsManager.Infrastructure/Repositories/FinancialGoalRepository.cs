using FinancialGoalsManager.Domain.Enuns;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.Repositories
{
    public class FinancialGoalRepository : IFinancialGoalRepository
    {
        private readonly DbFinancialGoalsContext _context;

        public FinancialGoalRepository(DbFinancialGoalsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FinancialGoal financialGoal)
        {
            await _context.AddAsync(financialGoal);
        }

        public async void Delete(FinancialGoal financialGoal)
        {
            var financialDelete = await GetByIdAsync(financialGoal.Id);
            _context.Remove(financialDelete);
        }

        public async Task<List<FinancialGoal>> GetAllAsync(PaginationParameters paginationParameters)
        {
            return await _context.FinancialGoals.AsNoTracking().OrderBy(a => a.CreatedAt)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize).ToListAsync();
        }

        public async Task<FinancialGoal> GetByIdAsync(Guid id)
        {
            var financialGoal = await _context.FinancialGoals.Include(f => f.FinancialGoalTransactions)
                .SingleOrDefaultAsync(f => f.Id == id);

            return financialGoal;
        }

        public async Task<FinancialGoal> GetByStatusAsync(FinancialGoalsStatusEnum goalsStatus)
        {
            var financialGoal = await _context.FinancialGoals.Include(f => f.FinancialGoalTransactions)
                .SingleOrDefaultAsync(f => f.Status == goalsStatus);

            return financialGoal;
        }

        public async Task Update(FinancialGoal financialGoal)
        {
            _context.Update(financialGoal);
        }
    }
}
