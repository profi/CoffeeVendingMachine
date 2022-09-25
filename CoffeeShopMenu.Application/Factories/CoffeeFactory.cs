using System;
using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Factories
{
    public class CoffeeFactory : ICoffeeFactory
    {
        public ICoffee Create(CoffeeTypeEnum coffeeType, string description = "", decimal price = 1)
        {
            switch (coffeeType)
            {
                case CoffeeTypeEnum.Espresso:
                    return new Espresso();

                case CoffeeTypeEnum.Cappuccino:
                    return new Cappuccino();

                case CoffeeTypeEnum.Americano:
                    return new Americano();

                case CoffeeTypeEnum.DeCaf:
                    return new DeCaf();

                case CoffeeTypeEnum.Mocha:
                    return new Mocha();

                default:
                    throw new ArgumentException();
            }
        }

        public ICoffee CreateExternalTypeOfCoffe(CoffeeTypeEnum coffeeType, string description = "Basic Coffee", decimal price = 1, int selectionId = 1)
        {
            switch (coffeeType)
            {
                case CoffeeTypeEnum.External:
                    return new ExternalTypeCoffee(description, price, selectionId);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
