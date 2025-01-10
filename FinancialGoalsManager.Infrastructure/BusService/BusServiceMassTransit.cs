﻿using FinancialGoalsManager.Domain.Services.Bus;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Infrastructure.BusService
{
    public class BusServiceMassTransit : IBusService
    {
        private readonly IBus _bus;
        private readonly string _exchangeName;
        private readonly string _queueName;

        public BusServiceMassTransit(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _exchangeName = configuration["ConnectionStrings:RabbitMQ:ExchangeName"] ?? throw new Exception("ExchangeName não configurado!");
            _queueName = configuration["ConnectionStrings:RabbitMQ:QueueName"] ?? throw new Exception("QueueName não configurado!");
        }

        public async Task Publish<T>(T message)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"rabbitmq://localhost/{_exchangeName}"));
            await endpoint.Send(message);
        }
    }
}