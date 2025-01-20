using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync(PaginationParameters parameters);
        Task Delete(User user);
        Task Update(User user);
    }
}
