

namespace Domain.Shared.ValueObjects
{
    public class OrderStatus
    {
        public static readonly OrderStatus Pending = new OrderStatus("Pending");
        public static readonly OrderStatus Confirmed = new OrderStatus("Confirmed");
        public static readonly OrderStatus Completed = new OrderStatus("Completed");

        public string Status { get; private set; }

        private OrderStatus(string status)
        {
            Status = status;
        }

        public override string ToString() => Status;
    }
}
