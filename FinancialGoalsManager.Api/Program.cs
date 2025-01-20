

using FinancialGoalsManager.Api.ErrorsMiddleware;
using FinancialGoalsManager.Extensions.DependencyInjections;
using FinancialGoalsManager.Infrastructure.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFinancialGoals(builder.Configuration);
builder.Services.AddMassTransit(c =>
{
    c.AddConsumer<TransactionCreatedConsumer>();
    c.AddConsumer<UserCreatedConsumer>();

    c.UsingRabbitMq((context, config) =>
    {
        // Configura todos os endpoints automaticamente
        config.ConfigureEndpoints(context);

        var exchangeName = context.GetRequiredService<IConfiguration>()["ConnectionStrings:RabbitMQ:ExchangeName"];

        // Configura um endpoint específico para o consumidor
        config.ReceiveEndpoint("Transaction_Created", e =>
        {
            e.ConfigureConsumer<TransactionCreatedConsumer>(context); // Configure o consumidor
            e.Bind(exchangeName, x => x.RoutingKey = "Transaction_Created");
        });

        config.ReceiveEndpoint("User_Created", e =>
        {
            e.ConfigureConsumer<UserCreatedConsumer>(context);
            e.Bind(exchangeName, x => x.RoutingKey = "User_Created");
        });
    });
});

builder.Services.AddDependencyInjection();
builder.Services.AddSettingsController();
builder.Services.AddExtensionsMediatR();
builder.Services.AddFluentValidation();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErrorMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
