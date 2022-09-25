using System;
using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Application.Decorators;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Factories
{
    public class AddOnFactory : IAddOnFactory
    {
        public IAddOnDecorator Create(ICoffee coffee, AddOnType addOnType)
        {
            switch (addOnType)
            {
                case AddOnType.Milk:
                    return new MilkDecorator(coffee);

                case AddOnType.Chocolate:
                    return new ChocolateDecorator(coffee);

                case AddOnType.Cinnamon:
                    return new CinnamonDecorator(coffee);

                case AddOnType.WhippedCream:
                    return new WhippedCreamDecorator(coffee);

                case AddOnType.Ice:
                    return new IceDecorator(coffee);

                case AddOnType.Caramel:
                    return new CaramelDecorator(coffee);

                case AddOnType.Water:
                    return new WaterDecorator(coffee);

                default:
                    throw new ArgumentException(nameof(addOnType));
            }
        }
    }
}
