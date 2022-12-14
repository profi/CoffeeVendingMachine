using System.Collections.Generic;
using CoffeeShopMenu.Domain.Entities.Coffee;

namespace CoffeeShopMenu.Application.Services
{
    public interface ICoffeeService
    {
        IEnumerable<ICoffeeBase> ListAll();
    }
}