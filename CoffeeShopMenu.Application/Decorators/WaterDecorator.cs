using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public class WaterDecorator : IAddOnDecorator
    {
        private readonly Water water;

        public WaterDecorator(ICoffee coffee)
        {
            this.water = new Water();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {water.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + water.Price;
        }
    }
}
