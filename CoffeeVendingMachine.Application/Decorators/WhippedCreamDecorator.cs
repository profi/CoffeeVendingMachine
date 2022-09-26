using CoffeeShopMenu.Domain.Entities.AddOn;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Decorators
{
    public class WhippedCreamDecorator : IAddOnDecorator
    {
        private readonly WhippedCream whippedCream;

        public WhippedCreamDecorator(ICoffee coffee)
        {
            this.whippedCream = new WhippedCream();
            this.Coffee = coffee;
        }

        public ICoffee Coffee { get; }

        public string GetDescription()
        {
            return $"{Coffee.GetDescription()} \n + {whippedCream.Description}";
        }

        public decimal GetPrice()
        {
            return Coffee.GetPrice() + whippedCream.Price;
        }
    }
}
