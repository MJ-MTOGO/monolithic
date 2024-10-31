

namespace Domain.Shared.ValueObjects
{
    public class OrderItem
    {
        public Guid ItemId { get; }
        public string Name { get; }
        public int Quantity { get; }
        public Money UnitPrice { get; }

        public OrderItem(Guid itemId, string name, int quantity, Money unitPrice)
        {
            ItemId = itemId;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
        }
    }
}
