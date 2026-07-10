using System.Text.Json;
using Azure.Messaging.ServiceBus;
using AzureMessageProcessing.Api.Configuration;
using AzureMessageProcessing.Shared.Interfaces;
using AzureMessageProcessing.Shared.Models;
using Microsoft.Extensions.Options;

namespace AzureMessageProcessing.Api.Services;

public class ServiceBusMessagePublisher : IMessagePublisher
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;

    public ServiceBusMessagePublisher(IOptions<ServiceBusSettings> options)
    {
        var settings = options.Value;

        _client = new ServiceBusClient(settings.ConnectionString);
        _sender = _client.CreateSender(settings.QueueName);
    }

    public async Task PublishAsync(OrderMessage message)
    {
        var json = JsonSerializer.Serialize(message);

        var serviceBusMessage = new ServiceBusMessage(json);

        await _sender.SendMessageAsync(serviceBusMessage);
    }
}