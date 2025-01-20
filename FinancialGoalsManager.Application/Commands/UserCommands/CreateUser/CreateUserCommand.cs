using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<Guid>>
    {
        public CreateUserCommand(string fullName, string cpf, string email)
        {
            FullName = fullName;
            Cpf = cpf;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
    }
}
