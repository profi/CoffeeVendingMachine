using CoffeeShopMenu.ConsoleUI;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var program = new Program();

            var result = program.InsertCoin(value);

            Assert.IsFalse(result, $"{value} should be be above 5");
        }
    }
}