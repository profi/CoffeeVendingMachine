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

        public void DisplayOrder()
        {
            Console.Clear();

            var builder = new StringBuilder();
            builder.AppendLine("Please Review Your Order");
            builder.AppendLine(Constants.TitleSeparator);
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

            builder.AppendLine($"Total Order Price: {totalPrice.ToString("C")}");
            builder.AppendLine();
            builder.AppendLine(Constants.TitleSeparator);

            Console.Write(builder);
        }

    }
}
