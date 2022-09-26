using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public interface IAddOnDecorator : ICoffee
    {
        ICoffee Coffee { get; }
    }
}
