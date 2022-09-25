using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public class Espresso : ICoffeeBase, ICoffee
    {
        public CoffeeTypeEnum CoffeeType => CoffeeTypeEnum.Espresso;

        public string Description => "Espresso";

        public decimal Price => 1;

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
