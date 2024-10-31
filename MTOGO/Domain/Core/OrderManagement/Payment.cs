
using Domain.Shared.ValueObjects;

namespace Domain.Core.OrderManagement
{
    public class Payment
    {
        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public Money Amount { get; private set; }
        public string Status { get; private set; }
        public DateTime ProcessedAt { get; private set; }

        public Payment(Guid orderId, Money amount)
        {
            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            Status = "Pending";
            ProcessedAt = DateTime.MinValue;
        }

        public void MarkAsProcessed()
        {
            Status = "Processed";
            ProcessedAt = DateTime.UtcNow;
        }
    }
}
