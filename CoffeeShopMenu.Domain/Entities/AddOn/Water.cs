using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class Water : IAddOn
    {
        public AddOnType AddOnType => AddOnType.Water;

        public string Description => "Water";

        public decimal Price => 0.0M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
