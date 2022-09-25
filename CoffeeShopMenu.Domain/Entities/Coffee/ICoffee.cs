namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public interface ICoffee
    {
        string GetDescription();

        decimal GetPrice();
    }
}
