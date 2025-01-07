using FinancialGoalsManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.DataContext
{
    public class DbFinancialGoalsContext : DbContext
    {
        public DbFinancialGoalsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<FinancialGoalTransactions> FinancialGoalTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
