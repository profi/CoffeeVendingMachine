using System;
using CoffeeShopMenu.ConsoleUI.Screens;
using CoffeeShopMenu.Application.Services;
using CoffeeShopMenu.Application.Factories;
using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Domain.Entities.Coffee;
using System.Linq;

namespace CoffeeShopMenu.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Coffee Vending Menu";
            var program = new Program();
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

                        var totalPrice = orderScreen.DisplayOrder();

                var IsOrderFinished = program.InsertCoin(totalPrice);

                        if (IsOrderFinished)
                        {
                            break;
                        }

                        break;                 
                }               
            }
        

        public static void AddOrder(MenuTypeEnum menu)
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

        public static bool IsOrderComplete()
        {
            Console.WriteLine("\nAdd another coffee to your order? Y/N");

            var isOrderComplete = !string.Equals(Console.ReadLine(), "y", StringComparison.OrdinalIgnoreCase);

            return isOrderComplete;
        }

        public  bool InsertCoin(decimal totalValue)
        {
            Console.WriteLine("Insert Credit");

            var currencyValue  = Console.ReadLine();

            while(Convert.ToDecimal(currencyValue) < totalValue)
            {
                Console.WriteLine("Not enoug credit please insert more " + (totalValue - Convert.ToDecimal(currencyValue)));
                currencyValue = currencyValue + Console.ReadLine();
            }

            Console.WriteLine("Please take your order....");

            return true;
        }
    }
}
