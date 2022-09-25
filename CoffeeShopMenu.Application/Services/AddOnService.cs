using System.Collections.Generic;
using CoffeeShopMenu.Domain.Entities.AddOn;

namespace CoffeeShopMenu.Application.Services
{
    public class AddOnService : IAddOnService
    {
        public IEnumerable<IAddOn> ListAll()
        {
            yield return new Caramel();
            yield return new Chocolate();
            yield return new Cinnamon();
            yield return new Ice();
            yield return new Milk();
            yield return new Water();
            yield return new WhippedCream();
        }
    }
}
