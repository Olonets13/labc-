using RestaurantSystem.Enums;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Models
{
    public class Order
    {
        public int Id { get; }
        public int TableNumber { get; }
        public OrderStatus Status { get; private set; }

        private List<IMenuItem> items = new List<IMenuItem>();
        public IReadOnlyList<IMenuItem> Items => items;

        public Order(int id, int table)
        {
            Id = id;
            TableNumber = table;
            Status = OrderStatus.New;
        }

        public void AddItem(IMenuItem item)
        {
            items.Add(item);
            Console.WriteLine($"Додано позицію: {item.Name}");
        }

        public void RemoveItem(string name)
        {
            var item = items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"Позицію видалено: {name}");
            }
        }

        public decimal GetTotal() => items.Sum(i => i.Price);

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"> Змінено статус: {newStatus}");
        }
    }
}
