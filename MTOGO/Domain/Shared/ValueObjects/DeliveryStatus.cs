

namespace Domain.Shared.ValueObjects
{
    public class DeliveryStatus
    {
        public static readonly DeliveryStatus Assigned = new DeliveryStatus("Assigned");
        public static readonly DeliveryStatus InTransit = new DeliveryStatus("InTransit");
        public static readonly DeliveryStatus Delivered = new DeliveryStatus("Delivered");

        public string Status { get; private set; }

        private DeliveryStatus(string status)
        {
            Status = status;
        }

        public override string ToString() => Status;
    }
}
