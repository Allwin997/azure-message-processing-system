using AzureMessageProcessing.Api.Interfaces;
using AzureMessageProcessing.Shared.Constants;
using AzureMessageProcessing.Shared.DTOs;
using AzureMessageProcessing.Shared.Interfaces;
using AzureMessageProcessing.Shared.Models;

namespace AzureMessageProcessing.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMessagePublisher _messagePublisher;
        public OrderService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
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

            await _messagePublisher.PublishAsync(order);

            return new CreateOrderResponse
            {
                OrderId = order.OrderId,
                Message = "Order submitted successfully."
            };
        }
    }
}
