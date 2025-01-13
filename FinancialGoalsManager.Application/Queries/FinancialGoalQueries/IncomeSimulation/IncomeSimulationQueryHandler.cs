using FinancialGoalsManager.Application.Dtos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Queries.FinancialGoalQueries.IncomeSimulation
{
    public class IncomeSimulationQueryHandler : IRequestHandler<IncomeSimulationQuery, SimulationResponse>
    {
        public Task<SimulationResponse> Handle(IncomeSimulationQuery request, CancellationToken cancellationToken)
        {
            double amountInvested = request.AmountInvested;
            double rate = request.Rate / 100; // Certifique-se de converter a taxa para decimal
            int months = request.Months;

            // Cálculo do retorno
            double amountReturned = amountInvested * Math.Pow((1 + rate), months);
            amountReturned = Math.Round(amountReturned, 2); // Arredondando para duas casas decimais

            var simulation = new SimulationResponse(amountInvested, rate, months, amountReturned);

            return Task.FromResult(simulation);


        }
    }
}
