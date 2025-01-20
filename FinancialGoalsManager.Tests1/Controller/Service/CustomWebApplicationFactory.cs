using AutoMapper;
using FinancialGoalsManager.Application.Profiles;
using FinancialGoalsManager.Application.Queries.FinancialGoalQueries.FinancialGoalById;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Tests1.Controller.Service
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Cria um mock do IUnitOfWork
                var mockUnitOfWork = new Mock<IUnitOfWork>();

                // Configura o mock para retornar um objeto FinancialGoal quando GetByIdAsync for chamado
                
                var financialGoalId = "123e4567-e89b-12d3-a456-426655440000";
                var financialGoal = new FinancialGoal(Guid.Parse(financialGoalId), "teste", 100, new DateTime(2026, 01, 18), 1000);
                financialGoal.InsertIdTest(Guid.Parse(financialGoalId)); // Insira um ID válido

                mockUnitOfWork.Setup(uow => uow.FinancialGoalRepository.GetByIdAsync(It.IsAny<Guid>()))
                              .ReturnsAsync(financialGoal);

                // Substitui o IUnitOfWork pelo mock
                services.AddScoped<IUnitOfWork>(provider => mockUnitOfWork.Object);

                // Configura o AutoMapper
                var config = new MapperConfiguration(cfg => cfg.AddProfile<FinanciaGoalProfile>());
                var mapper = config.CreateMapper();
                services.AddSingleton(mapper);

                // Configura o MediatR
                // Configura o MediatR
                services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblyContaining<FinancialGoalByIdQueryHandler>());// Passa o tipo do manipulador
            });
        }
    }
}

