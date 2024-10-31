

namespace Domain.Shared.ValueObjects
{
    public class MenuItem
    {
        public Guid ItemId { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public MenuItem(Guid itemId, string name, string description, decimal price)
        {
            ItemId = itemId;
            Name = name;
            Description = description;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj is MenuItem other)
                return ItemId == other.ItemId && Name == other.Name && Description == other.Description && Price == other.Price;
            return false;
        }

        public override int GetHashCode() => (ItemId, Name, Description, Price).GetHashCode();
    }
}
