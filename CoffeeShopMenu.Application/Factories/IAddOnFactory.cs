using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Domain.Entities.Coffee;
using CoffeeShopMenu.Application.Decorators;

namespace CoffeeShopMenu.Application.Factories
{
    public interface IAddOnFactory
    {
        IAddOnDecorator Create(ICoffee coffee, AddOnType addOnType);
    }
}