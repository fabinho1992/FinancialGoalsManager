using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinancialGoalsManager.Application.Dtos.ViewModels
{
    public class SimulationResponse
    {
        public SimulationResponse(double amountInvested, double rate, int months, double amountReturned)
        {
            AmountInvested = amountInvested;
            Rate = rate;
            Months = months;
            AmountReturned = amountReturned;
        }

        public double AmountInvested { get; private set; }
        public double Rate { get; private set; }
        public int Months { get; private set; }
        public double AmountReturned { get; private set; }
        
    }
}
