using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class Milk : IAddOn
    {
        public AddOnType AddOnType => AddOnType.Milk;

        public string Description => "Milk";

        public decimal Price => 0.5M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
