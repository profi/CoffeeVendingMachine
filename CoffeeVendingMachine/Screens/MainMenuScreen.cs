using System;
using System.Text;
using System.Linq;
using CoffeeShopMenu.Domain.Enums;
using CoffeeShopMenu.Application.Services;
using System.Collections.Generic;
using CoffeeShopMenu.Domain.Entities.Dto;
using CoffeeShopMenu.Domain.Entities.Coffee;
using System.IO;
using System.Text.Json;

namespace CoffeeShopMenu.ConsoleUI.Screens
{
    public class MainMenuScreen
    {
        private readonly ICoffeeService coffeeService;

        public MainMenuScreen()
        {
            coffeeService = ServiceLocator.GetService<ICoffeeService>();
        }

        public Dictionary<ExternalCoffeeDto, MenuTypeEnum> CaptureCoffeeType(MenuTypeEnum menyType)
        {
            Dictionary<ExternalCoffeeDto, MenuTypeEnum> coffeeType = new Dictionary<ExternalCoffeeDto, MenuTypeEnum>();

            while (coffeeType.Count == 0)
            {
                switch (menyType)
                {
                    case MenuTypeEnum.MainMenu:

                        DisplayMainMenu();

                        var optionSelected = Console.ReadLine().ToString();

                        int.TryParse(optionSelected, out int selected);

                        if (Enum.IsDefined(typeof(CoffeeTypeEnum), selected))
                        {
                            coffeeType.Add(new ExternalCoffeeDto() { SelectionId = selected }, menyType);
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    case MenuTypeEnum.ExternalMenu:

                        var externalCoffeList = DisplayExternalMenu();

                        var externalCoffeSelected = Console.ReadLine().ToString();

                        int.TryParse(externalCoffeSelected, out int externalSelected);

                        var selectedExternal = externalCoffeList.SingleOrDefault(x => x.SelectionId == externalSelected);
                        
                        if(selectedExternal is null)
                        {
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        else
                        {
                            coffeeType.Add(selectedExternal, menyType);
                        }

                        break;
                    case MenuTypeEnum.CustomMenu:
                        coffeeType.Add(new ExternalCoffeeDto() , menyType);
                        break;
                }
             
            }

            return coffeeType;
        }

        public MenuTypeEnum CaptureMenuType()
        {
            MenuTypeEnum? result = null;
            while (result == null)
            {
                DisplayDeafultMenu();

                var optionSelected = Console.ReadLine().ToString();

                int.TryParse(optionSelected, out int selected);

                if (Enum.IsDefined(typeof(MenuTypeEnum), selected))
                {
                    result = (MenuTypeEnum)selected;
                }
                else
                {
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
            }

            return result.Value;
        }

        private void DisplayMainMenu()
        {
            var coffeeOptions = coffeeService.ListAll().OrderBy(c => (int)c.CoffeeType);

            Console.Clear();

            var builder = new StringBuilder();
            builder.AppendLine("MAIN MENU");
            builder.AppendLine(Constants.Separator);
            builder.AppendLine();

            coffeeOptions.Select(c => c).ToList().ForEach(c => builder.AppendLine(c.ToString()));

            builder.AppendLine();
            builder.Append("Choose your coffee: ");
            Console.Write(builder);
        }

        private List<ExternalCoffeeDto>  DisplayExternalMenu()
        {

            string externalJsonFilePath = @"C:\Users\Kliment Petreski\source\repos\CVMDamilah\CoffeeVendingMachine.Domain\Files\\ExternalCoffees.json";

            var externalCoffeelistDto =JsonSerializer.Deserialize<ExternalCoffeesListDto>(File.ReadAllText(externalJsonFilePath));

            List<ICoffeeBase> coffeeOptions = new List<ICoffeeBase>();

            foreach (var externalCoffee in externalCoffeelistDto.ExternalCoffeesList)
            {
                coffeeOptions.Add(coffeeService.CreateExternalCoffee(externalCoffee.Description, externalCoffee.Price, externalCoffee.SelectionId));
            }

            Console.Clear();

            var builder = new StringBuilder();
            builder.AppendLine("EXTERNAL MENU");
            builder.AppendLine(Constants.Separator);
            builder.AppendLine();

            coffeeOptions.Select(c => c).ToList().ForEach(c => builder.AppendLine(c.ToString()));

            builder.AppendLine();
            builder.Append("Choose your coffee: ");
            Console.Write(builder);
            return externalCoffeelistDto.ExternalCoffeesList;
        }

        private void DisplayDeafultMenu()
        {
            var coffeeOptions = new Dictionary<int,string>()
            {
                { (int)MenuTypeEnum.MainMenu, "Main Coffees" },
                { (int)MenuTypeEnum.ExternalMenu, "External Coffees" },
                { (int)MenuTypeEnum.CustomMenu, "Make you own Coffee" }
            };

            Console.Clear();

            var builder = new StringBuilder();
            builder.AppendLine("DEFAULT MENU");
            builder.AppendLine(Constants.Separator);
            builder.AppendLine();

            coffeeOptions.Select(c => c).ToList().ForEach(c => builder.AppendLine(c.Key.ToString() + " - " + c.Value.ToString()));

            builder.AppendLine();
            builder.Append("Choose Option: ");
            Console.Write(builder);
        }
    }
}
