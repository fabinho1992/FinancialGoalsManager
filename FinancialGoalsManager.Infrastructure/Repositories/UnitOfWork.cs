using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private IFinancialGoalRepository? _financialGoalRepository;
        private IFinancialGoalTransactionRepository? _financialGoalTransactionRepository;

        private readonly DbFinancialGoalsContext _context;

        public UnitOfWork(DbFinancialGoalsContext context)
        {
            _context = context;
        }

        public IFinancialGoalRepository FinancialGoalRepository
        {
            get 
            {
                return _financialGoalRepository = _financialGoalRepository ?? new FinancialGoalRepository(_context);
            }
        }

        public IFinancialGoalTransactionRepository FinancialGoalTransactionRepository
        {
            get
            {
                return _financialGoalTransactionRepository = _financialGoalTransactionRepository ?? new FinancialGoalTransactionsRepository(_context);  
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
