using Domain.Shared.ValueObjects;

namespace Domain.Core.DeliveryManagement
{
    public class DeliveryAssignment
    {
        public Guid AssignmentId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid DeliveryAgentId { get; private set; }
        public DeliveryStatus Status { get; private set; }
        public DateTime PickupTime { get; private set; }
        public DateTime? DeliveryTime { get; private set; }

        public DeliveryAssignment(Guid orderId, Guid deliveryAgentId)
        {
            AssignmentId = Guid.NewGuid();
            OrderId = orderId;
            DeliveryAgentId = deliveryAgentId;
            Status = DeliveryStatus.Assigned;
            PickupTime = DateTime.UtcNow;
        }

        public void MarkInTransit()
        {
            if (Status != DeliveryStatus.Assigned)
                throw new InvalidOperationException("Cannot mark as in transit if not assigned.");
            Status = DeliveryStatus.InTransit;
        }

        public void MarkAsDelivered()
        {
            if (Status != DeliveryStatus.InTransit)
                throw new InvalidOperationException("Order must be in transit to mark as delivered.");
            Status = DeliveryStatus.Delivered;
            DeliveryTime = DateTime.UtcNow;
        }

        public Money CalculateBonus()
        {
            // Example rule: 1% of order value as a bonus if delivered between 18:00-06:00
            bool isEligibleForBonus = PickupTime.Hour >= 18 || PickupTime.Hour < 6;
            return isEligibleForBonus ? new Money(0.01m, "DKK") : new Money(0m, "DKK");
        }
    }
}
