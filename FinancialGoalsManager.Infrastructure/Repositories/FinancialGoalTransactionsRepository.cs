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
    public class FinancialGoalTransactionsRepository : IFinancialGoalTransactionRepository
    {
        private readonly DbFinancialGoalsContext _context;

        public FinancialGoalTransactionsRepository(DbFinancialGoalsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FinancialGoalTransactions financialGoalTransactions)
        {
            await _context.FinancialGoalTransactions.AddAsync(financialGoalTransactions);
        }

        public async Task<List<FinancialGoalTransactions>> GetAllAsync(PaginationParameters paginationParameters)
        {
            return await _context.FinancialGoalTransactions.AsNoTracking().OrderBy(a => a.TransactionDate)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize).ToListAsync();
        }

        public async Task<IEnumerable<FinancialGoalTransactions>> GetAllReport()
        {
            return await _context.FinancialGoalTransactions.Include(a => a.FinancialGoal)
                .ToListAsync();
        }

        public async Task<FinancialGoalTransactions> GetByIdAsync(Guid id)
        {
            var financialTransaction = await _context.FinancialGoalTransactions
                .Include(f => f.FinancialGoal)
                .SingleOrDefaultAsync(f => f.Id == id);

            return financialTransaction;
        }

        public async Task<List<FinancialGoalTransactions>> GetByIdFinancialGoalAsync(Guid id)
        {
            var financialTransactions = await _context.FinancialGoalTransactions
                .Include(f => f.FinancialGoal)
                .Where(f => f.FinancialGoal.Id == id) // Filtra as transações pela meta financeira
                .ToListAsync(); // Retorna uma lista

            return financialTransactions;
        }
    }
}
