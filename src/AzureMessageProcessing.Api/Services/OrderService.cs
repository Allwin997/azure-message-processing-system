using AzureMessageProcessing.Api.Interfaces;
using AzureMessageProcessing.Shared.Constants;
using AzureMessageProcessing.Shared.DTOs;
using AzureMessageProcessing.Shared.Interfaces;
using AzureMessageProcessing.Shared.Models;
using Microsoft.Extensions.Logging;

namespace AzureMessageProcessing.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IMessagePublisher messagePublisher, ILogger<OrderService> logger)
        {
            _messagePublisher = messagePublisher;
            _logger = logger;
        }
        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            var order = new OrderMessage
            {
                OrderId = Guid.NewGuid(),
                CustomerName = request.CustomerName,
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Price = request.Price,
                CreatedOn = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };
            _logger.LogInformation("Publishing Order {OrderId} for customer {CustomerName}",
            order.OrderId, order.CustomerName);
            await _messagePublisher.PublishAsync(order);
            _logger.LogInformation("Order {OrderId} published successfully.", order.OrderId);
            return new CreateOrderResponse
            {
                OrderId = order.OrderId,
                Message = "Order submitted successfully."
            };

        }
    }
}
