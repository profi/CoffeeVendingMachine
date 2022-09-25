using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class WhippedCream : IAddOn
    {
        public AddOnType AddOnType => AddOnType.WhippedCream;

        public string Description => "Whipped Cream";

        public decimal Price => 0.2M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t{Price.ToString("C")}";
        }
    }
}
