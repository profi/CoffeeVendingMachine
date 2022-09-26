using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class Chocolate : IAddOn
    {
        public AddOnType AddOnType => AddOnType.Chocolate;

        public string Description => "Chocolate";

        public decimal Price => 1.5M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
