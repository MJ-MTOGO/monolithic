using Domain.Shared.ValueObjects;


namespace Domain.Core.OrderManagement
{
    public class Order
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid RestaurantId { get; private set; }
        public Money TotalAmount { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(Guid customerId, Guid restaurantId, List<OrderItem> orderItems)
        {
            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            RestaurantId = restaurantId;
            _orderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));
            TotalAmount = CalculateTotalAmount();
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        private Money CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice.Amount * item.Quantity;
            }
            return new Money(total, "DKK"); // assuming currency is DKK
        }

        public void ConfirmOrder()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Order is not in a pending state.");
            Status = OrderStatus.Confirmed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsDelivered()
        {
            if (Status != OrderStatus.Confirmed)
                throw new InvalidOperationException("Order must be confirmed before delivery.");
            Status = OrderStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
