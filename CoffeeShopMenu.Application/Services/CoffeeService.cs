using System.Collections.Generic;
using CoffeeShopMenu.Domain.Entities.Coffee;
using CoffeeShopMenu.Domain.Entities.Dto;

namespace CoffeeShopMenu.Application.Services
{
    public class CoffeeService : ICoffeeService
    {
        public IEnumerable<ICoffeeBase> ListAll()
        {
            yield return new Americano();
            yield return new Cappuccino();
            yield return new DeCaf();
            yield return new Espresso();
            yield return new Mocha();            
        }

        public ICoffeeBase CreateExternalCoffee(string description , decimal price, int selectionId)
        {
            return new ExternalTypeCoffee(description, price, selectionId);
        }
        
    }
}
