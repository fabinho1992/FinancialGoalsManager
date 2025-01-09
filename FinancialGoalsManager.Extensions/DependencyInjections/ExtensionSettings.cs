using FinancialGoalsManager.Application.Commands.FinancialGoalCommands.CreateFinancialGoal;
using FinancialGoalsManager.Application.FluentValidation;
using FinancialGoalsManager.Application.Profiles;
using FinancialGoalsManager.Application.ServicesEmail;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Services;
using FinancialGoalsManager.Domain.Services.Bus;
using FinancialGoalsManager.Infrastructure.BusService;
using FinancialGoalsManager.Infrastructure.DataContext;
using FinancialGoalsManager.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Extensions.DependencyInjections
{
    public static class ExtensionSettings
    {
        public static IServiceCollection AddDbContextFinancialGoals(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbFinancialGoalsContext>(opt =>
                            opt.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
            services.AddScoped<IFinancialGoalTransactionRepository, FinancialGoalTransactionsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISendEmail, SendEmail>();
            services.AddScoped<IBusService, BusServiceMassTransit>();


            //AutoMapper
            services.AddAutoMapper(typeof(FinanciaGoalPeofile));


            return services;
        }

        public static IServiceCollection AddSettingsController(this IServiceCollection services)
        {
            services.AddControllers()
               .AddJsonOptions(op =>
               {
                   op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// mostra no Schemas do swagger os valores do enum
                   op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               })
               .AddNewtonsoftJson(op => op.SerializerSettings.Converters.Add(new StringEnumConverter()));


            return services;
        }

        public static IServiceCollection AddExtensionsMediatR(this IServiceCollection services)
        {
            var myHandlers = AppDomain.CurrentDomain.Load("FinancialGoalsManager.Application");
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(myHandlers));

            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateFinancialGoalValidation>();

            return services;
        }

        
    }
}
