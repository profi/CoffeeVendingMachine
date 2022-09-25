using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public interface IAddOn
    {
        AddOnType AddOnType { get; }

        string Description { get; }

        decimal Price { get; }
    }
}
