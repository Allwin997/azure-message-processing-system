using AzureMessageProcessing.Shared.DTOs;

namespace AzureMessageProcessing.Api.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);
    }
}
