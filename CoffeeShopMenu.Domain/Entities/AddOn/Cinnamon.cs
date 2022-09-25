using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class Cinnamon : IAddOn
    {
        public AddOnType AddOnType => AddOnType.Cinnamon;

        public string Description => "Cinnamon";

        public decimal Price => 1M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
