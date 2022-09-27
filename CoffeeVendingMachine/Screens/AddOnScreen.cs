using System;
using System.Text;
using System.Linq;
using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Domain.Entities.Coffee;
using CoffeeShopMenu.Application.Factories;
using CoffeeShopMenu.Application.Services;

namespace CoffeeShopMenu.ConsoleUI.Screens
{
    public class AddOnScreen
    {
        private readonly IAddOnFactory addOnFactory;
        private readonly IAddOnService addOnService;

        public AddOnScreen()
        {
            addOnFactory = ServiceLocator.GetService<IAddOnFactory>();
            addOnService = ServiceLocator.GetService<IAddOnService>();
        }

        public ICoffee CaptureAddOns(ICoffee coffee)
        {
            var done = false;

            while (!done)
            {
                DisplayAddOnMenu();

                var optionSelected = Console.ReadLine();
                if (optionSelected == "0")
                {
                    done = true;
                }
                else
                {
                    int.TryParse(optionSelected.ToString(), out int selected);

                    if (Enum.IsDefined(typeof(AddOnType), selected))
                    {
                        var addOnType = (AddOnType)selected;
                        coffee = addOnFactory.Create(coffee, addOnType);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                }
            }

            return coffee;
        }

        private void DisplayAddOnMenu()
        {
            var addOnOptions = addOnService
                .ListAll()
                .OrderBy(c => (int)c.AddOnType);

            Console.Clear();

            var builder = new StringBuilder();
            builder.AppendLine("ADD ON MENU");
            builder.AppendLine(Constants.Separator);
            builder.AppendLine();

            foreach (var option in addOnOptions)
            {
                builder.AppendLine(option.ToString());
            }

            builder.AppendLine();
            builder.AppendLine($"0 - Add to Order");

            builder.AppendLine();
            builder.Append("Add on - choice: ");

            Console.Write(builder);
        }
    }
}
