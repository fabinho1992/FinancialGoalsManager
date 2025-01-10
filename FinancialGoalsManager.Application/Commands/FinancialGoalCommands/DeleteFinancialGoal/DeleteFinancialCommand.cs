using FinancialGoalsManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Commands.FinancialGoalCommands.DeleteFinancialGoal
{
    public class DeleteFinancialCommand : IRequest<ResultViewModel>
    {
        public DeleteFinancialCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
