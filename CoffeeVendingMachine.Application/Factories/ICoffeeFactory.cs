using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Factories
{
    public interface ICoffeeFactory
    {
        ICoffee Create(CoffeeTypeEnum coffeeType, string description = "", decimal price = 1);
        ICoffee CreateExternalTypeOfCoffe(CoffeeTypeEnum coffeeType, string description = "Basic Coffee", decimal price = 1, int selectionId = 1);
    }
}