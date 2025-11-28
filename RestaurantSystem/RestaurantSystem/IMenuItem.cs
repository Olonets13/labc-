namespace RestaurantSystem.Interfaces
{
    public interface IMenuItem
    {
        string Name { get; }
        decimal Price { get; }
        string GetInfo();
    }
}
