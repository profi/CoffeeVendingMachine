using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    class ChocolateDecorator : IAddOnDecorator
    {
        private readonly Chocolate chocolate;

        public ChocolateDecorator(ICoffee coffee)
        {
            this.chocolate = new Chocolate();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {chocolate.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + chocolate.Price;
        }
    }
}
