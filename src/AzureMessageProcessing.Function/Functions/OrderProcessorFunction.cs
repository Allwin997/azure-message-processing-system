using AzureMessageProcessing.Shared.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureMessageProcessing.Function.Functions
{
    public class OrderProcessorFunction
    {
        private readonly ILogger<OrderProcessorFunction> _logger;

        public OrderProcessorFunction(ILogger<OrderProcessorFunction> logger)
        {
            _logger = logger;
        }

        [Function("OrderProcessorFunction")]
        public async Task Run(
            [ServiceBusTrigger("order-queue", Connection = "ServiceBusConnection")]
        string message)
        {
            _logger.LogInformation("Message received.");

            var order = JsonSerializer.Deserialize<OrderMessage>(message);

            if (order == null)
            {
                _logger.LogError("Unable to deserialize message.");
                return;
            }

            _logger.LogInformation(
                "Processing Order {OrderId} for {CustomerName}",
                order.OrderId,
                order.CustomerName);

            // Blob Storage implementation will be added in the next phase.

            await Task.CompletedTask;
        }
    }
}
