using FinancialGoalsManager.Application.Dtos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.FinancialGoalQueries.IncomeSimulation
{
    public class IncomeSimulationQuery : IRequest<SimulationResponse>
    {
        public IncomeSimulationQuery(double amountInvested, double rate, int months)
        {
            AmountInvested = amountInvested;
            Rate = rate;
            Months = months;
        }

        public double AmountInvested { get; private set; }
        public double Rate { get; private set; }
        public int Months { get; private set; }
    }
}
