namespace AzureMessageProcessing.Shared.Models
{
    public class OrderMessage
    {
        public Guid OrderId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
