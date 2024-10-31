

namespace Domain.Shared.ValueObjects
{
    public class OrderMetrics
    {
        public Guid OrderId { get; }
        public Money OrderValue { get; }
        public TimeSpan DeliveryTime { get; }
        public int Rating { get; } // Rating out of 5
        public bool IsOrderOpen { get; } // Indicates if the order is still open or closed

        public OrderMetrics(Guid orderId, Money orderValue, TimeSpan deliveryTime, int rating, bool isOrderOpen)
        {
            OrderId = orderId;
            OrderValue = orderValue;
            DeliveryTime = deliveryTime;
            Rating = rating;
            IsOrderOpen = isOrderOpen;
        }
    }
}
