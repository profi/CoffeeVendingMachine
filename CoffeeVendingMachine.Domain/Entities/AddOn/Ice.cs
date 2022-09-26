using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class Ice : IAddOn
    {
        public AddOnType AddOnType => AddOnType.Ice;

        public string Description => "Ice";

        public decimal Price => 0.1M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
