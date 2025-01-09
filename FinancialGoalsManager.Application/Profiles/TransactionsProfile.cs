using AutoMapper;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalsTransactionsResponses;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<FinancialGoalTransactions, FinancialTransactionsResponse>().ReverseMap();
        }
    }
}
