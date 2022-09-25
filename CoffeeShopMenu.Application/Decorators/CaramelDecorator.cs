using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public class CaramelDecorator : IAddOnDecorator
    {
        private readonly Caramel caramel;

        public CaramelDecorator(ICoffee coffee)
        {
            this.caramel = new Caramel();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {caramel.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + caramel.Price;
        }
    }
}
