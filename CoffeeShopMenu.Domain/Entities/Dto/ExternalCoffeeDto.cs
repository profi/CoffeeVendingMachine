using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopMenu.Domain.Entities.Dto
{
    public class ExternalCoffeeDto
    {
        public int SelectionId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
