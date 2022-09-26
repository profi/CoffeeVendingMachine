using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public class CinnamonDecorator : IAddOnDecorator
    {
        private readonly Cinnamon cinnamon;

        public CinnamonDecorator(ICoffee coffee)
        {
            this.cinnamon = new Cinnamon();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {cinnamon.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + cinnamon.Price;
        }
    }
}
