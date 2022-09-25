using CoffeeShopMenu.Application.Services;
using CoffeeShopMenu.Application.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShopMenu.ConsoleUI
{
    public static class ServiceLocator
    {
        public static ServiceProvider Services { get; set; }

        public static void Setup()
        {
            //Only one instance of these services will be required, hence add singleton
            Services = new ServiceCollection()
                .AddSingleton<ICoffeeService, CoffeeService>()
                .AddSingleton<IAddOnService, AddOnService>()
                .AddSingleton<ICoffeeFactory, CoffeeFactory>()
                .AddSingleton<IAddOnFactory, AddOnFactory>()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return Services.GetService<T>();
        }
    }
}
