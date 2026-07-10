using AzureMessageProcessing.Api.Configuration;
using AzureMessageProcessing.Api.Interfaces;
using AzureMessageProcessing.Api.Services;
using AzureMessageProcessing.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ServiceBusSettings>(builder.Configuration.GetSection("ServiceBusSettings"));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IMessagePublisher, ServiceBusMessagePublisher>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
