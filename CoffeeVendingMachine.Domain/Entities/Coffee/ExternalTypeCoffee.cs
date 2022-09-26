using CoffeeShopMenu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopMenu.Domain.Entities.Coffee
{
    public class ExternalTypeCoffee : ICoffeeBase, ICoffee    
    {
        private string _ExternalDescription;
        private decimal _ExternalPrice;
        private int _CoffeeTypeExternal;

        public ExternalTypeCoffee(string description, decimal price , int coffyTypeExternal)
        {
            _ExternalDescription = description;
            _ExternalPrice = price;
            _CoffeeTypeExternal = coffyTypeExternal;
        }
        public CoffeeTypeEnum CoffeeType => CoffeeTypeEnum.External;
        public int SelectionId => SetCoffeeType(_CoffeeTypeExternal);

        public string Description => SetDescription(_ExternalDescription);

        public decimal Price => SetPrice(_ExternalPrice);

        public string SetDescription(string description)
        {
            return description;
        }

        public string GetDescription()
        {
            return Description;
        }

        public decimal SetPrice(decimal price)
        {
            return price;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public int SetCoffeeType(int coffeTypeExternal)
        {
            return coffeTypeExternal;
        }

        public override string ToString()
        {
            return $"{SelectionId} - {Description}:\t\t{Price.ToString("C")}";
        }
    }
}
