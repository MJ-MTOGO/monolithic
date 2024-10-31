using Domain.Shared.ValueObjects;


namespace Domain.Supporting.BonusCalculation
{
    public class Bonus
    {
        public Guid BonusId { get; private set; }
        public Guid DeliveryAgentId { get; private set; }
        public Money Amount { get; private set; }
        public DateTime EarnedDate { get; private set; }
        public ApprovalCondition ApprovalCondition { get; private set; }

        public Bonus(Guid deliveryAgentId, Money amount, ApprovalCondition approvalCondition)
        {
            BonusId = Guid.NewGuid();
            DeliveryAgentId = deliveryAgentId;  
            Amount = amount;
            EarnedDate = DateTime.UtcNow;
            ApprovalCondition = approvalCondition;
        }

        public bool IsEligible(DateTime deliveryTime)
        {
            return ApprovalCondition.IsWithinEligibleTime(deliveryTime);
        }
    }
}
