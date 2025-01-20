using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse
{
    public class UserListResponse
    {
        public UserListResponse(Guid id, string fullName, string cpf, string email)
        {
            Id = id;
            FullName = fullName;
            Cpf = cpf;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
    }
}
