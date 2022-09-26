using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public class MilkDecorator : IAddOnDecorator
    {
        private readonly Milk milk;

        public MilkDecorator(ICoffee coffee)
        {
            this.milk = new Milk();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {milk.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + milk.Price;
        }
    }
}
