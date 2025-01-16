using AutoMapper;
using FinancialGoalsManager.Application.Profiles;
using FinancialGoalsManager.Domain.IRepositories;
using FinancialGoalsManager.Domain.Models;
using FinancialGoalsManager.Infrastructure.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Tests1.Controller.Service
{
    public class ServiceTestsController
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IMediator _mediator;

        public ServiceTestsController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FinanciaGoalProfile());
            });

            _mapper = config.CreateMapper();

            // Configurando o IUnitOfWork
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork = mockUnitOfWork.Object;

            // Configurando o IMediator
            var mockMediator = new Mock<IMediator>();

            // Aqui você deve configurar o mock para retornar um resultado esperado
            //mockMediator.Setup(m => m.Send(It.IsAny<FinancialGoalRepository>(), It.IsAny<CancellationToken>()))
            //  .ReturnsAsync(new FinancialGoal("Teste", 100, new DateTime(2026, 01, 10), 1000)); // Retorne um objeto que você espera

            _mediator = mockMediator.Object;
        }

    }
    
}
