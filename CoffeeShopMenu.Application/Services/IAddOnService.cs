using System.Collections.Generic;
using CoffeeShopMenu.Domain.Entities.AddOn;

namespace CoffeeShopMenu.Application.Services
{
    public interface IAddOnService
    {
        IEnumerable<IAddOn> ListAll();
    }
}