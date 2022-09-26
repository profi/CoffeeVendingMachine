using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public class Cappuccino : ICoffeeBase, ICoffee
    {
        public CoffeeTypeEnum CoffeeType => CoffeeTypeEnum.Cappuccino;

        public string Description => "Cappuccino";
        
        public decimal Price => 4;

        public string GetDescription()
        {
            return Description;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"{(int)CoffeeType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
