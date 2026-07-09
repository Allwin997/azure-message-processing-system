using AzureMessageProcessing.Shared.Models;

namespace AzureMessageProcessing.Shared.Interfaces
{
    public interface IMessagePublisher
    {
        Task PublishAsync(OrderMessage message);
    }
}
