using System;
using System.Text;
using CoffeeShopMenu.Application.Services;

namespace CoffeeShopMenu.ConsoleUI.Screens
{
    public class OrderScreen
    {
        private readonly IOrderService orderService;

        public OrderScreen()
        {
            orderService = ServiceLocator.GetService<IOrderService>();
        }

        public decimal DisplayOrder()
        {
            Console.Clear();

            var builder = new StringBuilder();
            builder.AppendLine("Please Review Your Order");
            builder.AppendLine(Constants.Separator);
            builder.AppendLine();

            var totalPrice = 0M;
            var orderedItems = orderService.GetOrderItems();
            foreach (var item in orderedItems)
            {
                var description = item.GetDescription();
                var price = item.GetPrice();

                builder.AppendLine(description);
                builder.AppendLine($"Price: {price.ToString("C")}");
                builder.AppendLine();

                totalPrice += price;
            }

            builder.AppendLine($"Please Insert: {totalPrice.ToString("C")}");
            builder.AppendLine();
            builder.AppendLine(Constants.Separator);

            Console.Write(builder);

            return totalPrice;
        }

    }
}
