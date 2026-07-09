namespace AzureMessageProcessing.Shared.DTOs
{
    public class CreateOrderResponse
    {
        public Guid OrderId { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
