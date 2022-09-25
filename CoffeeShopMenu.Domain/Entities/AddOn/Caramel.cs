using CoffeeShopMenu.Domain.Enums;

namespace CoffeeShopMenu.Domain.Entities.AddOn
{
    public class Caramel : IAddOn
    {
        public AddOnType AddOnType => AddOnType.Caramel;

        public string Description => "Caramel";

        public decimal Price => 0.8M;

        public override string ToString()
        {
            return $"{(int)AddOnType} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
