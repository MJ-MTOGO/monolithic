using Domain.Shared.ValueObjects;


namespace Domain.Supporting.RestaurantManagement
{
    public class Menu
    {
        public Guid MenuId { get; private set; }
        public Guid RestaurantId { get; private set; }
        private List<MenuItem> _menuItems;
        public IReadOnlyCollection<MenuItem> MenuItems => _menuItems.AsReadOnly();

        public Menu(Guid restaurantId)
        {
            MenuId = Guid.NewGuid();
            RestaurantId = restaurantId;
            _menuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            if (menuItem == null) throw new ArgumentNullException(nameof(menuItem));
            _menuItems.Add(menuItem);
        }

        public void RemoveMenuItem(Guid itemId)
        {
            var item = _menuItems.Find(i => i.ItemId == itemId);
            if (item != null)
            {
                _menuItems.Remove(item);
            }
        }

        public void UpdateMenuItems(List<MenuItem> newMenuItems)
        {
            if (newMenuItems == null) throw new ArgumentNullException(nameof(newMenuItems));
            _menuItems = newMenuItems;
        }
    }
}
