using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse
{
    public class UserDetailsResponse
    {
        public UserDetailsResponse()
        {
            
        }

        public UserDetailsResponse(Guid id, string fullName, string cpf, string email, List<FinancialGoalResponse> financialGoalResponses)
        {
            Id = id;
            FullName = fullName;
            Cpf = cpf;
            Email = email;
            FinancialGoalResponse = financialGoalResponses;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public List<FinancialGoalResponse> FinancialGoalResponse { get; private set; } = new List<FinancialGoalResponse>();
    }
}
