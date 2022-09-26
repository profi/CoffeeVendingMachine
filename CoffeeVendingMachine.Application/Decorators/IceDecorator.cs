using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public class IceDecorator : IAddOnDecorator
    {
        private readonly Ice ice;

        public IceDecorator(ICoffee coffee)
        {
            this.ice = new Ice();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {ice.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + ice.Price;
        }
    }
}
