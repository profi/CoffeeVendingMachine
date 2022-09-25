using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public class Americano : ICoffeeBase, ICoffee
    {
        public CoffeeTypeEnum CoffeeType => CoffeeTypeEnum.Americano;

        public string Description => "Americano";

        public decimal Price => 2;

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
