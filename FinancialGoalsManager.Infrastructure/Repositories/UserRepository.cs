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
    public class UserRepository : IUserRepository
    {
        private readonly DbFinancialGoalsContext _context;

        public UserRepository(DbFinancialGoalsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task Delete(User user)
        {
            var userDelete = await GetByIdAsync(user.Id);
            _context.Remove(userDelete);
        }

        public async Task<List<User>> GetAllAsync(PaginationParameters parameters)
        {
            return await _context.Users.AsNoTracking().OrderBy(a => a.FullName)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {

            var user = await _context.Users.Include(u => u.FinancialGoals)
                .SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task Update(User user)
        {
            _context.Update(user);
        }
    }
}
