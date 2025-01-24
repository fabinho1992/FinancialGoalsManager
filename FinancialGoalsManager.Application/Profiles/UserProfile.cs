using AutoMapper;
using FinancialGoalsManager.Application.Dtos.ViewModels.UsersResponse;
using FinancialGoalsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailsResponse>().ForMember(x => x.FinancialGoalResponse, op =>
                op.MapFrom(x => x.FinancialGoals)).ReverseMap();
        }
    }
}
