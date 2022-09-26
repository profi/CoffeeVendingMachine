using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public interface ICoffeeBase
    {
        CoffeeTypeEnum CoffeeType { get; }

        string Description { get; }

        decimal Price { get; }
    }
}
