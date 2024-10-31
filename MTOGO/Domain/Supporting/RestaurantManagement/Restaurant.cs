using Domain.Shared.ValueObjects;


namespace Domain.Supporting.RestaurantManagement
{
    public class Restaurant
    {
        public Guid RestaurantId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public decimal ServiceFee { get; private set; } // Variable fee percentage
        private List<MenuItem> _menuItems = new List<MenuItem>();
        public IReadOnlyCollection<MenuItem> MenuItems => _menuItems.AsReadOnly();

        public Restaurant(Guid restaurantId, string name, string location, decimal serviceFee)
        {
            RestaurantId = restaurantId;
            Name = name;
            Location = location;
            ServiceFee = serviceFee;
        }

        public void UpdateMenu(List<MenuItem> newMenuItems)
        {
            _menuItems = newMenuItems ?? throw new ArgumentNullException(nameof(newMenuItems));
        }

        public void SetServiceFee(decimal feePercentage)
        {
            ServiceFee = feePercentage;
        }
    }
}
