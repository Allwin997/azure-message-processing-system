using Azure.Monitor.OpenTelemetry.Exporter;
using AzureMessageProcessing.Function.Services;
using AzureMessageProcessing.Shared.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddOpenTelemetry()
    .UseFunctionsWorkerDefaults();
builder.Services.AddSingleton<IBlobStorageService, BlobStorageService>();

builder.Build().Run();
