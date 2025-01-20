using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Models
{
    public class User
    {
        public User(string fullName, string cpf, string email)
        {
            Id = new Guid();
            FullName = fullName;
            Cpf = cpf;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public List<FinancialGoal> FinancialGoals { get; private set; } = new List<FinancialGoal>();
    }
}
