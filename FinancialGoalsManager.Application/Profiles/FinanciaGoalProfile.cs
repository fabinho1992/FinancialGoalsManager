using AutoMapper;
using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.UpdateFinancialGoal;
using FinancialGoalsManager.Application.Dtos.ViewModels.FinancialGoalResponses;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Profiles
{
    public class FinanciaGoalProfile : Profile
    {
        public FinanciaGoalProfile()
        {
            CreateMap<FinancialGoal, FinancialGoalByIdResponse>()
                .ForMember(x => x.FinancialGoalTransactions, op => 
                op.MapFrom(x => x.FinancialGoalTransactions)).ReverseMap();

            CreateMap<UpdateFinancialGoalCommand, FinancialGoal>().ReverseMap();

            CreateMap<FinancialGoalResponse, FinancialGoal>().ReverseMap();
        }
    }
}
