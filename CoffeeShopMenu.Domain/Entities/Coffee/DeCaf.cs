using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public class DeCaf : ICoffeeBase, ICoffee
    {
        public CoffeeTypeEnum CoffeeType => CoffeeTypeEnum.DeCaf;

        public string Description => "deCaf";
        
        public decimal Price => 3;

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
