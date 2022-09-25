using System;
using CoffeeShopMenu.ConsoleUI.Screens;
using CoffeeShopMenu.Application.Services;
using CoffeeShopMenu.Application.Factories;
using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Domain.Entities.Coffee;
using System.Linq;

namespace CoffeeShopMenu.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Coffee Vending Menu";

            ServiceLocator.Setup();
            var orderService = ServiceLocator.GetService<IOrderService>();
            var orderScreen = new OrderScreen();

            while (true)
            {
                orderService.Initialize();

                var defaultMenuScreen = new MainMenuScreen();

                var menuType = defaultMenuScreen.CaptureMenuType();

                        do
                        {
                            AddOrder(menuType);
                        }
                        while (!IsOrderComplete());

                        orderScreen.DisplayOrder();

                        if (ExitProgram())
                        {
                            break;
                        }

                        break;                 
                }               
            }
        

        private static void AddOrder(MenuTypeEnum menu)
        {

            var mainMenuScreen = new MainMenuScreen();

            var coffeeType = mainMenuScreen.CaptureCoffeeType(menu);
                   
            var coffeeFactory = ServiceLocator.GetService<ICoffeeFactory>();

            var coffeeTypeDto = coffeeType.Take(1).Select(d => d.Key).First();

            var coffeeTypeIdEnum = (CoffeeTypeEnum)coffeeTypeDto.SelectionId;

            ICoffee coffee = null;

            if (menu == MenuTypeEnum.MainMenu)
            {
                coffee = coffeeFactory.Create(coffeeTypeIdEnum);
            }

            if(menu == MenuTypeEnum.ExternalMenu)
            {
                coffee = coffeeFactory.CreateExternalTypeOfCoffe(CoffeeTypeEnum.External, coffeeTypeDto.Description, coffeeTypeDto.Price, coffeeTypeDto.SelectionId);
            }

            if (menu == MenuTypeEnum.CustomMenu)
            {
                coffee = coffeeFactory.CreateExternalTypeOfCoffe(CoffeeTypeEnum.External);
            }

            var addOnScreen = new AddOnScreen();
            
            coffee = addOnScreen.CaptureAddOns(coffee);

            var orderService = ServiceLocator.GetService<IOrderService>();
            
            orderService.AddToOrder(coffee);
        }

        private static bool IsOrderComplete()
        {
            Console.WriteLine("\nAdd another coffee to your order? Y/N");

            var isOrderComplete = !string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);

            return isOrderComplete;
        }

        private static bool ExitProgram()
        {
            Console.WriteLine("\n0 - Exit program");
            Console.WriteLine("1 - Add another order");

            return Console.ReadLine().ToString() == "0";
        }
    }
}
