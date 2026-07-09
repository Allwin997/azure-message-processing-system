using AzureMessageProcessing.Shared.Models;

namespace AzureMessageProcessing.Shared.Interfaces
{
    public interface IBlobStorageService
    {
        Task UploadAsync(OrderMessage message);
    }
}
